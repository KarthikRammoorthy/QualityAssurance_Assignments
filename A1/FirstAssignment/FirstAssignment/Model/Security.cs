using System;
using System.Collections.Generic;

namespace FirstAssignment.Model
{
    public class Security : ISecurity
    {
        public string dealerid;
        public string dealeraccesskey;
        List<Security> lstSecurity = new List<Security>();

        public Security()
        {

        }

        public string DealerID
        {
            get { return dealerid; }
            set { dealerid = value; }
        }
        public string DealerAccessKey
        {
            get { return dealeraccesskey; }
            set
            {
                dealeraccesskey = value;
            }
        }

        //Populating List for holding mock data objects
        public List<Security> PopulateSecurity()
        {
            Security objSecurity = new Security();
            objSecurity.DealerID = "XXX-1234-ABCD-1234";
            objSecurity.DealerAccessKey = "kkklas8882kk23nllfjj88290";
            lstSecurity.Add(objSecurity);
            objSecurity = new Security();
            objSecurity.DealerID = "ZZZ-1234-ABCD-1234";
            objSecurity.DealerAccessKey = "kkklas8882kk23nllfjj88290";
            lstSecurity.Add(objSecurity);
            objSecurity = new Security();
            objSecurity.DealerID = "XYZ-1234-ABCD-1234";
            objSecurity.DealerAccessKey = "kkklas8882kk23nllfjj88290";
            lstSecurity.Add(objSecurity);

            return lstSecurity;
        }

        //Validate input dealer details with mockup DB
        public Boolean IsDealerAuthorized(string DealerID, string DealerAccessKey)
        {
            
            foreach(Security security in lstSecurity)
            {
                if ((DealerID.Equals(security.DealerID)) && (DealerAccessKey.Equals(security.DealerAccessKey)))
                    {
                    return true;
                }
                
            }

            return false;
        }

    }
}
