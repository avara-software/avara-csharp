using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportListResponse
        {
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                    IsAddendum = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = Sex.Female,
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    Status = Status.Completed,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    ReportPlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        List<Report> expectedReports =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                IsAddendum = false,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                SnapshotMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = Unit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    ScanDate = "2024-03-15",
                    ScanTime = "14:30",
                    ScanType = "MRI Brain with Contrast",
                    Sex = Sex.Female,
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                Status = Status.Completed,
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                UserID = "usr_1234567890abcdef1234567890abcdef",
                ReportPlainText =
                    "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
            },
        ];
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedReports.Count, model.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], model.Reports[i]);
        }
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportListResponse
        {
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                    IsAddendum = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = Sex.Female,
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    Status = Status.Completed,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    ReportPlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportListResponse
        {
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                    IsAddendum = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = Sex.Female,
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    Status = Status.Completed,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    ReportPlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Report> expectedReports =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                IsAddendum = false,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                SnapshotMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = Unit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    ScanDate = "2024-03-15",
                    ScanTime = "14:30",
                    ScanType = "MRI Brain with Contrast",
                    Sex = Sex.Female,
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                Status = Status.Completed,
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                UserID = "usr_1234567890abcdef1234567890abcdef",
                ReportPlainText =
                    "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
            },
        ];
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedReports.Count, deserialized.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], deserialized.Reports[i]);
        }
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportListResponse
        {
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                    IsAddendum = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = Sex.Female,
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    Status = Status.Completed,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    ReportPlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportListResponse
        {
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
                    IsAddendum = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = Sex.Female,
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    Status = Status.Completed,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    ReportPlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        ReportListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Report
        {
            CreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z"),
            IsAddendum = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            ReportPlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T14:30:00Z");
        bool expectedIsAddendum = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedSignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            ReferringPhysicianName = "Dr. Michael Chen",
            ScanDate = "2024-03-15",
            ScanTime = "14:30",
            ScanType = "MRI Brain with Contrast",
            Sex = Sex.Female,
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedReportPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsAddendum, model.IsAddendum);
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedSignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            ReferringPhysicianName = "Dr. Michael Chen",
            ScanDate = "2024-03-15",
            ScanTime = "14:30",
            ScanType = "MRI Brain with Contrast",
            Sex = Sex.Female,
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedReportPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsAddendum, deserialized.IsAddendum);
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SignedAt = DateTimeOffset.Parse("2024-03-15T16:00:00Z"),
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = Sex.Female,
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Status = Status.Completed,
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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
