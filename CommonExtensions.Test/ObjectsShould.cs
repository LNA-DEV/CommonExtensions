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

    [Fact]
    public void TrySystemJsonDeserializationObject()
    {
        // Arrange
        var personName = "Joe";
        var person = new Person
        {
            Name = personName
        };
        object personObject = person;

        // Act
        var extractItem = personObject.TrySystemJsonDeserialization<Person>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.Name = personName;
    }

    [Fact]
    public void TrySystemJsonDeserializationString()
    {
        // Arrange
        var personName = "Joe";
        object personObject = personName;

        // Act
        var extractItem = personObject.TrySystemJsonDeserialization<string>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBe(personName);
    }
}