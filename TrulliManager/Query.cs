using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Trullo> GetTrulloById([Service] ITrulloRepository trulloRepository, [Service]ITopicEventSender eventSender, int id)
        {
            Trullo trulloResult = trulloRepository.GetTrulloById(id);
            await eventSender.SendAsync("ReturnedTrullo", trulloResult);

            return trulloResult;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Trullo> Trulli => _trulloRepository.GetAll();
    }
}
