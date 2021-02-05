using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrulliManager.Database;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager.Repository.Concrete
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly TrulliContext _db;

        public PropertyRepository(TrulliContext db)
        {
            _db = db;
        }

        public IQueryable<Property> GetAll()
        {
            return _db.Properties.Include(t => t.Trulli);
        }

        public Property GetById(int id)
        {
            return _db.Properties.SingleOrDefault(x => x.Id == id);
        }

        public Property Create(Property property)
        {
            _db.Properties.Add(property);
            _db.SaveChanges();
            return property;
        }

    }
}
