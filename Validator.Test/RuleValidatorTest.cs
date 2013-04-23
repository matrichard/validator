using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Test
{
    using Validator.Base;
    using Validator.Rules;
    using Validator.Validators;

    [TestClass]
    public class RuleValidatorTest
    {
        [TestCategory("ValidatorBase")]
        [TestMethod]
        public void WhenValidateWithNoRulesThanShouldBeTrue()
        {
            //ARRANGE
            var validator = new ValidatorBase<Entity>();
            var e = new Entity();

            //ACT
            var condition = validator.Validate(e);

            //ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("ValidatorBase")]
        [TestMethod]
        public void WhenValidateWithOneRuleInConstructorThanShouldBeTrue()
        {
            //ARRANGE
            var rule = new Rule<Entity>(x => x.StringProperty != "some value");
            var validator = new ValidatorBase<Entity>(rule);
            var e = new Entity();

            //ACT
            var condition = validator.Validate(e);

            //ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("ValidatorBase")]
        [TestMethod]
        public void WhenValidateWithRuleCollectionInConstructorThanShouldBeTrue()
        {
            //ARRANGE
            var rules = new[]
                {
                    new Rule<Entity>(x => x.StringProperty != "some value"), 
                    new Rule<Entity>(x => x.IntProperty < 1)
                };
            var validator = new ValidatorBase<Entity>(rules);
            var e = new Entity();

            //ACT
            var condition = validator.Validate(e);

            //ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("ValidatorBase")]
        [TestMethod]
        public void WhenValidateWithRegisteredRuleThanShouldBeTrue()
        {
            //ARRANGE
            var rule = new Rule<Entity>(x => x.StringProperty != "some value");
            var validator = new ValidatorBase<Entity>();
            var e = new Entity();

            //ACT
            validator.RegisterRule(rule);
            var condition = validator.Validate(e);

            //ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("ValidatorBase")]
        [TestMethod]
        public void WhenValidateWithRegisteredRuleCollectionThanShouldBeTrue()
        {
            //ARRANGE
            var rules = new IRuleBase<Entity>[]
                {
                    new Rule<Entity>(x => x.StringProperty != "some value"), 
                    new Rule<Entity>(x => x.IntProperty < 1),
                    new RequiredStringRule<Entity>(x => x.StringProperty)
                };
            var validator = new ValidatorBase<Entity>();
            var e = new Entity { StringProperty = "some prop" };
            validator.RegisterRules(rules);

            //ACT
            var condition = validator.Validate(e);

            //ASSERT
            Assert.IsTrue(condition);
        }  
    }
}
