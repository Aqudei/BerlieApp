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
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            ActivateItem(IoC.Get<DashboardViewModel>());
            this._windowManager = windowManager;
        }

        public void ListEmployees()
        {
            ActivateItem(IoC.Get<EmployeeListViewModel>());
        }

        public void AddEmployee()
        {
            _windowManager.ShowDialog(IoC.Get<AddEditEmployeeViewModel>());

        }

        public void GoHome()
        {
            ActivateItem(IoC.Get<DashboardViewModel>());
        }
    }
}
