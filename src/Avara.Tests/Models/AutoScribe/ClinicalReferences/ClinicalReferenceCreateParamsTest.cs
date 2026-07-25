using System;
using System.Collections.Generic;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalReferenceID = "FAC-001",
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
        };

        string expectedName = "City Medical Center";
        ApiEnum<string, ClinicalReferenceType> expectedType = ClinicalReferenceType.Facility;
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalReferenceID = "FAC-001";
        Dictionary<string, string> expectedMetadata = new() { { "region", "northeast" } };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedExternalReferenceID, parameters.ExternalReferenceID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExternalReferenceID = "FAC-001",
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExternalReferenceID = "FAC-001",

            // Null should be interpreted as omitted for these properties
            ExpressCustomerID = null,
            Metadata = null,
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
        };

        Assert.Null(parameters.ExternalReferenceID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalReferenceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },

            ExternalReferenceID = null,
        };

        Assert.Null(parameters.ExternalReferenceID);
        Assert.True(parameters.RawBodyData.ContainsKey("externalReferenceId"));
    }

    [Fact]
    public void Url_Works()
    {
        ClinicalReferenceCreateParams parameters = new()
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/clinicalReferences"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClinicalReferenceCreateParams
        {
            Name = "City Medical Center",
            Type = ClinicalReferenceType.Facility,
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalReferenceID = "FAC-001",
            Metadata = new Dictionary<string, string>() { { "region", "northeast" } },
        };

        ClinicalReferenceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
