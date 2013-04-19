using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator
{
    using System.Linq.Expressions;

    public abstract class RuleBase<TEntity>
    {
        public abstract bool IsValid(TEntity entity);
    }

    public class Rule<TEntity> : RuleBase<TEntity>
    {
        protected Func<TEntity, bool> rule;

        public Rule(Func<TEntity, bool> r)
        {
            rule = r;
        }

        public override bool IsValid(TEntity entity)
        {
            return rule(entity);
        }
    }

    public abstract class RequiredRule<TEntity, TValue> : RuleBase<TEntity>
    {
        private readonly Expression<Func<TEntity, TValue>> projection;

        protected RequiredRule(Expression<Func<TEntity, TValue>> p)
        {
            projection = p;
        }

        public override bool IsValid(TEntity value)
        {
            return this.Validate(projection.Compile()(value));
        }

        protected abstract bool Validate(TValue value);

    }

    public class RequiredInstanceRule<TEntity, TInstance> : RequiredRule<TEntity, TInstance>
        where TInstance : class
    {
        public RequiredInstanceRule(Expression<Func<TEntity, TInstance>> p)
            : base(p)
        {
        }

        protected override bool Validate(TInstance value)
        {
            return value != null;
        }
    }

    public class RequiredStringRule<T> : RequiredRule<T, string>
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
