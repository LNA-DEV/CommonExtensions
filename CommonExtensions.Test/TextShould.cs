using Shouldly;

namespace CommonExtensions.Test
{
    public class TextShould
    {
        [Fact]
        public void SplitToString()
        {
            //Arrange 
            string[] input = { "Test1", "Test2", "Test3" };

            //Act
            string result = input.SplitToString(", ");

            //Assert
            Assert.Equal("Test1, Test2, Test3", result);
        }

        [Fact]
        public void ToCamelCase()
        {
            // Arrange
            string pascalCase = "HelloWorld";

            // Act
            string camelCase = pascalCase.ToCamelCase();

            // Assert
            camelCase.ShouldBe("helloWorld");
        }
    }
}
