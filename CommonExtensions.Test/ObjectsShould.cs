using CommonExtensions.Test.Models;
using Shouldly;

namespace CommonExtensions.Test
{
    public class ObjectsShould
    {
        [Fact]
        public void IsNull()
        {
            // Arrange
            TestDog dog = new();
            TestDog? anotherDog = null;

            // Act
            bool notNullDog = dog.IsNull();
            bool nullDog = anotherDog.IsNull();

            // Assert
            notNullDog.ShouldBeFalse();
            nullDog.ShouldBeTrue();
        }

                [Fact]
        public void IsNotNull()
        {
            // Arrange
            TestDog dog = new();
            TestDog? anotherDog = null;

            // Act
            bool notNullDog = dog.IsNotNull();
            bool nullDog = anotherDog.IsNotNull();

            // Assert
            notNullDog.ShouldBeTrue();
            nullDog.ShouldBeFalse();
        }
    }
}