using Shouldly;

namespace CommonExtensions.Test
{
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
            bool isEmpty = emptyList.IsNullOrEmpty();
            bool isNull = nullList.IsNullOrEmpty();
            bool isNotNullOrEmpty = fullList.IsNullOrEmpty();

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
            bool isEmpty = emptyList.IsNotNullOrEmpty();
            bool isNull = nullList.IsNotNullOrEmpty();
            bool isNullOrEmpty = fullList.IsNotNullOrEmpty();

            // Assert
            isEmpty.ShouldBeFalse();
            isNull.ShouldBeFalse();
            isNullOrEmpty.ShouldBeTrue();
        }
    }
}