using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator.Validators
{
    using ValidationVisitor;

    public class ValidatorsTable
    {
        private static readonly IDictionary<Type, object> registry;

        static ValidatorsTable()
        {
           registry = new Dictionary<Type, object>(); 
        }

        public static void Add<T>(ValidatorBase<T> validatorBase) 
            where T : IValidatable<T>
        {
            registry[typeof(T)] = validatorBase;
        }

        public static IValidator<T> Get<T>()
        {
            return (IValidator<T>)registry[typeof(T)];
        }
    }
}
