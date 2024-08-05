using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnsureNotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is IList list && list.Count > 0;
    }
}
