using Shouldly;

namespace CommonExtensions.Test
{
    public class DataTypesShould
    {
        [InlineData(true, false)]
        [InlineData(true, 0)]
        [InlineData(true, 0.0)]
        [InlineData(false, true)]
        [InlineData(false, 10)]
        [InlineData(false, 0.33)]
        [Theory]
        public void EvaluateSimpleTypes<T>(bool expected, T value)
        {
            value.IsDefault().ShouldBe(expected);
        }

        [InlineData(true, null, null, null)]
        [InlineData(false, 10, true, 0.333)]
        [InlineData(false, 0, false, 0.0)]
        [Theory]
        public void EvaluateNullableTypes(bool expected, int? intNull, bool? boolNull, double? doubleNull)
        {
            intNull.IsDefault().ShouldBe(expected);
            boolNull.IsDefault().ShouldBe(expected);
            doubleNull.IsDefault().ShouldBe(expected);
        }

        [InlineData(false, "SomeStringValue")]
        [InlineData(true, null)]
        [Theory]
        public void EvaluateStringTypes(bool expected, string value)
        {
            value.IsDefault().ShouldBe(expected);
        }

        [Fact]
        public void EvaluateComplexTypes()
        {
            Company company = new Company();

            company.Boss.IsDefault().ShouldBeTrue();
            company.Employees.IsDefault().ShouldBeTrue();

            company.Boss = new Person()
            {
                Name = "Tom"
            };
            company.Employees = new Person[] { company.Boss, new Person() { Name = "Fred" } };

            company.Boss.IsDefault().ShouldBeFalse();
            company.Employees.IsDefault().ShouldBeFalse();
        }
    }

    //Classes for Testing
    public class Company
    {
        public Person? Boss { get; set; }
        public Person[]? Employees { get; set; }
    }
    
    public class Person
    {
        public string? Name { get; set; }
    }
}