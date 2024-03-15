using System;

namespace WB.Models.Database
{
    internal class PickupPoints
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; } // (будет добавлен атрибут в БД)
    }
}
