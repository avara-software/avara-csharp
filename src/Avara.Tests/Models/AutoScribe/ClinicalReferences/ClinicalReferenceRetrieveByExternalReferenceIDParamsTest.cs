using System;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceRetrieveByExternalReferenceIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClinicalReferenceRetrieveByExternalReferenceIDParams
        {
            ExternalReferenceID = "FAC-001",
        };

        string expectedExternalReferenceID = "FAC-001";

        Assert.Equal(expectedExternalReferenceID, parameters.ExternalReferenceID);
    }

    [Fact]
    public void Url_Works()
    {
        ClinicalReferenceRetrieveByExternalReferenceIDParams parameters = new()
        {
            ExternalReferenceID = "FAC-001",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/clinicalReferences/byExternalReferenceId/FAC-001"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClinicalReferenceRetrieveByExternalReferenceIDParams
        {
            ExternalReferenceID = "FAC-001",
        };

        ClinicalReferenceRetrieveByExternalReferenceIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
