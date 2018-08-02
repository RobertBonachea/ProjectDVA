using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        /// <summary>
        /// fields
        /// </summary>
        private readonly IRepository<Person> _personRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="personRepository"></param>
        public PersonService(IRepository<Person> personRepository)
        {
            this._personRepository = personRepository;
        }

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="person">Person</param>
        public void DeletePerson(Person person)
        {
            this._personRepository.Delete(person);
        }

        /// <summary>
        /// Deletes a person by identifier
        /// </summary>
        /// <param name="id">PersonId</param>
        public void DeletePerson(int personId)
        {
            this._personRepository.Delete(personId);
        }

        /// <summary>
        /// Updates a person
        /// </summary>
        /// <param name="person"></param>
        public void UpdatePerson(Person person)
        {
            this._personRepository.Update(person);
        }

        /// <summary>
        /// Get all people
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPeople()
        {
            return this._personRepository.GetAllNoTracking;
        }

        /// <summary>
        /// Get person by person identifier
        /// </summary>
        /// <param name="personid">PersonId</param>
        /// <returns></returns>
        public Person GetPersonById(int id)
        {
            return this._personRepository.GetById(id);
        }

        /// <summary>
        /// Insert a person
        /// </summary>
        /// <param name="model"></param>
        public void Insert(Person model)
        {
            this._personRepository.Insert(model);
        }
    }
}
