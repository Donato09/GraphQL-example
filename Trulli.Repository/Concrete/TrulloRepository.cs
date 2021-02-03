using System.Collections.Generic;
using System.Linq;
using TrulliManager.Database;
using TrulliManager.Database.CustomException;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager.Repository.Concrete
{
    public class TrulloRepository : ITrulloRepository
    {
        private readonly TrulliContext _db;

        public TrulloRepository(TrulliContext db)
        {
            _db = db;
        }

        public IEnumerable<Trullo> GetAll()
        {
            return _db.Trulli;
        }

        public IEnumerable<Trullo> GetAllForProperty(int propertyId)
        {
            return _db.Trulli.Where(x => x.PropertyId == propertyId);
        }

        public IEnumerable<Trullo> GetAllForProperty(int propertyId, int capacity)
        {
            return _db.Trulli.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x => x.Capacity)
                .Take(capacity);
        }

        public Trullo Delete(Trullo trullo)
        {
            var trulloToDelete = GetAllForProperty(trullo.Id).FirstOrDefault();
            if (trulloToDelete == null)
                throw new TrulloNotFound() { TrulloId = trullo.Id };
            
            _db.Remove(trulloToDelete);
            _db.SaveChanges();

            return trulloToDelete;
        }

        public Trullo Create(Trullo trullo)
        {
            _db.Add(trullo);
            _db.SaveChanges();

            return trullo;
        }
    }
}
