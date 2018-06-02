using System;
using System.Collections.Generic;
using FirstAssignment.Model;

namespace FirstAssignment.Model
{
    public class PartManager : IPartManager
    {
        List<PartManager> lstPartManager = new List<PartManager>(); 
        public string partnumber;
        public string quantity;
        Order objOrder;
        OrderResponse orderResponse;
        public DeliveryAddress objDeliveryAddress;

        //PartResponse return values
        public enum PartResponse
        {
            SUCCESS,
            OUT_OF_STOCK,
            NO_LONGER_MANUFACTURED
        }

        public PartResponse objPartResponse { get; set; }

        public PartManager()
        {

        }

        public string PartNumber
        {
            get { return partnumber; } set { partnumber = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
            }
        }

        //Populate list with data objects
        public List<PartManager> PopulatePartManager()
        {
            PartManager objPartManager = new PartManager();
            objPartManager.PartNumber = "5678";
            objPartManager.quantity = "30";
            lstPartManager.Add(objPartManager);
            objPartManager = new PartManager();
            objPartManager.PartNumber = "5688";
            objPartManager.quantity = "20";
            lstPartManager.Add(objPartManager);

            objPartManager = new PartManager();
            objPartManager.PartNumber = "5478";
            objPartManager.quantity = "30";
            lstPartManager.Add(objPartManager);

            objPartManager = new PartManager();
            objPartManager.PartNumber = "5378";
            objPartManager.quantity = "30";
            lstPartManager.Add(objPartManager);
            
         

            return lstPartManager;
        }

        //Validates the input part details and send the reponse after performing checks
        public PartResponse SubmitPartForManufactureAndDelivery(string partnumber, string quantity, DeliveryAddress deliveryaddress)
        {
            foreach(PartManager part in lstPartManager)
            {
                if(Convert.ToInt32(partnumber) != Convert.ToInt32(part.partnumber))
                {
                    return PartResponse.NO_LONGER_MANUFACTURED;
                    
                }
                else if ((Convert.ToInt32(partnumber) == Convert.ToInt32(part.partnumber)) && (Convert.ToInt32(quantity) <= Convert.ToInt32(part.quantity)))
                {
                    return PartResponse.SUCCESS;
                }
                else if (Convert.ToInt32(quantity) >= Convert.ToInt32(part.quantity))
                {
                    return PartResponse.OUT_OF_STOCK;

                }


            }
            return PartResponse.OUT_OF_STOCK;

        }

        //Performs null or empty validations
        public Boolean IsValidPartNumber(string partnumber)
        {
            if(string.IsNullOrEmpty(partnumber) || !(IsDigits(partnumber)))
            {
                return false;
            }
          
            return true;
        }

        public Boolean IsValidQuantity(string quantity)
        {
            if (string.IsNullOrEmpty(quantity) || !(IsDigits(quantity)))
            {
                return false;
            }
            return true;
        }

        public Boolean IsValidAddress(DeliveryAddress objDeliveryAddress)
        {
            if ((string.IsNullOrEmpty(objDeliveryAddress.name)) || (string.IsNullOrEmpty(objDeliveryAddress.city)) || (string.IsNullOrEmpty(objDeliveryAddress.street)) || (string.IsNullOrEmpty(objDeliveryAddress.province)) || (string.IsNullOrEmpty(objDeliveryAddress.postalcode)))
            {
                return false;
            }

            return true;
        }

        //Test for numerical strings
        public Boolean IsDigits(string str)
        {
            foreach (Char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
