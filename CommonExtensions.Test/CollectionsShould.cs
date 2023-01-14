using Shouldly;

namespace CommonExtensions.Test;

public class CollectionsShould
{
    [Fact]
    public void IsNullOrEmpty()
    {
        // Arrange
        List<string> emptyList = new();
        List<string>? nullList = null;
        List<string> fullList = new()
        {
            "Blub",
            "Hello World"
        };

        // Act
        var isEmpty = emptyList.IsNullOrEmpty();
        var isNull = nullList.IsNullOrEmpty();
        var isNotNullOrEmpty = fullList.IsNullOrEmpty();

        // Assert
        isEmpty.ShouldBeTrue();
        isNull.ShouldBeTrue();
        isNotNullOrEmpty.ShouldBeFalse();
    }

    [Fact]
    public void IsNotNullOrEmpty()
    {
        // Arrange
        List<string> emptyList = new();
        List<string>? nullList = null;
        List<string> fullList = new()
        {
            "Blub",
            "Hello World"
        };

        // Act
        var isEmpty = emptyList.IsNotNullOrEmpty();
        var isNull = nullList.IsNotNullOrEmpty();
        var isNullOrEmpty = fullList.IsNotNullOrEmpty();

        // Assert
        isEmpty.ShouldBeFalse();
        isNull.ShouldBeFalse();
        isNullOrEmpty.ShouldBeTrue();
    }
}