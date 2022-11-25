using Entity;

namespace sofTech.Models
{
    public class ArticleInputModel
    {
        
        public string Reference {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string Availability {get; set;}
        public int Amount {get; set;}
        public decimal PurchasePrice {get; set;}
        public decimal SalePrice {get; set;}
        
    }

    public class ArticleViewModel: ArticleInputModel
    {
        public ArticleViewModel(){

        }

        public ArticleViewModel(Article article)
        {
            Reference = article.Reference_;
            Name = article.Name_;
            Amount = article.Amount_;
            Description = article.Description_;
            Availability = article.Availability_;
            PurchasePrice = article.PurchasePrice_;
            SalePrice = article.SalePrice_;
            
        }
    }
}