using AutoMapper;
using BerlieApp.Events;
using BerlieApp.Model;
using BerlieApp.Persistence;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BerlieApp.ViewModels
{
    class EmployeeListViewModel : Conductor<object>.Collection.OneActive, IHandle<Events.CrudEvent<Employee>>
    {
        private static DebugLog _logger = new DebugLog(typeof(EmployeeListViewModel));
        private Employee _selectedEmployee;
        private readonly IWindowManager _windowManager;

        private BindableCollection<Employee> _employees { get; set; }
        public ICollectionView Employees { get; set; }
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                Set(ref _selectedEmployee, value);
                NotifyOfPropertyChange(nameof(CanEditEmployee));
            }
        }
        public EmployeeListViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
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

            using (var db = new BerlieContext())
            {
                _employees.AddRange(db.Employees.ToList());
            }

            _windowManager = windowManager;
            eventAggregator.SubscribeOnPublishedThread(this);
        }

        public void ViewAttachments()
        {
            _logger.Info("Viewing attachment of : {0}", SelectedEmployee);
        }

        public void EditEmployee()
        {
            var vm = IoC.Get<AddEditEmployeeViewModel>();
            Mapper.Map(SelectedEmployee, vm);
            _windowManager.ShowDialog(vm);
        }

        public bool CanEditEmployee => SelectedEmployee != null;

        public Task HandleAsync(CrudEvent<Employee> message, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (message.Event == CrudEvent<Employee>.CrudEventType.Create)
                {
                    _employees.Add(message.Entity);
                }
            });
        }
    }
}
