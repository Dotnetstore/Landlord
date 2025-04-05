using Dotnetstore.LandLord.SharedKernel.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.LandLord.SharedKernel.Tests.Entities;

public class PersonTests
{
    [Fact]
    public void Person_ShouldHaveValidProperties()
    {
        // Arrange
        var type = typeof(Person);
        
        // Act
        var properties = type.GetProperties();
        
        // Assert
        using (new AssertionScope())
        {
            properties.Should().ContainSingle(x => x.Name == nameof(Person.LastName) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(Person.FirstName) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(Person.MiddleName) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(Person.SocialSecurityNumber) && x.PropertyType == typeof(string));
            properties.Should().ContainSingle(x => x.Name == nameof(Person.IsMale) && x.PropertyType == typeof(bool));
        }
    }
}