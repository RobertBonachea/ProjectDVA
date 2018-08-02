using Domain.Entities;
using System.Collections.Generic;

namespace Services.PersonService
{
    /// <summary>
    /// Person service interface
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Deletes a Person
        /// </summary>
        /// <param name="person"></param>
        void DeletePerson(Person person);

        /// <summary>
        /// Deletes a Person by identifier
        /// </summary>
        /// <param name="personid">personid</param>
        void DeletePerson(int personid);

        /// <summary>
        /// Gets all Person objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetPeople();

        /// <summary>
        /// Gets person by the person identifer
        /// </summary>
        /// <param name="personid">PersonId</param>
        /// <returns></returns>
        Person GetPersonById(int id);

        /// <summary>
        /// Inserts a person
        /// </summary>
        /// <param name="model"></param>
        void Insert(Person model);

        /// <summary>
        /// Updates a person
        /// </summary>
        /// <param name="person"></param>
        void UpdatePerson(Person person);
    }
}
