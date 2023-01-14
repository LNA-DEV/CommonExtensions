using CommonExtensions.Test.Models;
using Shouldly;

namespace CommonExtensions.Test;

public class ObjectsShould
{
    [Fact]
    public void IsNull()
    {
        // Arrange
        TestDog dog = new();
        TestDog? anotherDog = null;

        // Act
        var notNullDog = dog.IsNull();
        var nullDog = anotherDog.IsNull();

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
        var notNullDog = dog.IsNotNull();
        var nullDog = anotherDog.IsNotNull();

        // Assert
        notNullDog.ShouldBeTrue();
        nullDog.ShouldBeFalse();
    }
}