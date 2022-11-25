using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        private string ID="";
        [Column(TypeName = "varchar(50)")]
        private string Name="";
        [Column(TypeName = "varchar(10)")]
        private string PhoneNumber="";
        [Column(TypeName = "varchar(50)")]
        private string Address="";
        [Column(TypeName = "varchar(40)")]
        private string Email="";
        [Column(TypeName = "varchar(50)")]
        private string Description="";
        [Column(TypeName = "varchar(10)")]
        private string Type="";
        [Column(TypeName = "varchar(10)")]
        private string State="";
        [Column(TypeName = "decimal")]
        private decimal Salary;

        public string ID_ { get => ID; set => ID = value; }
        public string Name_ { get => Name; set => Name = value; }
        public string PhoneNumber_ { get => PhoneNumber; set => PhoneNumber = value; }
        public string Address_ { get => Address; set => Address = value; }
        public string Email_ { get => Email; set => Email = value; }
        public string Description_ { get => Description; set => Description = value; }
        public string Type_ { get => Type; set => Type = value; }
        public string State_ { get => State; set => State = value; }
        public decimal Salary_ { get => Salary; set => Salary = value; }

        public Person(string iD, string name, string phoneNumber, string address, string email, string descriptiion, string type, string state, decimal salary)
        {
            ID = iD;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Description = descriptiion;
            Type = type;
            State = state;
            Salary = salary;
        }

        public Person()
        {
        }


    }
}
