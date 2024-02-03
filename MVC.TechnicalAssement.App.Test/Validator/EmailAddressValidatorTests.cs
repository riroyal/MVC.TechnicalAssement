using Logic.TechnicalAssement.App.Validator;

namespace Logic.TechnicalAssement.App.Test.Validator
{
    [TestFixture]
    public class EmailAddressValidatorTests
    {
        [Test]
        public void IsEmailValid_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var validator = new EmailAddressValidator();
            var validEmail = "test@acme.com";

            // Act
            var result = validator.IsValidFormat(validEmail);

            // Assert
            Assert.That(result, Is.True);
        }

        [TestCase("test")]
        [TestCase("acme@com")]
        [TestCase("test@.com")]
        public void IsEmailValid_InvalidEmail_ReturnsFalse(string invalidEmail)
        {
            // Arrange
            var validator = new EmailAddressValidator();

            // Act
            var result = validator.IsValidFormat(invalidEmail);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
