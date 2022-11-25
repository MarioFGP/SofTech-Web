using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonService
    {
        private readonly DataContext _context;



        public PersonService()
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }

        public ObjectResponse SavePerson(Person person)
        {

            try
            {
                var _person = _context.Person.Find(person.ID_);

                if (_person != null)
                {
                    return new ObjectResponse("No se pudo guardar. La persona ya está registrada.");
                }
                else
                {
                    _context.Person.Add(person);
                    _context.SaveChanges();
                    return new ObjectResponse(person);
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo guardar. " + e.Message);
            }
        }

        public ObjectResponse FindPersonByID(string ID)
        {

            try
            {
                var person = _context.Person.Find(ID);
                if (person != null)
                {
                    return new ObjectResponse(person);
                }
                else
                {
                    return new ObjectResponse("No se encuentra a la persona.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error en la conexion. " + e.Message);
            }

        }

        public ObjectResponse FindPersonaByName(string name)
        {

            try
            {
                var persona = _context.Person.Where(p => p.Name_.ToLower().Equals(name.ToLower())).FirstOrDefault();
                if (persona != null)
                {
                    return new ObjectResponse(persona);
                }
                else
                {
                    return new ObjectResponse("No se encuentra a la persona.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error en la conexion. " + e.Message);
            }

        }

        public ObjectResponse FindAll()
        {
            try
            {
                var Personas = _context.Person.ToList();
                if (Personas != null)
                {
                    return new ObjectResponse(Personas);
                }
                else
                {
                    return new ObjectResponse("No hay registros de personas.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se puedo establecer la conexion. " + e.Message);
            }
        }

        public ObjectResponse UpdatePerson(Person person)
        {
            try
            {
                var _person = _context.Person.Find(person.ID_);
                if (_person != null)
                {
                    _person.Email_ = person.Email_;
                    _person.Description_ = person.Description_;
                    _person.Name_ = person.Name_;
                    _person.PhoneNumber_ = person.PhoneNumber_;
                    _person.State_ = person.State_;
                    _person.Type_ = person.Type_;
                    _context.Person.Update(_person);
                    _context.SaveChanges();
                    return new ObjectResponse(person);
                }
                else
                {
                    return new ObjectResponse("La persona no se encuentra registrada.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("Error en la conexion" + e.Message);
            }
        }
    }
}
