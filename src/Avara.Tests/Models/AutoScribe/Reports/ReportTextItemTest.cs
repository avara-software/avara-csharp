using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportTextItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = HeightUnit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedIsCritical, model.IsCritical);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedPlainText, model.PlainText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportTextItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportTextItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = HeightUnit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedIsCritical, deserialized.IsCritical);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedPlainText, deserialized.PlainText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportTextItem
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        ReportTextItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
