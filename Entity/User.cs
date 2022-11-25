using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        private string IDUser="";
        [Column(TypeName = "varchar(20)")]
        private string Password="";
        [Column(TypeName = "varchar(15)")]
        private string Name="";
        [Column(TypeName = "varchar(10)")]
        private string State = "";

        public User()
        {
        }

        public User(string iDUser, string password, string name, string estate)
        {
            IDUser = iDUser;
            Password = password;
            Name = name;
            State = estate;
        }

        public string IDUser_ { get => IDUser; set => IDUser = value; }
        public string Password_ { get => Password; set => Password = value; }
        public string Name_ { get => Name; set => Name = value; }
        public string State_ { get => State; set => State = value; }
    }
}