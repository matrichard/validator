using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator
{
    using ValidationVisitor;

    using Validator.Validators;

    public static class Extensions
    {
        public static bool IsValid<T>(this IValidatable<T> entity)
        {
            var validator = ValidatorsTable.Get<T>();
            return entity.IsValid(validator);
        }
    }
}
