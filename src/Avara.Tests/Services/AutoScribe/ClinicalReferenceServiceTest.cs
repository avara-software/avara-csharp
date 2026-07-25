using System.Threading.Tasks;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Services.AutoScribe;

public class ClinicalReferenceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var clinicalReference = await this.client.AutoScribe.ClinicalReferences.Create(
            new() { Name = "City Medical Center", Type = ClinicalReferenceType.Facility },
            TestContext.Current.CancellationToken
        );
        clinicalReference.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var clinicalReference = await this.client.AutoScribe.ClinicalReferences.Retrieve(
            "ref_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        clinicalReference.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var clinicalReference = await this.client.AutoScribe.ClinicalReferences.Update(
            "ref_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        clinicalReference.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.AutoScribe.ClinicalReferences.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var clinicalReference = await this.client.AutoScribe.ClinicalReferences.Delete(
            "ref_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        clinicalReference.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveByExternalReferenceID_Works()
    {
        var clinicalReference =
            await this.client.AutoScribe.ClinicalReferences.RetrieveByExternalReferenceID(
                "FAC-001",
                new(),
                TestContext.Current.CancellationToken
            );
        clinicalReference.Validate();
    }
}
