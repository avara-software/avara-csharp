using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Express;

namespace Avara.Tests.Models.Express;

public class ExpressListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        List<ExpressListResponse> expectedExpressCustomers =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedExpressCustomers.Count, model.ExpressCustomers.Count);
        for (int i = 0; i < expectedExpressCustomers.Count; i++)
        {
            Assert.Equal(expectedExpressCustomers[i], model.ExpressCustomers[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ExpressListResponse> expectedExpressCustomers =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedExpressCustomers.Count, deserialized.ExpressCustomers.Count);
        for (int i = 0; i < expectedExpressCustomers.Count; i++)
        {
            Assert.Equal(expectedExpressCustomers[i], deserialized.ExpressCustomers[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExpressListPageResponse
        {
            ExpressCustomers =
            [
                new()
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
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        ExpressListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
