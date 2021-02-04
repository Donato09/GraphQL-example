using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface ITrulloRepository
    {
        IQueryable<Trullo> GetAll();
        //IEnumerable<Trullo> GetAllForProperty(int propertyId);
        //IEnumerable<Trullo> GetAllForProperty(int propertyId, int capacity);
        Trullo Delete(Trullo trullo);
        Trullo Create(Trullo trullo);
    }
}
