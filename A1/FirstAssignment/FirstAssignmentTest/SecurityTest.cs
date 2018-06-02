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
        [TestClass]
        public class SecurityTest
        //Unit Tests for methods inside Security class. Since, the class has nooutside dependencies, 
        // no dependency injection and mocking techniques are followed.
        { 
        #region POSITIVE TEST CASE

    

        [TestMethod()]
        public void Security_IsDealerAuthorized_ValidAuthorization()
        {
                //Arrange
                string dealerID = "XXX-1234-ABCD-1234";
                string dealerAccessKey = "kkklas8882kk23nllfjj88290";
                Boolean returnValue;
           
                Security objSecurity = new Security();
                List<Security> securityMockList = new List<Security>();
                objSecurity.PopulateSecurity();


                //Act
                returnValue = objSecurity.IsDealerAuthorized(dealerID, dealerAccessKey);

                //Result
                Assert.IsTrue(returnValue);
            }

        #endregion

        #region NEGATIVE TEST CASE

        [TestMethod()]
        public void Security_IsDealerAuthorized_InvalidAuthorization_InvaliddealerID()
        {
            //Arrange
            string dealerID = "345-1234-ABCD-1234";
            string dealerAccessKey = "kkklas8882kk23nllfjj88290";
            Boolean returnValue;

            Security objSecurity = new Security();
            List<Security> securityMockList = new List<Security>();
            objSecurity.PopulateSecurity();


            //Act
            returnValue = objSecurity.IsDealerAuthorized(dealerID, dealerAccessKey);

            //Result
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void Security_IsDealerAuthorized_InvalidAuthorization_InvalidDealerAccessKey()
        {
            //Arrange
            string dealerID = "XXX-1234-ABCD-1234";
            string dealerAccessKey = "kzzlas8882kk23nllfjj88290";
            Boolean returnValue;

            Security objSecurity = new Security();
            List<Security> securityMockList = new List<Security>();
            objSecurity.PopulateSecurity();


            //Act
            returnValue = objSecurity.IsDealerAuthorized(dealerID, dealerAccessKey);

            //Result
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void Security_IsDealerAuthorized_InvalidAuthorization_InvalidDealerAttributes()
        {
            //Arrange
            string dealerID = "123-1234-ABCD-1234";
            string dealerAccessKey = "kzzlas8882kk23nllfjj88290";
            Boolean returnValue;

            Security objSecurity = new Security();
            List<Security> securityMockList = new List<Security>();
            objSecurity.PopulateSecurity();


            //Act
            returnValue = objSecurity.IsDealerAuthorized(dealerID, dealerAccessKey);

            //Result
            Assert.IsFalse(returnValue);
        }


        #endregion
    }
}
