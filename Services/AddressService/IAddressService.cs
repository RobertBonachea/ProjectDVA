using Domain.Entities;
using System.Collections.Generic;

namespace Services.AddressService
{
    /// <summary>
    /// Address service interface
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Deletes a Address
        /// </summary>
        /// <param name="address"></param>
        void DeleteAddress(Address address);

        /// <summary>
        /// Gets all Address objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<Address> GetAddresses();

        /// <summary>
        /// Gets address by the address identifer
        /// </summary>
        /// <param name="addressid">AddressId</param>
        /// <returns></returns>
        Address GetAddressById(int id);

        /// <summary>
        /// Inserts a Address
        /// </summary>
        /// <param name="model"></param>
        void Insert(Address model);

        /// <summary>
        /// Updates a Address
        /// </summary>
        /// <param name="address"></param>
        void UpdateAddress(Address address);
    }
}
