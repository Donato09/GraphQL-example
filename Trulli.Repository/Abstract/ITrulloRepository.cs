using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface ITrulloRepository
    {
        IQueryable<Trullo> GetAll();
        Trullo Delete(Trullo trullo);
        Trullo GetTrulloById(int id);
        Task<Trullo> Create(Trullo trullo);
    }
}
