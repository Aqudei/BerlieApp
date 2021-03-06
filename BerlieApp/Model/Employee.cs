﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.Model
{
    class Employee : EntityBase
    {
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName.FirstOrDefault()}.";
            }
        }

       
        public string FirstName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime Birthday { get; internal set; }
        public string Sex { get; internal set; }
        public string PlaceOfBirth { get; internal set; }
        public string PresentAddress { get; internal set; }

        public override string EntityCode => "EMP";

        public override string ToString()
        {
            return FullName;
        }
    }
}
