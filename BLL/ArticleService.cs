using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class ArticleService
    {
        private readonly DataContext _context;

        public ArticleService()
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }

        public ObjectResponse SaveArticle(Article article)
        {
            try
            {
                var _Article = _context.Article.Find(article.Reference_);
                if (_Article != null)
                {
                    return new ObjectResponse("El articulo ya existe.");
                }
                else
                {
                    _context.Article.Add(article);
                    _context.SaveChanges();
                    return new ObjectResponse(article);
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error de conexion. " + e.Message);
            }
        }

        public ObjectResponse FindArticleByReference(string reference)
        {
            try
            {
                var article = _context.Article.Find(reference);
                if (article != null)
                {
                    return new ObjectResponse(article);
                }
                else
                {
                    return new ObjectResponse("No existe el articulo.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error de conexion. " + e.Message);
            }
        }

        public ObjectResponse FindArticleByName(string Nombre)
        {
            try
            {
                var article = _context.Article.Where(p => p.Name_.Equals(Nombre)).FirstOrDefault();
                if (article != null)
                {
                    return new ObjectResponse(article);
                }
                else
                {
                    return new ObjectResponse("No existe el articulo.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error de conexion. " + e.Message);
            }
        }

        public ObjectResponse Articles()
        {
            try
            {
                var articles = _context.Article.ToList();
                if (articles != null)
                {
                    return new ObjectResponse(articles);
                }
                else
                {
                    return new ObjectResponse("No hay articulos.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error de conexion. " + e.Message);
            }
        }

        public ObjectResponse UpdateArticle(Article article)
        {
            try
            {
                var _article = _context.Article.Find(article.Reference_);
                if (_article != null)
                {
                    _article.Description_ = article.Description_;
                    _article.Availability_ = article.Availability_;
                    _article.PurchasePrice_ = article.PurchasePrice_;
                    _article.SalePrice_ = article.SalePrice_;
                    _article.Name_ = article.Name_;
                    _article.Amount_ = article.Amount_;
                    _context.Article.Update(_article);
                    _context.SaveChanges();
                    return new ObjectResponse(article);
                }
                else
                {
                    return new ObjectResponse("No existe el platillo");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error de conexion. " + e.Message);
            }
        }
    }
}
