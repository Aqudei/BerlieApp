using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BerlieApp.ViewModels
{
    class AddEditEmployeeViewModel : Screen
    {
        public void Cancel()
        {
            var mbRslt = MessageBox.Show("Cancel adding/editing employee record?", "Confirm action", MessageBoxButton.YesNo);
            if (mbRslt == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void Save()
        {

        }
    }
}
