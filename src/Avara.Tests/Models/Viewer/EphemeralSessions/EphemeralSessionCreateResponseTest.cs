using System.Text.Json;
using Avara.Core;
using Avara.Models.Viewer.EphemeralSessions;

namespace Avara.Tests.Models.Viewer.EphemeralSessions;

public class EphemeralSessionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EphemeralSessionCreateResponse
        {
            Url = "https://viewer.avarasoftware.com/token/landing?token=abc123",
        };

        string expectedUrl = "https://viewer.avarasoftware.com/token/landing?token=abc123";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EphemeralSessionCreateResponse
        {
            Url = "https://viewer.avarasoftware.com/token/landing?token=abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralSessionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EphemeralSessionCreateResponse
        {
            Url = "https://viewer.avarasoftware.com/token/landing?token=abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralSessionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://viewer.avarasoftware.com/token/landing?token=abc123";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EphemeralSessionCreateResponse
        {
            Url = "https://viewer.avarasoftware.com/token/landing?token=abc123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EphemeralSessionCreateResponse
        {
            Url = "https://viewer.avarasoftware.com/token/landing?token=abc123",
        };

        EphemeralSessionCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
