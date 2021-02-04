﻿using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using TrulliManager.Types.Property;
using TrulliManager.Types.Trullo;

namespace TrulliManager
{
    public class Query
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ITrulloRepository _trulloRepository;

        public Query(IPropertyRepository propertyRepository, ITrulloRepository trulloRepository)
        {
            _propertyRepository = propertyRepository;
            _trulloRepository = trulloRepository;
        }

        public IQueryable<Property> Properties => _propertyRepository.GetAll();

        public IQueryable<Trullo> Trulli => _trulloRepository.GetAll();
    }
}
