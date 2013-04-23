using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Test
{
    using Validator.Validators;

    [TestClass]
    public class ValidatorsTableTest
    {
        [TestCategory("Validators")]
        [TestMethod]
        public void WhenAddValidatorThenShouldSucceed()
        {
            // ARRANGE
            var validator = new ValidatorBase<Entity>();

            // ACT
            ValidatorsTable.Add(validator);

            // ASSERT
            Assert.IsTrue(true);
        }

        [TestCategory("Validators")]
        [TestMethod]
        public void WhenGetValidatorFromTypeThenShouldNotBeNull()
        {
            //ARRANGE
            ValidatorsTable.Add(new ValidatorBase<Entity>());
            ValidatorsTable.Add(new ValidatorBase<Entity2>());

            //ACT
            var v = ValidatorsTable.Get<Entity>();
            var v2 = ValidatorsTable.Get<Entity2>();

            //ASSERT
            Assert.IsNotNull(v);
            Assert.IsNotNull(v2);
        } 
  
    }
}
