using DAL;
using Entity;

namespace BLL
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService()
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }


        public ObjectResponse SaveUser(User usuario)
        {

            try
            {
                var user = _context.User.Find(usuario.IDUser_);
                if (user != null)
                {
                    return new ObjectResponse("Ya existe el usuario");
                }
                else
                {
                    _context.User.Add(usuario);
                    _context.SaveChanges();
                    return new ObjectResponse(usuario);
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se puedo guardar el usuario" + e.Message);
            }

        }

        public ObjectResponse FindUserByID(string ID)
        {

            try
            {
                var user = _context.User.Find(ID);
                if (user != null)
                {
                    return new ObjectResponse(user);

                }
                else
                {
                    return new ObjectResponse("El usuario no existe");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo concretar la busqueda. " + e.Message);
            }
        }

        public ObjectResponse UpdateUser(User user)
        {
            try
            {
                var _usuario = _context.User.Find(user.IDUser_);
                if (_usuario != null)
                {
                    _usuario.Password_ = user.Password_;
                    _usuario.State_ = user.State_;
                    _usuario.Name_ = user.Name_;
                    _context.User.Update(user);
                    _context.SaveChanges();
                    return new ObjectResponse(_usuario);
                }
                else
                {
                    return new ObjectResponse("No existe el usuario.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo modificar el usuario. " + e.Message);
            }
        }

        public ObjectResponse FindUsers()
        {

            try
            {
                var usuarios = _context.User.ToList();
                if (usuarios != null)
                {
                    return new ObjectResponse(usuarios);

                }
                else
                {
                    return new ObjectResponse("No hay registro de usuarios");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo concretar la busqueda. " + e.Message);
            }
        }




    }


}