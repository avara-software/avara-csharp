using System.Threading.Tasks;
using Avara.Models.AutoScribe;
using Studies = Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Services.AutoScribe;

public class StudyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var study = await this.client.AutoScribe.Studies.Create(
            new()
            {
                ReportMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = Unit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    Procedure = "MRI Brain with Contrast",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    Sex = Sex.Female,
                    StudyDate = "2024-03-15",
                    StudyTime = "14:30",
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                Severity = Studies::Severity.Normal,
                StudyDescription = "Brain MRI with Contrast",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            },
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var study = await this.client.AutoScribe.Studies.Retrieve(
            "stu_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var study = await this.client.AutoScribe.Studies.Update(
            "stu_1234567890abcdef1234567890abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        study.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.AutoScribe.Studies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.AutoScribe.Studies.Cancel(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RerouteUrl_Works()
    {
        var response = await this.client.AutoScribe.Studies.RerouteUrl(
            new() { AssignedToUserID = "usr_1234567890abcdef1234567890abcdef" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveByUid_Works()
    {
        var response = await this.client.AutoScribe.Studies.RetrieveByUid(
            "1.2.840.10008.5.1.4.1.1.2",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Uncancel_Works()
    {
        var response = await this.client.AutoScribe.Studies.Uncancel(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ViewerOnlyRerouteUrl_Works()
    {
        var response = await this.client.AutoScribe.Studies.ViewerOnlyRerouteUrl(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
