using Alba;
using Shows.Api.Shows.Models;
using Shows.Tests.Api.Fixtures;

namespace Shows.Tests.Api.Shows;

[Collection("SystemTestFixture")]
[Trait("Category", "SystemTest")]
public class AddingAShow(SystemTestFixture fixture)
{
    private readonly IAlbaHost _host = fixture.Host;

    [Fact]
    public async Task AddShow()
    {
        var showToCreate = new ShowCreateModel
        {
            Name = "Test Show",
            Description = "This is a test show",
            StreamingService = "HBO Max"

        };
        var response = await _host.Scenario(api =>
        {
            api.Post.Json(showToCreate).ToUrl("/api/shows");
            api.StatusCodeShouldBeOk();
        });
        
        var postBody= response.ReadAsJson<ShowDetailsModel>();

        Assert.NotNull(postBody);
        Assert.Equal(showToCreate.Name, postBody.Name);
        //Assert.True(postBody.Id != Guid.NewGuid());

    }
    
}