using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetailService
    {
        private readonly DataContext _context;

        public DetailService()
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }

        public ObjectResponse GuardarDetalle(Detail detail)
        {
            try
            {
                var _detail = _context.Detail.Find(detail.Code_);

                if (_detail != null)
                {
                    return new ObjectResponse("Ya existe el detalle.");
                }
                else
                {
                    _context.Detail.Add(detail);
                    _context.SaveChanges();
                    return new ObjectResponse(detail);
                }

            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Hubo un problema al intentar guardar el detalle. " + e.Message);
            }
        }


        public ObjectResponse ConsultarDetalles()
        {
            try
            {
                var _detail = _context.Detail.ToList();

                if (_detail != null)
                {
                    return new ObjectResponse(_detail);
                }
                else
                {
                    return new ObjectResponse("No hay registros de detalle.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Problemas al intentar consultar. " + e.Message);
            }
        }
    }
}
