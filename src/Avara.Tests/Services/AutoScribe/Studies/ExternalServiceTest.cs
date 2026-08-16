using System.Threading.Tasks;
using Avara.Models;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Services.AutoScribe.Studies;

public class ExternalServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var external = await this.client.AutoScribe.Studies.External.Create(
            new()
            {
                ReportMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    Procedure = "CT Chest",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    Sex = Sex.Female,
                    StudyDate = "2024-01-15",
                    StudyTime = "14:30",
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                Severity = Severity.Normal,
                StudyDescription = "CT Chest without contrast",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            },
            TestContext.Current.CancellationToken
        );
        external.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var external = await this.client.AutoScribe.Studies.External.Delete(
            new(),
            TestContext.Current.CancellationToken
        );
        external.Validate();
    }
}
