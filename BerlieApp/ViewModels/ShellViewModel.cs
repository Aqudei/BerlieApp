using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.ViewModels
{
    class ShellViewModel : Conductor<object>
    {

        public ShellViewModel()
        {
            ActivateItem(IoC.Get<DashboardViewModel>());
        }

        public void ListEmployees()
        {
            ActivateItem(IoC.Get<EmployeeListViewModel>());
        }
    }
}
