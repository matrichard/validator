using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator
{
    using System.Linq.Expressions;

    public abstract class RuleBase<T,TProp>
    {
        protected Expression<Func<T, TProp>> projection;

        protected RuleBase(Expression<Func<T, TProp>> p)
        {
            projection = p;
        }

        public bool IsValid(T entity)
        {
            return Validate(projection.Compile()(entity));
        }

        protected abstract bool Validate(TProp value);
    }
    
    public class Rule<T, TProp> : RuleBase<T, TProp>
    {
        protected Func<TProp, bool> rule;

        public Rule(Expression<Func<T, TProp>> p, Func<TProp, bool> r)
            : base(p)
        {
            rule = r;
        }

        protected override bool Validate(TProp value)
        {
            return rule(value);
        }
    }

    public class RequiredRule<T, TValue> :RuleBase<T, TValue>
        where TValue : class 
    {
        public RequiredRule(Expression<Func<T, TValue>> p)
            : base(p)
        {
        }

        protected override bool Validate(TValue value)
        {
            return value != null;
        }
    }

    public class RequiredStringRule<T>: RuleBase<T,string>
    {
        public RequiredStringRule(Expression<Func<T, string>> p)
            : base(p)
        {
        }

        protected override bool Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
