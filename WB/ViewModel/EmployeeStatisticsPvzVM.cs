using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WB.Models.Database;
using WB.Utilities;

namespace WB.ViewModel
{
    internal class EmployeeStatisticsPvzVM : ViewModelBase
    {
        public PickupPoints _pickupPoints;

        
        public EmployeeStatisticsPvzVM(ViewModelStore viewModelStore, Employees employees)
        {

        }

        protected virtual void Dispose() { }
    }
}
