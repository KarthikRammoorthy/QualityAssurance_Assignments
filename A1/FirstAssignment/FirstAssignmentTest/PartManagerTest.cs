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
    public class PartManagerTest
    {

        //Unit Tests for methods insidePartManager class. Since, the class has nooutside dependencies, 
        // no dependency injection and mocking techniques are followed.

        #region POSITIVE TEST CASE

        [TestMethod()]
        public void PartManager_SubmitPartForManufactureAndDelivery_NoLongerManufactured()
        {
            //Arrange
            string partNumber = "3333";
            string quantity = "20";
            Order objOrder = new Order();
            objOrder.objDeliveryAddress = new DeliveryAddress();
  

            PartManager objPartManager = new PartManager();
            List<PartManager> partManagerMockList = new List<PartManager>();
            objPartManager.objPartResponse = PartManager.PartResponse.NO_LONGER_MANUFACTURED;
            PartManager.PartResponse returnValue;
            objPartManager.PopulatePartManager();
            

            //Act
            returnValue = objPartManager.SubmitPartForManufactureAndDelivery(partNumber,quantity, objOrder.objDeliveryAddress);

            //Result
            Assert.AreEqual(returnValue, objPartManager.objPartResponse);
        }

        [TestMethod()]
        public void PartManager_SubmitPartForManufactureAndDelivery_OutOfStock()
        {
            //Arrange
            string partNumber = "5678";
            string quantity = "35";
            Order objOrder = new Order();
            objOrder.objDeliveryAddress = new DeliveryAddress();


            PartManager objPartManager = new PartManager();
            List<PartManager> partManagerMockList = new List<PartManager>();
            objPartManager.objPartResponse = PartManager.PartResponse.OUT_OF_STOCK;
            PartManager.PartResponse returnValue;
            objPartManager.PopulatePartManager();


            //Act
            returnValue = objPartManager.SubmitPartForManufactureAndDelivery(partNumber, quantity, objOrder.objDeliveryAddress);

            //Result
            Assert.AreEqual(returnValue, objPartManager.objPartResponse);
        }

        [TestMethod()]
        public void PartManager_SubmitPartForManufactureAndDelivery_Success()
        {
            //Arrange
            string partNumber = "5678";
            string quantity = "25";
            Order objOrder = new Order();
            objOrder.objDeliveryAddress = new DeliveryAddress();


            PartManager objPartManager = new PartManager();
            List<PartManager> partManagerMockList = new List<PartManager>();
            objPartManager.objPartResponse = PartManager.PartResponse.SUCCESS;
            PartManager.PartResponse returnValue;
            objPartManager.PopulatePartManager();


            //Act
            returnValue = objPartManager.SubmitPartForManufactureAndDelivery(partNumber, quantity, objOrder.objDeliveryAddress);

            //Result
            Assert.AreEqual(returnValue, objPartManager.objPartResponse);
        }

        [TestMethod()]
        public void PartManager_ValidatePartNumber_Success()
        {
            //Arrange
            string partNumber = "5678";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidPartNumber(partNumber);

            //Result
            Assert.IsTrue(returnValue);
        }

      
        [TestMethod()]
        public void PartManager_ValidateQuantity_Success()
        {
            //Arrange
            string quantity = "58";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidQuantity(quantity);

            //Result
            Assert.IsTrue(returnValue);
        }

       

        [TestMethod()]
        public void PartManager_ValidateAddress_Success()
        {
            //Arrange
            DeliveryAddress objDeliveryAddress = new DeliveryAddress();
            objDeliveryAddress.name = "Test";
            objDeliveryAddress.city = "halifax";
            objDeliveryAddress.street = "34 NS street";
            objDeliveryAddress.province = "NS";
            objDeliveryAddress.postalcode = "B3J3J7";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidAddress(objDeliveryAddress);

            //Result
            Assert.IsTrue(returnValue);
        }

      

        #endregion

        #region NEGATIVE TEST CASE

        [TestMethod()]
        public void PartManager_ValidatePartNumber_Failure()
        {
            //Arrange
            string partNumber = "";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidPartNumber(partNumber);

            //Result
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void PartManager_ValidateQuantity_Failure()
        {
            //Arrange
            string quantity = "a";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidPartNumber(quantity);

            //Result
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void PartManager_ValidateAddress_Failure()
        {
            //Arrange
            DeliveryAddress objDeliveryAddress = new DeliveryAddress();
            objDeliveryAddress.name = "";
            objDeliveryAddress.city = "halifax";
            objDeliveryAddress.street = "34 NS street";
            objDeliveryAddress.province = "NS";
            objDeliveryAddress.postalcode = "B3J3J7";
            Boolean returnValue;
            PartManager objPartManager = new PartManager();


            //Act
            returnValue = objPartManager.IsValidAddress(objDeliveryAddress);

            //Result
            Assert.IsFalse(returnValue);
        }


        #endregion
    }
}

