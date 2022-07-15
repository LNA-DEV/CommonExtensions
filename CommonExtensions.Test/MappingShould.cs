using CommonExtensions.Test.MappingHelpers;
using Shouldly;

namespace CommonExtensions.Test
{
    public class MappingShould
    {
        [Fact]
        public void MapSimple()
        {
            //Arrange
            ExampleModel model = new()
            {
                Blub = true,
                DeviceNames = new() { "Device1", "Device2" },
                Id = 1,
                Name = "Blub"
            };

            //Act
            var result = model.MapSimple<MappedExampleModel, ExampleModel>();

            //Assert
            result.ShouldNotBeNull();
            result.Name.ShouldBe("Blub");
            result.Id.ShouldBe(1);
            result.Blub.ShouldBe(true);
            result.DeviceNames.ShouldBe(new() { "Device1", "Device2" });
        }
    }
}