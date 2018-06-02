using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment.Model
{
    public interface IPartManager
    {
        List<PartManager> PopulatePartManager();
        PartManager.PartResponse objPartResponse { get; set; }
        PartManager.PartResponse SubmitPartForManufactureAndDelivery(string partnumber, string quantity, DeliveryAddress deliveryaddress);

        Boolean IsValidPartNumber(string partnumber);
        Boolean IsValidQuantity(string quantity);

        Boolean IsValidAddress(DeliveryAddress objDeliveryAddress);

    }
}
