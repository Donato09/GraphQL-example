using HotChocolate;
using HotChocolate.Resolvers;
using System;
using System.Collections.Generic;
using System.Text;
using TrulliManager.Repository.Abstract;
using modelsdb = TrulliManager.Database.Models;

namespace TrulliManager.Types.Trullo
{
    public class TrulloResolver
    {
        private readonly ITrulloRepository _trulloRepository;

        public TrulloResolver([Service]ITrulloRepository trulloRepository)
        {
            _trulloRepository = trulloRepository;
        }

        public IEnumerable<modelsdb.Trullo> GetTrullos(modelsdb.Property property, IResolverContext ctx )
        {
            return _trulloRepository.GetAllForProperty(property.Id);
        }
    }
}
