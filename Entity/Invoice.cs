using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        
        [Key]
        [Column(TypeName = "varchar(20)")]
        private int InvoiceNumber;
        [Column(TypeName = "varchar(10)")]
        private string EmployeeID="";
        [Column(TypeName = "varchar(50)")]
        private string EmployeeName="";
        [NotMapped]
        private Person Employee;
        [Column(TypeName = "DateTime")]
        private DateTime InvoiceDate;
        [Column(TypeName = "varchar(20)")]
        private string Concept="";
        [Column(TypeName = "decimal")]
        private decimal Total;
        [NotMapped]
        private List<Detail> Details;

        public Invoice()
        {
            Employee = new Person();
            Details = new List<Detail>();
        }

        public Invoice(int invoiceNumber, string employeeID, string employeeName, Person employee, DateTime invoiceDate, string concept, decimal total, List<Detail> details)
        {
            InvoiceNumber = invoiceNumber;
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            Employee = employee;
            InvoiceDate = invoiceDate;
            Concept = concept;
            Total = total;
            Details = details;
        }

        public int InvoiceNumber_ { get => InvoiceNumber; set => InvoiceNumber = value; }
        public string EmployeeID_ { get => EmployeeID; set => EmployeeID = value; }
        public string EmployeeName_ { get => EmployeeName; set => EmployeeName = value; }
        public Person Employee_ { get => Employee; set => Employee = value; }
        public DateTime InvoiceDate_ { get => InvoiceDate; set => InvoiceDate = value; }
        public string Concept_ { get => Concept; set => Concept = value; }
        public decimal Total_ { get => Total; set => Total = value; }
        public List<Detail> Details_ { get => Details; set => Details = value; }

        public decimal InvoiceTotal()
        {
            if (Details!=null)
            {
                if (Concept.Equals("Selling"))
                {
                    foreach (Detail detail in Details)
                    {
                        this.Total += detail.TotalSale();
                    }
                }
                else
                {
                    if (Concept.Equals("Purchase"))
                    {
                        foreach (Detail detail in Details)
                        {
                            this.Total += detail.TotalPurchase();
                        }
                    }
                }
            }

            return Total;
        }
    }
}
