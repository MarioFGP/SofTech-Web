using System.Linq;
using System.Collections.Generic;
using sofTech.Models;
using Entity;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sofTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticleController:ControllerBase
    {
        private readonly ArticleService articleService;

        public ArticleController(){
            articleService = new ArticleService();
        }

        [HttpGet]
        public IEnumerable<ArticleViewModel> Get(){
            var articles = articleService.Articles().Objects.Select(a => new ArticleViewModel((Article)a));
            return articles;
        }

        [HttpGet("{reference}")]
        public ActionResult<ArticleViewModel> GetByReference(string reference){
            var article = (Article)articleService.FindArticleByReference(reference).Object;
            if(article==null){
                return NotFound();
            }
            return new ArticleViewModel(article);
        }

        [HttpGet("{name}")]
        public ActionResult<ArticleViewModel> GetByName(string name){
            var article = (Article)articleService.FindArticleByName(name).Object;
            if(article==null){
                return NotFound();
            }
            return new ArticleViewModel(article);
        }

        [HttpDelete("{reference}")]
        public ActionResult<string> Delete(string reference){
            var response = articleService.FindArticleByReference(reference);
            if(response.Error){
                return BadRequest(response.Message);
            }
            var article = (Article) response.Object;
            return Ok(articleService.UpdateArticle(article).Message);
        }

        [HttpPost]
        public ActionResult<ArticleViewModel> Post(ArticleInputModel articleInputModel){
            var article = MapArticle(articleInputModel);
            var response = articleService.SaveArticle(article);
            if(response.Error){
                return BadRequest(response.Message);
            }
            return Ok(article);
        }

        public Article MapArticle(ArticleInputModel articleInputModel){
            Article article = new Article();
            article.Amount_= articleInputModel.Amount;
            article.Availability_ = articleInputModel.Availability;
            article.Description_ = articleInputModel.Description;
            article.Name_ = articleInputModel.Name;
            article.PurchasePrice_ = articleInputModel.PurchasePrice;
            article.Reference_ = articleInputModel.Reference;
            article.SalePrice_ = articleInputModel.SalePrice;

            return article;
        }
        
    }
}