using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager
{
    public class Query
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ITrulloRepository _trulloRepository;

        public Query(IPropertyRepository propertyRepository, ITrulloRepository trulloRepository)
        {
            _propertyRepository = propertyRepository;
            _trulloRepository = trulloRepository;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Property> Properties => _propertyRepository.GetAll();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Trullo> Trulli => _trulloRepository.GetAll();
    }
}
