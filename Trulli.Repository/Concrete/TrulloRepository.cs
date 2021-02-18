using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<Trullo> GetAll()
        {
            return _db.Trulli.Include(p => p.Property);
        }

        public Trullo GetTrulloById(int id)
        {
            var trullo = _db.Trulli
                .Include(p => p.Property)
                .Where(t => t.Id == id)
                .FirstOrDefault();
            
            return trullo;
        }

        public Trullo Delete(Trullo trullo)
        {
            var trulloToDelete = GetAll().FirstOrDefault(t => t.Id == trullo.Id);
            if (trulloToDelete == null)
                throw new TrulloNotFound() { TrulloId = trullo.Id };
            
            _db.Remove(trulloToDelete);
            _db.SaveChanges();

            return trulloToDelete;
        }

        public async Task<Trullo> Create(Trullo trullo)
        {
           await _db.AddAsync(trullo);
           await _db.SaveChangesAsync();

            return trullo;
        }
    }
}
