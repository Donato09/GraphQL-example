using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface IPropertyRepository
    {
        IQueryable<Property> GetAll();
        Property GetById(int id);
        Property Create(Property property);
    }
}
