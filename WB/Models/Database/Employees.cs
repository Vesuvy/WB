using System;

namespace WB.Models.Database
{
    internal class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public PickupPoints FK_PickupPoint { get; set; }
        public bool isAdmin { get; set; }
    }
}
