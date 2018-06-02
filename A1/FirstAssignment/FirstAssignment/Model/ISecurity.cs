using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{
    public interface ISecurity
    {
        List<Security> PopulateSecurity();
        Boolean IsDealerAuthorized(string DealerID, string DealerAccessKey);
    }
}
