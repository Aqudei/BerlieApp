using BerlieApp.Model;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BerlieApp.ViewModels
{
    class EmployeeListViewModel : Conductor<object>.Collection.OneActive
    {
        private static DebugLog _logger = new DebugLog(typeof(EmployeeListViewModel));
        private Employee _selectedEmployee;
        
        private BindableCollection<Employee> _employees { get; set; }
        public ICollectionView Employees { get; set; }
        public Employee SelectedEmployee { get => _selectedEmployee; set => Set(ref _selectedEmployee, value); }
        public EmployeeListViewModel()
        {
            _employees = new BindableCollection<Employee>();
            Employees = CollectionViewSource.GetDefaultView(_employees);
                      
            Items.Add(IoC.Get<EducationTabViewModel>());
            Items.Add(IoC.Get<DesignationsTabViewModel>());

            _employees.Add(new Employee
            {
                FirstName = "Archie",
                MiddleName = "Espelimbergo",
                LastName = "Cortez",
                Birthday = new DateTime(1988, 8, 30),
                Sex = "Male",
                PlaceOfBirth = "Tacloban City"
            });
            _employees.Add(new Employee
            {
                FirstName = "Mark Lister",
                MiddleName = "Espelimbergo",
                LastName = "Abria",
                Birthday = new DateTime(1991, 12, 22),
                Sex = "Male",
                PlaceOfBirth = "Catarman Northern Samar"
            });
            _employees.Add(new Employee
            {
                FirstName = "Shekaina Donnna",
                MiddleName = "Ladipe",
                LastName = "Alcos",
                Birthday = new DateTime(1988, 4, 5),
                Sex = "Female",
                PlaceOfBirth = "Tacloban City"
            });
        }
        
        public void ViewAttachments()
        {
            _logger.Info("Viewing attachment of : {0}", SelectedEmployee);
        }
    }
}
