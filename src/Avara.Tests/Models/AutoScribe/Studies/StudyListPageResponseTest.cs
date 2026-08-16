using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Studies;

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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                Severity = Severity.Normal,
                StudyDescription = "Brain MRI with Contrast",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                StudyReportStatus = StudyReportStatus.InProgress,
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
                ClinicalHistory = "clinicalHistory",
                ClinicalIndication = "clinicalIndication",
                CreatedByApiKey = new()
                {
                    ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    Description = "Production API Key",
                    IsClinicalContextEnrichmentEnabled = true,
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
                ExternalPatientID = "externalPatientId",
                ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                IsCritical = true,
                Metadata = new Dictionary<string, string>()
                {
                    { "department", "radiology" },
                    { "priority", "routine" },
                },
                Modality = "modality",
                PriorReports =
                [
                    new()
                    {
                        ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                        ExternalStudyID = "EXT-2024-001",
                        Modality = "CT",
                        StudyDate = "2024-01-15",
                        StudyDescription = "CT Chest without contrast",
                    },
                ],
                ReportIds =
                [
                    new()
                    {
                        IsCritical = null,
                        ReportID = "rep_1234567890abcdef1234567890abcdef",
                        Status = ReportStatus.InProgress,
                    },
                ],
                StudyType = StudyType.Standard,
                TechnologistNotes = ["x"],
                TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                Severity = Severity.Normal,
                StudyDescription = "Brain MRI with Contrast",
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                StudyReportStatus = StudyReportStatus.InProgress,
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
                ClinicalHistory = "clinicalHistory",
                ClinicalIndication = "clinicalIndication",
                CreatedByApiKey = new()
                {
                    ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    Description = "Production API Key",
                    IsClinicalContextEnrichmentEnabled = true,
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
                ExternalPatientID = "externalPatientId",
                ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                IsCritical = true,
                Metadata = new Dictionary<string, string>()
                {
                    { "department", "radiology" },
                    { "priority", "routine" },
                },
                Modality = "modality",
                PriorReports =
                [
                    new()
                    {
                        ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                        ExternalStudyID = "EXT-2024-001",
                        Modality = "CT",
                        StudyDate = "2024-01-15",
                        StudyDescription = "CT Chest without contrast",
                    },
                ],
                ReportIds =
                [
                    new()
                    {
                        IsCritical = null,
                        ReportID = "rep_1234567890abcdef1234567890abcdef",
                        Status = ReportStatus.InProgress,
                    },
                ],
                StudyType = StudyType.Standard,
                TechnologistNotes = ["x"],
                TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
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
                    Severity = Severity.Normal,
                    StudyDescription = "Brain MRI with Contrast",
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    StudyReportStatus = StudyReportStatus.InProgress,
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
                    ClinicalHistory = "clinicalHistory",
                    ClinicalIndication = "clinicalIndication",
                    CreatedByApiKey = new()
                    {
                        ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                        Description = "Production API Key",
                        IsClinicalContextEnrichmentEnabled = true,
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
                    ExternalPatientID = "externalPatientId",
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    IsCritical = true,
                    Metadata = new Dictionary<string, string>()
                    {
                        { "department", "radiology" },
                        { "priority", "routine" },
                    },
                    Modality = "modality",
                    PriorReports =
                    [
                        new()
                        {
                            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                            ExternalStudyID = "EXT-2024-001",
                            Modality = "CT",
                            StudyDate = "2024-01-15",
                            StudyDescription = "CT Chest without contrast",
                        },
                    ],
                    ReportIds =
                    [
                        new()
                        {
                            IsCritical = null,
                            ReportID = "rep_1234567890abcdef1234567890abcdef",
                            Status = ReportStatus.InProgress,
                        },
                    ],
                    StudyType = StudyType.Standard,
                    TechnologistNotes = ["x"],
                    TechnologistTechnique = "technologistTechnique",
                },
            ],
            Cursor = "cursor",
        };

        StudyListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
