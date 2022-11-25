using Entity;

namespace sofTech.Models
{
    public class UserInputModel
    {
        public string IDUser {get; set;}
        public string Password {get; set;}
        public string Name {get; set;}
        public string State {get; set;}

    }

    public class UserViewModel:UserInputModel{

        public UserViewModel(){

        }


        public UserViewModel(User user){

            IDUser = user.IDUser_;
            Password = user.Password_;
            Name = user.Name_;
            State = user.State_;
        }
    }
}