﻿using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using Validator;
    using Validator.Rules;
    using Validator.Test;

    [TestClass]
    public class RulesTests
    {
        [TestCategory("Rule")]
        [TestMethod]
        public void RuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new Rule<Entity2>(e => e.StringProperty2 != "some string");
            var entity = new Entity2{StringProperty2 = "value"};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Rule")]
        [TestMethod]
        public void RuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new Rule<Entity>(e => e.StringProperty != "some string");
            var entity = new Entity { StringProperty = "some string" };

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }

        [TestCategory("Required Instance")]
        [TestMethod]
        public void RequiredInstanceRuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new RequiredInstanceRule<Entity, object>(e => e.ObjectProperty);
            var entity = new Entity { ObjectProperty = new object()};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Required Instance")]
        [TestMethod]
        public void RequiredInstanceRuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new RequiredInstanceRule<Entity, object>(e => e.ObjectProperty);
            var entity = new Entity();

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }

        [TestCategory("Required String")]
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

        [TestCategory("Required String")]
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

        [TestCategory("Required int")]
        [TestMethod]
        public void RequiredIntRuleIsValid_ShouldBeTrue()
        {
            // ARRANGE
            var rule = new RequiredIntRule<Entity>(e => e.IntProperty);
            var entity = new Entity{IntProperty = 1};

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsTrue(condition);
        }

        [TestCategory("Required int")]
        [TestMethod]
        public void RequiredIntRuleIsValid_ShouldBeFalse()
        {
            // ARRANGE
            var rule = new RequiredIntRule<Entity>(e => e.IntProperty);
            var entity = new Entity();

            // ACT
            var condition = rule.IsValid(entity);

            // ASSERT
            Assert.IsFalse(condition);
        }

    }
}
