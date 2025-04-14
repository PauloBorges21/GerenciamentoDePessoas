using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciamentoDePessoas.Converters
{
    public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcDateTimeConverter() : base(
            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {

        }
    }
}
