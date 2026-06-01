using System;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z");
        bool expectedIsAddendum = false;
        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedSignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
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
        ApiEnum<string, ReportStatus> expectedStatus = ReportStatus.Completed;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedReportPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsAddendum, model.IsAddendum);
        Assert.Equal(expectedIsCritical, model.IsCritical);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedSignedAt, model.SignedAt);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedReportPlainText, model.ReportPlainText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Report>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Report>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z");
        bool expectedIsAddendum = false;
        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedSignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
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
        ApiEnum<string, ReportStatus> expectedStatus = ReportStatus.Completed;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedReportPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsAddendum, deserialized.IsAddendum);
        Assert.Equal(expectedIsCritical, deserialized.IsCritical);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedSignedAt, deserialized.SignedAt);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedReportPlainText, deserialized.ReportPlainText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        Assert.Null(model.ReportPlainText);
        Assert.False(model.RawData.ContainsKey("reportPlainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            ReportPlainText = null,
        };

        Assert.Null(model.ReportPlainText);
        Assert.False(model.RawData.ContainsKey("reportPlainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            ReportPlainText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
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
            Status = ReportStatus.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        Report copied = new(model);

        Assert.Equal(model, copied);
    }
}
