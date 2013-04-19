using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestValidation;

namespace UnitTestProject1
{
    using Validator;

    [TestClass]
    public class RulesTests
    {
        [TestCategory("Rule")]
        [TestProperty("Value", "string")]
        [TestMethod]
        public void RuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new Rule<Entity2,string>(e => e.StringProperty2, v => v != "some string");
            var entity = new Entity2{StringProperty2 = "value"};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Rule")]
        [TestProperty("Value", "string")]
        [TestMethod]
        public void RuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new Rule<Entity, string>(e => e.StringProperty, v => v != "some string");
            var entity = new Entity { StringProperty = "some string" };

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }

        [TestCategory("Required")]
        [TestProperty("Value", "object")]
        [TestMethod]
        public void RequiredRuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new RequiredRule<Entity, object>(e => e.ObjectProperty);
            var entity = new Entity { ObjectProperty = new object()};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Required")]
        [TestProperty("Value", "object")]
        [TestMethod]
        public void RequiredRuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new RequiredRule<Entity, object>(e => e.ObjectProperty);
            var entity = new Entity();

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }

        [TestCategory("RequiredString")]
        [TestProperty("Value", "string")]
        [TestMethod]
        public void RequiredStringRuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new RequiredStringRule<Entity>(e => e.StringProperty);
            var entity = new Entity{StringProperty = "value"};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Required")]
        [TestProperty("Value", "string")]
        [TestMethod]
        public void RequiredStringRuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new RequiredStringRule<Entity>(e => e.StringProperty);
            var entity = new Entity();

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }
/*
        [TestCategory("Required")]
        [TestProperty("Value", "int")]
        [TestMethod]
        public void RequiredIntRuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new RequiredRule<int>(e => e.IntProperty);
            var entity = new Entity{IntProperty = 1};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Required")]
        [TestProperty("Value", "int")]
        [TestMethod]
        public void RequiredIntRuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new RequiredRule<int>(e => e.IntProperty);
            var entity = new Entity();

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }
*/
    }
}
