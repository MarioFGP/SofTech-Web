using Entity;

namespace sofTech.Models
{
    public class InvoiceInputModel
    {
        public int InvoiceNumber {get; set;}
        public string EmployeeID {get; set;}
        public string EmployeeName {get; set;}
        public Person Employee {get; set;} = new Person();
        public DateTime InvoiceDate {get; set;}
        public string Concept {get; set;}
        public decimal Total {get; set;}
        public List<Detail> Details {get; set;} = new List<Detail>();


    }

    public class InvoiceViewModel: InvoiceInputModel{

        public InvoiceViewModel(){

        }


        public InvoiceViewModel(Invoice invoice){
            InvoiceNumber = invoice.InvoiceNumber_;
            EmployeeID = invoice.EmployeeID_;
            EmployeeName = invoice.EmployeeName_;
            Employee = invoice.Employee_;
            InvoiceDate = invoice.InvoiceDate_;
            Concept = invoice.Concept_;
            Total = invoice.Total_;

        }
    }
}