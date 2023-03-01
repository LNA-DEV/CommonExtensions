using System.Text.Json;
using CommonExtensions.Test.TestHelpers;
using Shouldly;

namespace CommonExtensions.Test;

public class ObjectsShould
{
    [Fact]
    public void IsNull()
    {
        // Arrange
        TestDog dog = new()
        {
            LegCount = 4,
            Name = "Kira"
        };
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
        var person = new Person
        {
            Name = "LNA-DEV"
        };
        object personObject = JsonSerializer.Serialize(person);

        // Act
        var extractItem = personObject.TrySystemJsonDeserialization<Person>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBeEquivalentTo(person);
    }

    [Fact]
    public void TrySystemJsonDeserializationJsonElement()
    {
        // Arrange
        var person = new Person
        {
            Name = "LNA-DEV"
        };
        var jsonElement = JsonSerializer.SerializeToDocument(person).RootElement;
        var obj = (object)jsonElement;

        // Act
        var extractItem = obj.TrySystemJsonDeserialization<Person>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBeEquivalentTo(person);
    }

    [Fact]
    public void TrySystemJsonDeserializationJsonElementString()
    {
        // Arrange
        var person = new Person
        {
            Name = "LNA-DEV"
        };
        var jsonElement = JsonSerializer.SerializeToDocument(person).RootElement;
        var obj = (object)jsonElement;

        // Act
        var extractItem = obj.TrySystemJsonDeserialization<string>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBeEquivalentTo(JsonSerializer.Serialize(person));
    }

    [Fact]
    public void TrySystemJsonDeserializationJsonElementArrayString()
    {
        // Arrange
        var personList = new List<Person>
        {
            new()
            {
                Name = "LNA-DEV"
            }
        };
        var jsonElement = JsonSerializer.SerializeToDocument(personList).RootElement;
        var obj = (object)jsonElement;

        // Act
        var extractItem = obj.TrySystemJsonDeserialization<string>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBeEquivalentTo(JsonSerializer.Serialize(personList));
    }
    
    [Fact]
    public void TrySystemJsonDeserializationJsonElementStringInput()
    {
        // Arrange
        var text = @"hi";
        var jsonElement = JsonSerializer.SerializeToDocument(text).RootElement;
        var obj = (object)jsonElement;

        // Act
        var extractItem = obj.TrySystemJsonDeserialization<string>();

        // Assert
        extractItem.ShouldNotBeNull();
        extractItem.ShouldBeEquivalentTo(text);
    }

    [Fact]
    public void TrySystemJsonDeserializationException()
    {
        // Arrange
        var person = new Person
        {
            Name = "LNA-DEV"
        };

        // Act
        try
        {
            var extractItem = person.TrySystemJsonDeserialization<string>();
        }
        catch (ArgumentException ex)
        {
            // Assert
            Assert.True(true);
            return;
        }

        Assert.True(false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsSameAs(bool same)
    {
        // Arrange
        var obj1 = new Person
        {
            Name = "Cuddlefish"
        };
        Person obj2;
        if (same)
            obj2 = new Person
            {
                Name = "Cuddlefish"
            };
        else
            obj2 = new Person
            {
                Name = "Cuddlefish2"
            };

        // Act
        var result = obj1.IsSameAs(obj2);

        // Assert
        result.ShouldBe(same);
    }

    [Fact]
    public void IsSameAsRefEqual()
    {
        // Arrange
        var obj1 = new Person
        {
            Name = "Cuddlefish"
        };

        // Act
        var result = obj1.IsSameAs(obj1);

        // Assert
        result.ShouldBe(true);
    }

    [Fact]
    public void IsSameAsNull()
    {
        // Arrange
        var obj1 = new Person
        {
            Name = "Cuddlefish"
        };

        // Act
        var result = obj1.IsSameAs(null);

        // Assert
        result.ShouldBe(false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsNotSameAs(bool same)
    {
        // Arrange
        var obj1 = new Person
        {
            Name = "Cuddlefish"
        };
        Person obj2;
        if (same)
            obj2 = new Person
            {
                Name = "Cuddlefish"
            };
        else
            obj2 = new Person
            {
                Name = "Cuddlefish2"
            };

        // Act
        var result = obj1.IsNotSameAs(obj2);

        // Assert
        result.ShouldBe(!same);
    }
}