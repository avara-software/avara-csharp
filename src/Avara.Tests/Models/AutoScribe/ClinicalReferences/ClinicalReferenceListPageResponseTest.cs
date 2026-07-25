using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        List<ClinicalReference> expectedClinicalReferences =
        [
            new()
            {
                ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                IsActive = true,
                Name = "City Medical Center",
                Type = ClinicalReferenceType.Facility,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                ExpressCustomer = new()
                {
                    ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                    ExpressCustomerName = "City Medical Center",
                },
                ExternalReferenceID = "FAC-001",
                Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
            },
        ];
        bool expectedHasMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedClinicalReferences.Count, model.ClinicalReferences.Count);
        for (int i = 0; i < expectedClinicalReferences.Count; i++)
        {
            Assert.Equal(expectedClinicalReferences[i], model.ClinicalReferences[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalReferenceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalReferenceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ClinicalReference> expectedClinicalReferences =
        [
            new()
            {
                ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                IsActive = true,
                Name = "City Medical Center",
                Type = ClinicalReferenceType.Facility,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                ExpressCustomer = new()
                {
                    ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                    ExpressCustomerName = "City Medical Center",
                },
                ExternalReferenceID = "FAC-001",
                Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
            },
        ];
        bool expectedHasMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedClinicalReferences.Count, deserialized.ClinicalReferences.Count);
        for (int i = 0; i < expectedClinicalReferences.Count; i++)
        {
            Assert.Equal(expectedClinicalReferences[i], deserialized.ClinicalReferences[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
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
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
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
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
                },
            ],
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
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
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
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
        var model = new ClinicalReferenceListPageResponse
        {
            ClinicalReferences =
            [
                new()
                {
                    ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
                    CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
                    IsActive = true,
                    Name = "City Medical Center",
                    Type = ClinicalReferenceType.Facility,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    ExternalReferenceID = "FAC-001",
                    Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
                },
            ],
            HasMore = true,
            Cursor = "cursor",
        };

        ClinicalReferenceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
