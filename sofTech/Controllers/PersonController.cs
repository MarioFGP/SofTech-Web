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

    public class PersonController:ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(){
            personService = new PersonService();

        }

        [HttpGet]
        public IEnumerable<PersonViewModel> Gets(){

            var People = personService.FindAll().Objects.Select(p => new PersonViewModel((Person)p));
            return People;

        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> GetByID(string id){
            var person = personService.FindPersonByID(id).Object;
            if(person==null) return NotFound();

            return new PersonViewModel((Person)person);

        }

        [HttpGet("{name}")]
        public ActionResult<PersonViewModel> GetByName(string name){
            var person = personService.FindPersonByID(name).Object;
            if(person==null) return NotFound();

            return new PersonViewModel((Person)person);

        }


        [HttpPost]
        public ActionResult<PersonViewModel> Post(PersonInputModel personInputModel){
            var person = MapPerson(personInputModel);
            var response = personService.SavePerson(person);
            if(response.Error){
                return BadRequest(response.Message);
            }
            return Ok((Person)response.Object);
        }

        [HttpPut]
        public ActionResult<Person> UpdatePerson(PersonInputModel personInputModel){
            var person = MapPerson(personInputModel);
            var response = personService.UpdatePerson(person);
            if(response.Error){
                return BadRequest(response.Message);
            }
            return Ok(person);
        }


        public Person MapPerson(PersonInputModel personInputModel){

            Person person = new Person();
            person.ID_ = personInputModel.Id;
            person.Name_ = personInputModel.Name;
            person.PhoneNumber_ = personInputModel.PhoneNumber;
            person.Salary_ = personInputModel.Salary;
            person.Address_ = personInputModel.Address;
            person.Description_ = personInputModel.Description;
            person.Email_ = personInputModel.Email;
            person.Type_ = personInputModel.Type;
            person.State_ = personInputModel.State;

            return person;
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string identificacion){

            Person person = (Person)personService.FindPersonByID(identificacion).Object;
            if(person==null){
                return BadRequest("No existe la persona");
            }
            person.State_ = "Inactivo";
            return Ok(personService.UpdatePerson(person).Message);
        }

    }
    
}