using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity
{
    public class Detail
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        private int Code;
        [Column(TypeName = "number")]
        private int InvoiceNumber;
        [NotMapped]
        private Article Article;
        [Column(TypeName = "varchar(20)")]
        private string ArticleReference="";
        [Column(TypeName = "number")]
        private int Amount;
        [Column(TypeName = "decimal")]
        private decimal UnitPrice;
        [Column(TypeName = "decimal")]
        private decimal Total;


        public Detail()
        {
            Article = new Article();
        }

        public Detail(int code, int invoiceNumber, Article article, string articleReference, int amount, decimal unitPrice, decimal total)
        {
            this.Code = code;
            InvoiceNumber = invoiceNumber;
            Article = article;
            ArticleReference = articleReference;
            Amount = amount;
            UnitPrice = unitPrice;
            Total = total;
        }

        public int Code_ { get => Code; set => Code = value; }
        public int InvoiceNumber_ { get => InvoiceNumber; set => InvoiceNumber = value; }
        public Article Article_ { get => Article; set => Article = value; }
        public string ArticleReference_ { get => ArticleReference; set => ArticleReference = value; }
        public int Amount_ { get => Amount; set => Amount = value; }
        public decimal UnitPrice_ { get => UnitPrice; set => UnitPrice = value; }
        public decimal Total_ { get => Total; set => Total = value; }

        public decimal TotalPurchase()
        {

            return Total = Article.PurchasePrice_ * this.Amount;
        }

        public decimal TotalSale()
        {
            return Total = Article.SalePrice_ * this.Amount;
        }
    }
}
