using System;
using System.Collections.Generic;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "region", "northeast" },
                { "wing", "Building A" },
            },
            Name = "City Medical Center - Main Campus",
        };

        string expectedClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "region", "northeast" },
            { "wing", "Building A" },
        };
        string expectedName = "City Medical Center - Main Campus";

        Assert.Equal(expectedClinicalReferenceID, parameters.ClinicalReferenceID);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "region", "northeast" },
                { "wing", "Building A" },
            },
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "region", "northeast" },
                { "wing", "Building A" },
            },

            // Null should be interpreted as omitted for these properties
            ExpressCustomerID = null,
            Name = null,
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Name = "City Medical Center - Main Campus",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Name = "City Medical Center - Main Campus",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ClinicalReferenceUpdateParams parameters = new()
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/clinicalReferences/ref_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClinicalReferenceUpdateParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "region", "northeast" },
                { "wing", "Building A" },
            },
            Name = "City Medical Center - Main Campus",
        };

        ClinicalReferenceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
