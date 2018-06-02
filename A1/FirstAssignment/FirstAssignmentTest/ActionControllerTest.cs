using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FirstAssignment.Model;
using FirstAssignment.Controller;
using Unity;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace FirstAssignmentTest
{
    [TestClass()]
    public class ActionControllerTest
    {

        #region POSITIVE TEST CASE

        /// <summary>
        /// XML Deserializer and populating PartManager and Security classes
        /// </summary>
        [TestMethod()]
        public void XMLDeserializer_TestObjectNotNull_Positve()
        {
            //Arrange
            string inputFile = @"../../XML_UnitTest_files/IncomingOrder.xml"; 
            Order orderObj = new Order();
            List<PartManager> partManagerMockList = new List<PartManager>();
            List<Security> secMockList = new List<Security>();

            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockPartManager.Setup(x => x.PopulatePartManager()).Returns(partManagerMockList);
            mockSecurity.Setup(x => x.PopulateSecurity()).Returns(secMockList);

            //Act
            var result = actionObj.XMLDeserializer(inputFile);

            //Result
            Assert.IsNotNull(result);
            Assert.IsTrue(result.objOrderItems.Count == 2);
        }


        [TestMethod()]
        public void XMLValidation_ValidAuthorization_ValidXML_PartResponse_SUCCESS()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objItem.partnumber = "5678";
            objItem.quantity = "10";
            objOrder.objDeliveryAddress = new DeliveryAddress();
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = true;
            PartManager.PartResponse partResponse = PartManager.PartResponse.SUCCESS;


            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockPartManager.Setup(x => x.objPartResponse).Returns(partResponse);
            mockPartManager.Setup(x => x.SubmitPartForManufactureAndDelivery(objOrder.objOrderItems[0].partnumber, objOrder.objOrderItems[0].quantity, objOrder.objDeliveryAddress)).Returns(partResponse);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.objOrderItems[0].result == "success");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_ValidXML_PartResponse_OUT_OF_STOCK()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objItem.partnumber = "5678";
            objItem.quantity = "10";
            objOrder.objDeliveryAddress = new DeliveryAddress();
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = true;

            PartManager.PartResponse partResponse = PartManager.PartResponse.OUT_OF_STOCK;

            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockPartManager.Setup(x => x.objPartResponse).Returns(partResponse);
            mockPartManager.Setup(x => x.SubmitPartForManufactureAndDelivery(objOrder.objOrderItems[0].partnumber, objOrder.objOrderItems[0].quantity, objOrder.objDeliveryAddress)).Returns(partResponse);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.objOrderItems[0].errormessage == "out of stock");
        }


        [TestMethod()]
        public void XMLValidation_ValidAuthorization_ValidXML_PartResponse_NO_LONGER_MANUFACTURED()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objItem.partnumber = "5678";
            objItem.quantity = "10";
            objOrder.objDeliveryAddress = new DeliveryAddress();
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = true;
            PartManager.PartResponse partResponse = PartManager.PartResponse.NO_LONGER_MANUFACTURED;


            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockPartManager.Setup(x => x.objPartResponse).Returns(partResponse);
            mockPartManager.Setup(x => x.SubmitPartForManufactureAndDelivery(objOrder.objOrderItems[0].partnumber, objOrder.objOrderItems[0].quantity, objOrder.objDeliveryAddress)).Returns(partResponse);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.objOrderItems[0].result == "failure");
        }


        #endregion


        #region NEGATIVE TEST CASE
        
        [TestMethod()]
        public void XMLDeserializer_TestObjectNotNull_Negative()
        {
            try
            {


                //Arrange
                string inputFile = "";
                Order orderObj = new Order();
                List<PartManager> partManagerMockList = new List<PartManager>();
                List<Security> secMockList = new List<Security>();

                //Mock
                var mockPartManager = new Mock<IPartManager>();
                var mockSecurity = new Mock<ISecurity>();
                ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
                mockPartManager.Setup(x => x.PopulatePartManager()).Returns(partManagerMockList);
                mockSecurity.Setup(x => x.PopulateSecurity()).Returns(secMockList);

                //Act
                var result = actionObj.XMLDeserializer(inputFile);

            }
            catch (Exception e)
            {
                //Result
                Assert.IsNotNull(e);
            }

           
        }

        [TestMethod()]
        public void XMLValidation_DealerAuthorized_InvalidAuthorization()
        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objDealer.dealeraccesskey = "kkklas8882kk23nllfjj88290";
            objOrder.objDealer.dealerid = "XXX-1234-ABCD-1234";
            var isAuthorized = false;


            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.errormessage == "Not authorized");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLOrderNumber()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objItem.partnumber = "";
            objOrder.objDealer.dealeraccesskey = "kkklas8882kk23nllfjj88290";
            objOrder.objDealer.dealerid = "XXX-1234-ABCD-1234";
            objOrder.objDeliveryAddress = new DeliveryAddress();
            var isAuthorized = true;
            var isValidOrderItem = false;
            var isValidQuantity = true;
            var isValidAddress = true;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid Order Item Type");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLQuantity()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objItem.quantity = "";
            objOrder.objDeliveryAddress = new DeliveryAddress();
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = false;
            var isValidAddress = true;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid Quantity");

        }



        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLAddress_InvalidName()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objOrder.objDeliveryAddress = new DeliveryAddress();
            objOrder.objDeliveryAddress.name = "";
            objOrder.objDeliveryAddress.city = "halifax";
            objOrder.objDeliveryAddress.street = "34 NS street";
            objOrder.objDeliveryAddress.province = "NS";
            objOrder.objDeliveryAddress.postalcode = "B3J3J7";
            objItem.quantity = "";
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = false;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid DeliveryAddress");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLAddress_InvalidStreetName()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objOrder.objDeliveryAddress = new DeliveryAddress();
            objOrder.objDeliveryAddress.name = "Test";
            objOrder.objDeliveryAddress.city = "halifax";
            objOrder.objDeliveryAddress.street = "";
            objOrder.objDeliveryAddress.province = "NS";
            objOrder.objDeliveryAddress.postalcode = "B3J3J7";
            objItem.quantity = "";
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = false;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid DeliveryAddress");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLAddress_InvalidCity()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objOrder.objDeliveryAddress = new DeliveryAddress();
            objOrder.objDeliveryAddress.name = "Test";
            objOrder.objDeliveryAddress.city = "";
            objOrder.objDeliveryAddress.street = "34 NS Street";
            objOrder.objDeliveryAddress.province = "NS";
            objOrder.objDeliveryAddress.postalcode = "B3J3J7";
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = false;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid DeliveryAddress");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLAddress_InvalidProvince()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objOrder.objDeliveryAddress = new DeliveryAddress();
            objOrder.objDeliveryAddress.name = "Test";
            objOrder.objDeliveryAddress.city = "Halifax";
            objOrder.objDeliveryAddress.street = "34 NS Street";
            objOrder.objDeliveryAddress.province = "";
            objOrder.objDeliveryAddress.postalcode = "B3J3J7";
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = false;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid DeliveryAddress");
        }

        [TestMethod()]
        public void XMLValidation_ValidAuthorization_InvalidXML_InvalidXMLAddress_InvalidPincode()

        {
            //Arrange
            string outputFile = @"../../XML_UnitTest_files/Response.xml";
            OrderResponse orderResponseObj = new OrderResponse();
            Order objOrder = new Order();
            objOrder.objDealer = new Dealer();
            objOrder.objOrderItems = new List<Item>();
            Item objItem = new Item();
            objOrder.objDeliveryAddress = new DeliveryAddress();
            objOrder.objDeliveryAddress.name = "Test";
            objOrder.objDeliveryAddress.city = "Halifax";
            objOrder.objDeliveryAddress.street = "34 NS Street";
            objOrder.objDeliveryAddress.province = "NS";
            objOrder.objDeliveryAddress.postalcode = "";
            var isAuthorized = true;
            var isValidOrderItem = true;
            var isValidQuantity = true;
            var isValidAddress = false;
            objOrder.objOrderItems.Add(objItem);



            //Mock
            var mockPartManager = new Mock<IPartManager>();
            var mockSecurity = new Mock<ISecurity>();
            ActionController actionObj = new ActionController(mockPartManager.Object, mockSecurity.Object);
            mockSecurity.Setup(x => x.IsDealerAuthorized(objOrder.objDealer.dealerid, objOrder.objDealer.dealeraccesskey)).Returns(isAuthorized);
            mockPartManager.Setup(x => x.IsValidPartNumber(objOrder.objOrderItems[0].partnumber)).Returns(isValidOrderItem);
            mockPartManager.Setup(x => x.IsValidQuantity(objOrder.objOrderItems[0].quantity)).Returns(isValidQuantity);
            mockPartManager.Setup(x => x.IsValidAddress(objOrder.objDeliveryAddress)).Returns(isValidAddress);
            mockSecurity.Setup(x => x.PopulateSecurity());
            mockPartManager.Setup(x => x.PopulatePartManager());

            //Act
            actionObj.ValidateXML(outputFile, objOrder);
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderResponse));
            TextReader reader = new StreamReader(outputFile, System.Text.Encoding.UTF8);
            object obj = deserializer.Deserialize(reader);
            OrderResponse XmlData = (OrderResponse)obj;
            reader.Close();

            //Result

            Assert.IsTrue(XmlData.result == "failure");
            Assert.IsTrue(XmlData.error == "Invalid Order");
            Assert.IsTrue(XmlData.errormessage == "Invalid DeliveryAddress");
        }



        #endregion
    }
}
