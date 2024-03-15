using System;

namespace WB.Models.Database
{
    internal class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public PickupPoints FK_PickupPoint { get; set; }
    }
}
