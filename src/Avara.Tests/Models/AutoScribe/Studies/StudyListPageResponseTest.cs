using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe.Studies;
using AutoScribe = Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
            Cursor = "cursor",
        };

        bool expectedHasMore = true;
        List<StudyListResponse> expectedStudies =
        [
            new()
            {
                CancelledAt = null,
                CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                IsCancelled = false,
                ReportMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    ScanDate = "2024-03-15",
                    ScanTime = "14:30",
                    ScanType = "MRI Brain with Contrast",
                    Sex = AutoScribe::Sex.Female,
                    Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                },
                Severity = StudyListResponseSeverity.Normal,
                StudyDescription = "Brain MRI with Contrast",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                AssignedTo = new()
                {
                    Email = "dr.smith@radiology.com",
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    FirstName = "John",
                    LastName = "Smith",
                    MiddleName = "Robert",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
                CreatedByApiKey = new()
                {
                    ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    Description = "Production API Key",
                    IsViewerEnabled = true,
                },
                CreatedByUser = new()
                {
                    Email = "dr.smith@radiology.com",
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    FirstName = "John",
                    LastName = "Smith",
                    MiddleName = "Robert",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
                ExpressCustomer = new()
                {
                    ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                    ExpressCustomerName = "City Medical Center",
                },
                Metadata = new Dictionary<string, string>()
                {
                    { "department", "radiology" },
                    { "priority", "routine" },
                },
                PriorReportTexts = ["Previous imaging shows stable findings."],
                PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                ReportIds =
                [
                    new()
                    {
                        ReportID = "rep_1234567890abcdef1234567890abcdef",
                        Status = Status.InProgress,
                    },
                ],
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedStudies.Count, model.Studies.Count);
        for (int i = 0; i < expectedStudies.Count; i++)
        {
            Assert.Equal(expectedStudies[i], model.Studies[i]);
        }
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<StudyListResponse> expectedStudies =
        [
            new()
            {
                CancelledAt = null,
                CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                IsCancelled = false,
                ReportMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    ScanDate = "2024-03-15",
                    ScanTime = "14:30",
                    ScanType = "MRI Brain with Contrast",
                    Sex = AutoScribe::Sex.Female,
                    Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                },
                Severity = StudyListResponseSeverity.Normal,
                StudyDescription = "Brain MRI with Contrast",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                AssignedTo = new()
                {
                    Email = "dr.smith@radiology.com",
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    FirstName = "John",
                    LastName = "Smith",
                    MiddleName = "Robert",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
                CreatedByApiKey = new()
                {
                    ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    Description = "Production API Key",
                    IsViewerEnabled = true,
                },
                CreatedByUser = new()
                {
                    Email = "dr.smith@radiology.com",
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    FirstName = "John",
                    LastName = "Smith",
                    MiddleName = "Robert",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
                ExpressCustomer = new()
                {
                    ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                    ExpressCustomerName = "City Medical Center",
                },
                Metadata = new Dictionary<string, string>()
                {
                    { "department", "radiology" },
                    { "priority", "routine" },
                },
                PriorReportTexts = ["Previous imaging shows stable findings."],
                PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                ReportIds =
                [
                    new()
                    {
                        ReportID = "rep_1234567890abcdef1234567890abcdef",
                        Status = Status.InProgress,
                    },
                ],
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedStudies.Count, deserialized.Studies.Count);
        for (int i = 0; i < expectedStudies.Count; i++)
        {
            Assert.Equal(expectedStudies[i], deserialized.Studies[i]);
        }
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
            Cursor = "cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListPageResponse
        {
            HasMore = true,
            Studies =
            [
                new()
                {
                    CancelledAt = null,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
                    IsCancelled = false,
                    ReportMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        ScanDate = "2024-03-15",
                        ScanTime = "14:30",
                        ScanType = "MRI Brain with Contrast",
                        Sex = AutoScribe::Sex.Female,
                        Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
                    },
                    Severity = StudyListResponseSeverity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
                    AssignedTo = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsViewerEnabled = true,
                    },
                    CreatedByUser = new()
                    {
                        Email = "dr.smith@radiology.com",
                        UserID = "usr_1234567890abcdef1234567890abcdef",
                        FirstName = "John",
                        LastName = "Smith",
                        MiddleName = "Robert",
                        Suffix1 = "MD",
                        Suffix2 = "FACR",
                    },
                    ExpressCustomer = new()
                    {
                        ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
                        ExpressCustomerName = "City Medical Center",
                    },
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    PriorReportTexts = ["Previous imaging shows stable findings."],
                    PriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"],
                    ReportIds =
                    [
                        new()
                        {
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = Status.InProgress,
                        },
                    ],
                },
            ],
            Cursor = "cursor",
        };

        StudyListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
