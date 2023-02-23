using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events.Shipment
{
    public class DeletedShipmentEvent
    {
        public int Id { get; set; }
    }
}
