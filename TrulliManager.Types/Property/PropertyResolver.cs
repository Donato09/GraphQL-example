using HotChocolate;
using HotChocolate.Resolvers;
using System.Linq;
using TrulliManager.Repository.Abstract;
using modelsdb = TrulliManager.Database.Models;

namespace TrulliManager.Types.Property
{
    public class PropertyResolver
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyResolver([Service]IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public modelsdb.Property GetProperty(modelsdb.Trullo trullo, IResolverContext ctx)
        {
            return _propertyRepository.GetAll().Where(a => a.Id == trullo.PropertyId).FirstOrDefault();
        }
    }
}
