using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

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

        public Trullo CreateTrullo(Trullo trullo)
        {
            return _trulloRepository.Create(trullo);
        }

        public Trullo DeleteTrullo(Trullo trullo)
        {
            return _trulloRepository.Delete(trullo);
        }

        public Property CreateProperty(Property property)
        {
            return _propertyRepository.Create(property);
        }
    }
}
