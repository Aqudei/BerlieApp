using AutoMapper;
using BerlieApp.Events;
using BerlieApp.Model;
using BerlieApp.Persistence;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BerlieApp.ViewModels
{
    class AddEditEmployeeViewModel : Screen
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthday;
        private string _sex;
        private string _placeOfBirth;
        private string _presentAddress;
        private int _id;
        private readonly IEventAggregator _eventAggregator;

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName.FirstOrDefault()}.";
            }
        }

        public string[] Sexes { get; set; } = { "Male", "Female" };

        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, value); }
        public string LastName { get => _lastName; set => Set(ref _lastName, value); }
        public DateTime Birthday { get => _birthday; set => Set(ref _birthday, value); }
        public string Sex { get => _sex; set => Set(ref _sex, value); }
        public string PlaceOfBirth { get => _placeOfBirth; set => Set(ref _placeOfBirth, value); }
        public string PresentAddress { get => _presentAddress; set => Set(ref _presentAddress, value); }
        public int Id { get => _id; set => Set(ref _id, value); }

        public AddEditEmployeeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Cancel()
        {
            var mbRslt = MessageBox.Show("Cancel adding/editing employee record?", "Confirm action", MessageBoxButton.YesNo);
            if (mbRslt == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public async Task Save()
        {
            var employee = Mapper.Map<Employee>(this);
            if (employee.Id == 0)
            {
                using (var db = new BerlieContext())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    await _eventAggregator.PublishOnCurrentThreadAsync(new CrudEvent<Employee>(employee, CrudEvent<Employee>.CrudEventType.Create));
                }
            }
            else
            {
                using (var db = new BerlieContext())
                {
                    var emp = db.Set<Employee>().Attach(employee);
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    await _eventAggregator.PublishOnCurrentThreadAsync(new CrudEvent<Employee>(employee, CrudEvent<Employee>.CrudEventType.Modify));
                }
            }
        }

      
    }
}
