using System;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClinicalReferenceDeleteParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
        };

        string expectedClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef";

        Assert.Equal(expectedClinicalReferenceID, parameters.ClinicalReferenceID);
    }

    [Fact]
    public void Url_Works()
    {
        ClinicalReferenceDeleteParams parameters = new()
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/clinicalReferences/ref_1234567890abcdef1234567890abcdef/delete"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClinicalReferenceDeleteParams
        {
            ClinicalReferenceID = "ref_1234567890abcdef1234567890abcdef",
        };

        ClinicalReferenceDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
