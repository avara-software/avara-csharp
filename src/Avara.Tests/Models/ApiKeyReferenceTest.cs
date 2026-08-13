using System.Text.Json;
using Avara.Core;
using Avara.Models;

namespace Avara.Tests.Models;

public class ApiKeyReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsClinicalContextEnrichmentEnabled = true,
            IsViewerEnabled = true,
        };

        string expectedApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedDescription = "Production API Key";
        bool expectedIsClinicalContextEnrichmentEnabled = true;
        bool expectedIsViewerEnabled = true;

        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(
            expectedIsClinicalContextEnrichmentEnabled,
            model.IsClinicalContextEnrichmentEnabled
        );
        Assert.Equal(expectedIsViewerEnabled, model.IsViewerEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsClinicalContextEnrichmentEnabled = true,
            IsViewerEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsClinicalContextEnrichmentEnabled = true,
            IsViewerEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedDescription = "Production API Key";
        bool expectedIsClinicalContextEnrichmentEnabled = true;
        bool expectedIsViewerEnabled = true;

        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(
            expectedIsClinicalContextEnrichmentEnabled,
            deserialized.IsClinicalContextEnrichmentEnabled
        );
        Assert.Equal(expectedIsViewerEnabled, deserialized.IsViewerEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsClinicalContextEnrichmentEnabled = true,
            IsViewerEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
        };

        Assert.Null(model.IsClinicalContextEnrichmentEnabled);
        Assert.False(model.RawData.ContainsKey("isClinicalContextEnrichmentEnabled"));
        Assert.Null(model.IsViewerEnabled);
        Assert.False(model.RawData.ContainsKey("isViewerEnabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",

            // Null should be interpreted as omitted for these properties
            IsClinicalContextEnrichmentEnabled = null,
            IsViewerEnabled = null,
        };

        Assert.Null(model.IsClinicalContextEnrichmentEnabled);
        Assert.False(model.RawData.ContainsKey("isClinicalContextEnrichmentEnabled"));
        Assert.Null(model.IsViewerEnabled);
        Assert.False(model.RawData.ContainsKey("isViewerEnabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",

            // Null should be interpreted as omitted for these properties
            IsClinicalContextEnrichmentEnabled = null,
            IsViewerEnabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyReference
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsClinicalContextEnrichmentEnabled = true,
            IsViewerEnabled = true,
        };

        ApiKeyReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
