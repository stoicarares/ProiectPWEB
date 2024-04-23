using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums
{
    [JsonConverter(typeof(SmartEnumNameConverter<PaymentMethod, string>))]
    public sealed class PaymentMethod : SmartEnum<PaymentMethod, string>
    {
        public static readonly PaymentMethod CreditCard = new(nameof(CreditCard), "Credit Card");
        public static readonly PaymentMethod DebitCard = new(nameof(DebitCard), "Debit Card");
        public static readonly PaymentMethod Cash = new(nameof(Cash), "Cash");
        public static readonly PaymentMethod PayPal = new(nameof(PayPal), "PayPal");

        private PaymentMethod(string name, string value) : base(name, value)
        {
        }
    }
}
