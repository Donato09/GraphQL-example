using System;
using System.Collections.Generic;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetById(int id);
        Property Add(Property property);
    }
}
