using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Article
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        private string Reference="";
        [Column(TypeName = "varchar(30)")]
        private string Name="";
        [Column(TypeName = "varchar(50)")]
        private string Description = "";
        [Column(TypeName = "varchar(10)")]
        private string Availability = "";
        [Column(TypeName = "number")]
        private int Amount  = 0;
        [Column(TypeName = "decimal")]
        private decimal PurchasePrice=0;
        [Column(TypeName = "decimal")]
        private decimal SalePrice=0;

        public Article()
        {
        }

        public Article(string reference, string name, string description, int amount, decimal purchasePrice, decimal salePrice_)
        {
            Reference = reference;
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice_;
            Amount = amount;
            Availability = "Disponible"; 
        }

        public string Reference_ { get => Reference; set => Reference = value; }
        public string Name_ { get => Name; set => Name = value; }
        public string Description_ { get => Description; set => Description = value; }
        public int Amount_ { get => Amount; set => Amount = value; }
        public decimal PurchasePrice_ { get => PurchasePrice; set => PurchasePrice = value; }
        public decimal SalePrice_ { get => SalePrice; set => SalePrice = value; }
        public string Availability_ { get => Availability; set => Availability = value; }
    }
}
