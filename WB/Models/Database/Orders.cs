using System;

namespace WB.Models.Database
{
    internal class Orders
    {
        public string Id { get; set; }
        public PickupPoints FK_PickupPoint { get; set; }
        public Clients FK_Client { get; set; }
    }
}
