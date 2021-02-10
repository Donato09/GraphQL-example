using HotChocolate.Types;
using TrulliManager.Types.Trullo;

namespace TrulliManager.Types.Property
{
    public class PropertyType : ObjectType<Database.Models.Property>
    {
        protected override void Configure(IObjectTypeDescriptor<Database.Models.Property> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.City).Type<StringType>();
            descriptor.Field(a => a.Street).Type<StringType>();
            descriptor.Field(a => a.Spa).Type<BooleanType>();
            descriptor.Field(a => a.SwimmingPool).Type<BooleanType>();
            descriptor.Field<TrulloResolver>(t => t.GetTrullos(default, default));
        }
    }
}
