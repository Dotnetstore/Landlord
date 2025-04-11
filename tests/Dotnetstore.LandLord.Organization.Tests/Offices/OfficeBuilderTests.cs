using Dotnetstore.LandLord.Organization.Offices;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.Organization.Tests.Offices;

public class OfficeBuilderTests
{
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000001", "Test Office", null)]
    [InlineData("EEE691A4-53FE-4143-80FE-93769DAE120D", "Test Office", "123456-7897")]
    public void Build_ShouldReturnOfficeWithCorrectProperties(
        string id,
        string name,
        string? corporateId)
    {
        // Arrange
        var officeId = new OfficeId(Guid.Parse(id));

        // Act
        var office = OfficeBuilder
            .Create()
            .WithId(officeId)
            .WithName(name)
            .WithCorporateId(corporateId)
            .Build();

        // Assert
        using (new AssertionScope())
        {
            office.Id.Should().Be(officeId);
            office.Name.Should().Be(name);
            office.CorporateId.Should().Be(corporateId);
        }
    }
    
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000", "Test Office", null)]
    [InlineData("EEE691A4-53FE-4143-80FE-93769DAE120D", "Test Office", "123456-7890")]
    [InlineData("EEE691A4-53FE-4143-80FE-93769DAE120D", "", "123456-7897")]
    public void Build_ShouldThrowException(
        string id,
        string name,
        string? corporateId)
    {
        // Arrange
        var officeId = new OfficeId(Guid.Empty);

        // Act
        var act = () => OfficeBuilder
            .Create()
            .WithId(officeId);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*id*");
    }}