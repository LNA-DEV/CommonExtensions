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
    }
}
