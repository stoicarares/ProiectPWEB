using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums
{
    [JsonConverter(typeof(SmartEnumNameConverter<ShippingMethod, string>))]
    public class ShippingMethod : SmartEnum<ShippingMethod, string>
    {
        public static readonly ShippingMethod Courier = new(nameof(Courier), "Courier");
        public static readonly ShippingMethod Easybox = new(nameof(Easybox), "Express");
        public static readonly ShippingMethod PersonalLift = new(nameof(PersonalLift), "PersonalLift");

        private ShippingMethod(string name, string value) : base(name, value)
        {
        }
    }
}
