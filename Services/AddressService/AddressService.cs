using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Services.AddressService
{
    public class AddressService : IAddressService
    {
        /// <summary>
        /// fields
        /// </summary>
        private readonly IRepository<Address> _addressRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="addressRepository"></param>
        public AddressService(IRepository<Address> addressRepository)
        {
            this._addressRepository = addressRepository;
        }

        /// <summary>
        /// Deletes a address
        /// </summary>
        /// <param name="address">Address</param>
        public void DeleteAddress(Address address)
        {
            _addressRepository.Delete(address);
        }

        /// <summary>
        /// Updates a address
        /// </summary>
        /// <param name="address"></param>
        public void UpdateAddress(Address address)
        {
            _addressRepository.Update(address);
        }

        /// <summary>
        /// Get all addresses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetAddresses()
        {
            return _addressRepository.GetAllNoTracking;
        }

        /// <summary>
        /// Get address by address identifier
        /// </summary>
        /// <param name="addressid">AddressId</param>
        /// <returns></returns>
        public Address GetAddressById(int id)
        {
            return _addressRepository.GetById(id);
        }

        /// <summary>
        /// Insert a address
        /// </summary>
        /// <param name="model"></param>
        public void Insert(Address model)
        {
            _addressRepository.Insert(model);
        }
    }
}
