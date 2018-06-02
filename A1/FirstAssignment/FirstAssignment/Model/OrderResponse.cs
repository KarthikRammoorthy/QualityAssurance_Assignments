using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FirstAssignment.Model
{
    [XmlType("item")]
    public class ItemResponse
    {

        [XmlElement("partnumber")]
        public string partnumber
        {
            get; set;
        }

        [XmlElement("quantity")]
        public string quantity
        {
            get; set;
        }

        [XmlElement("result")]
        public string result
        {
            get; set;
        }


        [XmlElement("errormessage")]
        public string errormessage
        {
            get; set;
        }

    }

    // public class OrderItems {

    //   [XmlArray("item")]
    // public List<Item> lstItem = new List<Item>();
    //}




    
    [XmlRoot("order")]
    public class OrderResponse
    {

        [XmlArray("orderitems")]
        public List<ItemResponse> objOrderItems { get; set; }

        [XmlElement("result")]
        public string result
        {
            get; set;
        }

        [XmlElement("error")]
        public string error
        {
            get; set;
        }

        [XmlElement("errormessage")]
        public string errormessage
        {
            get; set;
        }


    }
}
