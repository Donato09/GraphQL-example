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

        public Mutation(ITrulloRepository trulloRepository)
        {
            _trulloRepository = trulloRepository;
        }

        public Trullo CreateTrullo(Trullo trullo)
        {
            return _trulloRepository.Create(trullo);
        }

        public Trullo DeleteTrullo(Trullo trullo)
        {
            return _trulloRepository.Delete(trullo);
        }
    }
}
