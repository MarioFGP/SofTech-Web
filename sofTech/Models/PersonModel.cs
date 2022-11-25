using Entity;

namespace sofTech.Models
{
    public class PersonInputModel
    {
        public string Id { get; set;}
        public string Name { get; set;}
        public string PhoneNumber { get; set;}
        public string Description {get; set; }
        public string Address { get; set;}
        public string Email { get; set;}
        public string Type { get; set;}
        public string State { get; set;}
        public decimal Salary { get; set;}
    }

    public class PersonViewModel: PersonInputModel
    {
        
        public PersonViewModel(){

        }

        public PersonViewModel(Person person){
            Id = person.ID_;
            Name = person.Name_;
            Description = person.Description_;
            PhoneNumber = person.PhoneNumber_;
            Email = person.Email_;
            Address = person.Address_;
            Type = person.Type_;
            State = person.State_;
            Salary = person.Salary_;
        }
    }
}