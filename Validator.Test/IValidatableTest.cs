using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Test
{
    using Validator.Validators;

    [TestClass]
    public class IValidatableTest
    {
        [TestCategory("IValidatable")]
        [TestMethod]
        public void WhenIsValidWithValidatorThenIsTrue()
        {
            // ARRANGE
            //reset valiators registration
            typeof(ValidatorsTable).TypeInitializer.Invoke(null, null);
            var entity = new Entity();
            
            // ACT
            var condition = entity.IsValid(new ValidatorBase<Entity>());

            // ASSERT
            Assert.IsTrue(condition);
        }
    }
}
