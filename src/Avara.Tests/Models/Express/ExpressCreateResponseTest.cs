using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
            CreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            CreatedByUserID = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z");
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center - Radiology Department";
        bool expectedIsActive = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        long expectedUserCount = 15;
        string expectedCreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedCreatedByUserID = "usr_1234567890abcdef1234567890abcdef";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "region", "northeast" },
        };

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpressCustomerID, model.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, model.ExpressCustomerName);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserCount, model.UserCount);
        Assert.Equal(expectedCreatedByApiKeyID, model.CreatedByApiKeyID);
        Assert.Equal(expectedCreatedByUserID, model.CreatedByUserID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
            CreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            CreatedByUserID = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
            CreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            CreatedByUserID = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z");
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center - Radiology Department";
        bool expectedIsActive = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        long expectedUserCount = 15;
        string expectedCreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedCreatedByUserID = "usr_1234567890abcdef1234567890abcdef";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "region", "northeast" },
        };

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpressCustomerID, deserialized.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, deserialized.ExpressCustomerName);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserCount, deserialized.UserCount);
        Assert.Equal(expectedCreatedByApiKeyID, deserialized.CreatedByApiKeyID);
        Assert.Equal(expectedCreatedByUserID, deserialized.CreatedByUserID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
            CreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            CreatedByUserID = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
        };

        Assert.Null(model.CreatedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("createdByApiKeyId"));
        Assert.Null(model.CreatedByUserID);
        Assert.False(model.RawData.ContainsKey("createdByUserId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,

            // Null should be interpreted as omitted for these properties
            CreatedByApiKeyID = null,
            CreatedByUserID = null,
            Metadata = null,
        };

        Assert.Null(model.CreatedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("createdByApiKeyId"));
        Assert.Null(model.CreatedByUserID);
        Assert.False(model.RawData.ContainsKey("createdByUserId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,

            // Null should be interpreted as omitted for these properties
            CreatedByApiKeyID = null,
            CreatedByUserID = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExpressCreateResponse
        {
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center - Radiology Department",
            IsActive = true,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            UserCount = 15,
            CreatedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            CreatedByUserID = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "region", "northeast" },
            },
        };

        ExpressCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
