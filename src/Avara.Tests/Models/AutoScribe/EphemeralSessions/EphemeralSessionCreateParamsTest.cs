using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Models;
using Avara.Models.AutoScribe.EphemeralSessions;

namespace Avara.Tests.Models.AutoScribe.EphemeralSessions;

public class EphemeralSessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EphemeralSessionCreateParams
        {
            RetrievalID = "order-12345",
            HangingProtocol = new()
            {
                Layout = ViewerLayout.TwoByTwo,
                ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
            },
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedRetrievalID = "order-12345";
        EphemeralHangingProtocol expectedHangingProtocol = new()
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };
        Dictionary<string, JsonElement> expectedOptions = new()
        {
            { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedRetrievalID, parameters.RetrievalID);
        Assert.Equal(expectedHangingProtocol, parameters.HangingProtocol);
        Assert.NotNull(parameters.Options);
        Assert.Equal(expectedOptions.Count, parameters.Options.Count);
        foreach (var item in expectedOptions)
        {
            Assert.True(parameters.Options.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Options[item.Key]));
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EphemeralSessionCreateParams { RetrievalID = "order-12345" };

        Assert.Null(parameters.HangingProtocol);
        Assert.False(parameters.RawBodyData.ContainsKey("hangingProtocol"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EphemeralSessionCreateParams
        {
            RetrievalID = "order-12345",

            // Null should be interpreted as omitted for these properties
            HangingProtocol = null,
            Options = null,
        };

        Assert.Null(parameters.HangingProtocol);
        Assert.False(parameters.RawBodyData.ContainsKey("hangingProtocol"));
        Assert.Null(parameters.Options);
        Assert.False(parameters.RawBodyData.ContainsKey("options"));
    }

    [Fact]
    public void Url_Works()
    {
        EphemeralSessionCreateParams parameters = new() { RetrievalID = "order-12345" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/ephemeral-sessions"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EphemeralSessionCreateParams
        {
            RetrievalID = "order-12345",
            HangingProtocol = new()
            {
                Layout = ViewerLayout.TwoByTwo,
                ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
            },
            Options = new Dictionary<string, JsonElement>()
            {
                { "studyInstanceUids", JsonSerializer.SerializeToElement("bar") },
            },
        };

        EphemeralSessionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
