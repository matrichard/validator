namespace Validator.Validators
{
    using System.Collections.Generic;
    using System.Linq;

    using ValidationVisitor;

    using Validator.Base;
    using Validator.Rules;

    public class ValidatorBase<TEntity> : IValidator<TEntity>
        where TEntity : IValidatable<TEntity>
    {
        private readonly IList<IRuleBase<TEntity>> rules;

        public ValidatorBase()
            : this(new IRuleBase<TEntity>[] { })
        {
        }

        public ValidatorBase(Rule<TEntity> r)
            :this(new []{r})
        {
        }

        public ValidatorBase(IEnumerable<IRuleBase<TEntity>> collection)
        {
            this.rules = new List<IRuleBase<TEntity>>(collection);
        }

        public bool Validate(TEntity e)
        {
            return !this.rules.Any() || this.rules.All(r => r.IsValid(e));
        }

        public void RegisterRule(Rule<TEntity> rule)
        {
            this.rules.Add(rule);
        }

        public void RegisterRules(IEnumerable<IRuleBase<TEntity>> collection)
        {
            ((List<IRuleBase<TEntity>>)this.rules).AddRange(collection);
        }
    }
}