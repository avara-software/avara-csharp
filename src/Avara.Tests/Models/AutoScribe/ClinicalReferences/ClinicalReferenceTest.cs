using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalReference
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
        };

        string expectedClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z");
        bool expectedIsActive = true;
        string expectedName = "City Medical Center";
        ApiEnum<string, ClinicalReferenceType> expectedType = ClinicalReferenceType.Facility;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        ExpressCustomerReference expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalReferenceID = "FAC-001";
        Dictionary<string, string> expectedMetadata = new() { { "region", "northeast" } };

        Assert.Equal(expectedClinicalReferenceID, model.ClinicalReferenceID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedExpressCustomer, model.ExpressCustomer);
        Assert.Equal(expectedExternalReferenceID, model.ExternalReferenceID);
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
        var model = new ClinicalReference
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalReference
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z");
        bool expectedIsActive = true;
        string expectedName = "City Medical Center";
        ApiEnum<string, ClinicalReferenceType> expectedType = ClinicalReferenceType.Facility;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        ExpressCustomerReference expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalReferenceID = "FAC-001";
        Dictionary<string, string> expectedMetadata = new() { { "region", "northeast" } };

        Assert.Equal(expectedClinicalReferenceID, deserialized.ClinicalReferenceID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedExpressCustomer, deserialized.ExpressCustomer);
        Assert.Equal(expectedExternalReferenceID, deserialized.ExternalReferenceID);
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
        var model = new ClinicalReference
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalReference
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
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalReference
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalReference
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalReference
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalReference
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            IsActive = true,
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
        };

        Assert.Null(model.ExpressCustomer);
        Assert.False(model.RawData.ContainsKey("expressCustomer"));
        Assert.Null(model.ExternalReferenceID);
        Assert.False(model.RawData.ContainsKey("externalReferenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalReference
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            IsActive = true,
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClinicalReference
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            IsActive = true,
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },

            ExpressCustomer = null,
            ExternalReferenceID = null,
        };

        Assert.Null(model.ExpressCustomer);
        Assert.True(model.RawData.ContainsKey("expressCustomer"));
        Assert.Null(model.ExternalReferenceID);
        Assert.True(model.RawData.ContainsKey("externalReferenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalReference
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            CreatedAt = DateTimeOffset.Parse("2024-01-15T09:00:00Z"),
            IsActive = true,
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },

            ExpressCustomer = null,
            ExternalReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalReference
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
        };

        ClinicalReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
