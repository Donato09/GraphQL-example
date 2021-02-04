using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Types.Property;
using TrulliManager.Types.Trullo;

namespace TrulliManager
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(f => f.Properties)
                .Type<PropertyType>();
            descriptor
                .Field(f => f.Trulli)
                .Type<TrulloType>();
        }
    }
}
