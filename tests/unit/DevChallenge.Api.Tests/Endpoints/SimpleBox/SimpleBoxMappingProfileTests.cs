using AutoMapper;
using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.Endpoints.SimpleBox;

public class SimpleBoxMappingProfileTests
{
    [Fact]
    public void SimpleBoxMappingProfile_should_be_valid()
    {
        var mapperConfig = new MapperConfiguration(x => x.AddProfile<SimpleBoxMappingProfile>());
        mapperConfig.AssertConfigurationIsValid();
    }
}