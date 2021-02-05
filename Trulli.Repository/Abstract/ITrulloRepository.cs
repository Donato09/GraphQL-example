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
        Trullo Delete(Trullo trullo);
        Trullo Create(Trullo trullo);
    }
}
