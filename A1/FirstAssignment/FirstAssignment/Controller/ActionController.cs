using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstAssignment.Model;
using System.IO;
using System.Xml.Serialization;
using Ninject;
using Unity;

//Controller that performs input file processing and generates output files
namespace FirstAssignment.Controller
{
    public class ActionController
    {
        
        List<Security> lstSecurity = new List<Security>();
        private IPartManager partManagerService;
        private ISecurity securityService;
      
        //Construct Dependency Resolving using Unity 
        public ActionController(IPartManager partManagerService, ISecurity securityService)
        {
            this.partManagerService = partManagerService;
            this.securityService = securityService;
        }

        //Accepts input xml file and constructs object of class Order
        public Order XMLDeserializer(string inputFile)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Order));
            TextReader reader = new StreamReader(inputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            Order XmlData = (Order)obj;
            reader.Close();            
            return XmlData;
        }

        //Generates output XML file
        public void XMLSerializer(OrderResponse XmlData, string outputFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OrderResponse));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (TextWriter writer = new StreamWriter(outputFile))
            {
                serializer.Serialize(writer, XmlData, ns);
            }


        
        }


        //Validates XML for empty or invalid attributes such as partnumber, quantity and address
        public void ItemsValidation(Boolean isValidPartNumber, Boolean isValidQuantity, Boolean isValidAddress, string outputFile)
        {
            OrderResponse objResponse = new OrderResponse();
           
            if(!isValidPartNumber)
            {
                objResponse.result = "failure";
                objResponse.error = "Invalid Order";
                objResponse.errormessage = "Invalid Order Item Type";
                XMLSerializer(objResponse, outputFile);
                return;
            }
            if (!isValidQuantity)
            {
                objResponse.result = "failure";
                objResponse.error = "Invalid Order";
                objResponse.errormessage = "Invalid Quantity";
                XMLSerializer(objResponse, outputFile);
                return;
            }
            if (!isValidAddress)
            {
                objResponse.result = "failure";
                objResponse.error = "Invalid Order";
                objResponse.errormessage = "Invalid DeliveryAddress";
                XMLSerializer(objResponse, outputFile);
                return;
            }

        }

        //Core Business logic method that checks for dealer authorization and partmanager response.
        public void ValidateXML(string outputFile, Order XmlData)
        {            
            try
            {
                OrderResponse objResponse = new OrderResponse();
                ItemResponse objItemResponse;
                List<ItemResponse> objOrderItems = new List<ItemResponse>();
                var partResponse = "";
                var isAuthorized = false;
                var isValidPartNumber = false;
                var isValidQuantity = false;
                var isValidAddress = false;

                this.partManagerService.PopulatePartManager();
                this.securityService.PopulateSecurity();
                isAuthorized = this.securityService.IsDealerAuthorized(XmlData.objDealer.dealerid, XmlData.objDealer.dealeraccesskey);

                if (isAuthorized == false)
                {
                    objResponse = new OrderResponse();
                    objResponse.result = "failure";
                    objResponse.errormessage = "Not authorized";
                    this.XMLSerializer(objResponse, outputFile);
                }

                if (isAuthorized == true)
                {
                    objResponse = new OrderResponse();
                    objOrderItems = new List<ItemResponse>();
                    foreach (Item item in XmlData.objOrderItems)
                    {
                        isValidPartNumber = this.partManagerService.IsValidPartNumber(item.partnumber);
                        isValidQuantity = this.partManagerService.IsValidQuantity(item.quantity);
                    }
                    isValidAddress = this.partManagerService.IsValidAddress(XmlData.objDeliveryAddress);
                    this.ItemsValidation(isValidPartNumber, isValidQuantity, isValidAddress, outputFile);

                }

                if (isAuthorized == true && isValidAddress == true && isValidPartNumber == true && isValidQuantity == true)
                {
                    objOrderItems = new List<ItemResponse>();
                    foreach (Item item in XmlData.objOrderItems)
                    {
                        objItemResponse = new ItemResponse();
                        this.partManagerService.objPartResponse = this.partManagerService.SubmitPartForManufactureAndDelivery(item.partnumber, item.quantity, XmlData.objDeliveryAddress);
                        partResponse = this.partManagerService.objPartResponse.ToString();
                        if (partResponse.Equals("SUCCESS"))
                        {
                            objItemResponse.result = "success";
                            objItemResponse.quantity = item.quantity;
                            objItemResponse.partnumber = item.partnumber;

                        }
                        else if (partResponse.Equals("OUT_OF_STOCK"))
                        {
                            objItemResponse.result = "failure";
                            objItemResponse.errormessage = "out of stock";
                        }
                        else
                        {
                            objItemResponse.result = "failure";
                            objItemResponse.errormessage = "invalid part number";
                        }
                        objOrderItems.Add(objItemResponse);
                    }
                    objResponse = new OrderResponse();
                    objResponse.objOrderItems = objOrderItems;
                    this.XMLSerializer(objResponse, outputFile);
                }

                //Console.ReadLine();
                //IsValid = true;
                

            }
            catch (Exception e)
            {
                //IsValid = false;                
                Console.WriteLine(e);
            }

            //return IsValid;

        }


        public static void Main(string[] args)
        {

            try
            {

                //Input XML File
                Console.WriteLine("Please Enter Input File Path");
                var inputFile = Console.ReadLine();
                Console.WriteLine("Please Enter Output File Path");
                var outputFile = Console.ReadLine();

                //Resolving dependency
                var container = new UnityContainer();
                container.RegisterType<IPartManager, PartManager>();
                container.RegisterType<ISecurity, Security>();
                ActionController objActionController = container.Resolve<ActionController>();
                Order XmlData = objActionController.XMLDeserializer(inputFile);
                objActionController.ValidateXML(outputFile, XmlData);
                Console.WriteLine("Process Complete. Please check output file.");
                //Console.WriteLine("Validation: {0}", IsValid? "Success" : "Failure");
                Console.Read();

            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }


        }

    }
}
