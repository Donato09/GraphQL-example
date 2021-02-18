using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using TrulliManager.ViewModel;

namespace TrulliManager
{
    public class Mutation
    {
        private readonly ITrulloRepository _trulloRepository;
        private readonly IPropertyRepository _propertyRepository;

        public Mutation(ITrulloRepository trulloRepository, IPropertyRepository propertyRepository)
        {
            _trulloRepository = trulloRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Trullo> CreateTrullo([Service]ITrulloRepository trulloRepository, [Service]ITopicEventSender eventSender, CreateTrulloInput trullo)
        {
            Trullo newTrullo = new Trullo
            {
                //Id = _trulloRepository.GetAll().Max(x => x.Id) + 1,
                Name = trullo.Name,
                Description = trullo.Description,
                Capacity = trullo.Capacity,
                Price = trullo.Price,
                PropertyId = trullo.PropertyId
            };

            var createdTrullo = await trulloRepository.Create(newTrullo);

            await eventSender.SendAsync("TrulloCreated", createdTrullo);

            return createdTrullo;
        }

        public Trullo DeleteTrullo(DeleteTrulloInput deletedTrullo)
        {
            Trullo oldTrullo = new Trullo
            {
                Id = deletedTrullo.Id
            };

            return _trulloRepository.Delete(oldTrullo);
        }

        public Property CreateProperty(CreatePropertyInput property)
        {
            Property newProperty = new Property
            {
                Id = _propertyRepository.GetAll().Max(x => x.Id) + 1,
                Name = property.Name,
                City = property.City,
                Street = property.Street,
                Spa = property.Spa,
                SwimmingPool = property.SwimmingPool
            };

            return _propertyRepository.Create(newProperty);
        }
    }
}
