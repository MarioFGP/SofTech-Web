
using Entity;

namespace sofTech.Models
{
    public class DetailInputModel
    {
        public int Code {get; set;}
        public int InvoiceNumber {get; set;}
        public Article Article {get; set;} = new Article();
        public string ArticleReference {get; set;}
        public int Amount {get; set;}
        public decimal UnitPrice {get; set;}
        public decimal Total;

    }

    public class DetailViewModel:DetailInputModel{

        public DetailViewModel(){

        }

        public DetailViewModel(Detail detail){

            Code = detail.Code_;
            InvoiceNumber = detail.InvoiceNumber_;
            Article = detail.Article_;
            ArticleReference = detail.ArticleReference_;
            Amount = detail.Amount_;
            UnitPrice = detail.UnitPrice_;
            Total = detail.Total_;

        }
    }
}