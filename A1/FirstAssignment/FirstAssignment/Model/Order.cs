using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FirstAssignment.Model
{
    [XmlType("item")]
    public class Item {

        [XmlElement("partnumber")]
        public string partnumber 
        {
            get; set;
        }

        [XmlElement("quantity")]
        public string quantity {
            get; set;
        }

    }

   // public class OrderItems {
        
     //   [XmlArray("item")]
       // public List<Item> lstItem = new List<Item>();
    //}

    public class Dealer
    {
        [XmlElement("dealerid")]
        public string dealerid
        {
         get; set;
        }

        [XmlElement("dealeraccesskey")]
        public string dealeraccesskey
        {
            get; set;
        }

    }

    public class DeliveryAddress
    {
        [XmlElement("name")]
        public string name
        {
            get; set;
        }

        [XmlElement("street")]
        public string street
        {
            get; set;
        }

        [XmlElement("city")]
        public string city
        {
            get; set;
        }

        [XmlElement("province")]
        public string province
        {
            get; set;
        }

        [XmlElement("postalcode")]
        public string postalcode
        {
            get; set;
        }

    }

    [XmlRoot("order")]
    public class Order
    {
        
        [XmlElement("dealer")]
        public Dealer objDealer { get; set; }

        [XmlArray("orderitems")]
        public List<Item> objOrderItems { get; set; }

        [XmlElement("deliveryaddress")]
        public DeliveryAddress objDeliveryAddress { get; set; }
    }
}
