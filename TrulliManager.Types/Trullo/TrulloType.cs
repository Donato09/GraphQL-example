using HotChocolate.Types;
using TrulliManager.Types.Property;

namespace TrulliManager.Types.Trullo
{
    public class TrulloType : ObjectType<Database.Models.Trullo>
    {
        protected override void Configure(IObjectTypeDescriptor<Database.Models.Trullo> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Name).Type<StringType>();
            descriptor.Field(b => b.Description).Type<StringType>();
            descriptor.Field(b => b.Price).Type<DecimalType>();
            descriptor.Field<PropertyResolver>(t => t.GetProperty(default, default));
        }
    }
}
