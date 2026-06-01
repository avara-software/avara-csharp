using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyRetrieveResponse
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
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        StudyReportMetadata expectedReportMetadata = new()
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
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyReportStatus> expectedStudyReportStatus = StudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        UserReference expectedAssignedTo = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        string expectedClinicalHistory = "clinicalHistory";
        string expectedClinicalIndication = "clinicalIndication";
        ApiKeyReference expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        UserReference expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        ExpressCustomerReference expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalPatientID = "externalPatientId";
        bool expectedIsCritical = true;
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "modality";
        List<PriorReport> expectedPriorReports =
        [
            new()
            {
                ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                ExternalStudyID = "EXT-2024-001",
                Modality = "CT",
                StudyDate = "2024-01-15",
                StudyDescription = "CT Chest without contrast",
            },
        ];
        List<ReportIDWithStatus> expectedReportIds =
        [
            new()
            {
                IsCritical = null,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                Status = ReportStatus.InProgress,
            },
        ];
        List<string> expectedTechnologistNotes = ["x"];
        string expectedTechnologistTechnique = "technologistTechnique";

        Assert.Null(model.CancelledAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsCancelled, model.IsCancelled);
        Assert.Equal(expectedReportMetadata, model.ReportMetadata);
        Assert.Equal(expectedSeverity, model.Severity);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedStudyReportStatus, model.StudyReportStatus);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedAssignedTo, model.AssignedTo);
        Assert.Equal(expectedClinicalHistory, model.ClinicalHistory);
        Assert.Equal(expectedClinicalIndication, model.ClinicalIndication);
        Assert.Equal(expectedCreatedByApiKey, model.CreatedByApiKey);
        Assert.Equal(expectedCreatedByUser, model.CreatedByUser);
        Assert.Equal(expectedExpressCustomer, model.ExpressCustomer);
        Assert.Equal(expectedExternalPatientID, model.ExternalPatientID);
        Assert.Equal(expectedIsCritical, model.IsCritical);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedModality, model.Modality);
        Assert.NotNull(model.PriorReports);
        Assert.Equal(expectedPriorReports.Count, model.PriorReports.Count);
        for (int i = 0; i < expectedPriorReports.Count; i++)
        {
            Assert.Equal(expectedPriorReports[i], model.PriorReports[i]);
        }
        Assert.NotNull(model.ReportIds);
        Assert.Equal(expectedReportIds.Count, model.ReportIds.Count);
        for (int i = 0; i < expectedReportIds.Count; i++)
        {
            Assert.Equal(expectedReportIds[i], model.ReportIds[i]);
        }
        Assert.NotNull(model.TechnologistNotes);
        Assert.Equal(expectedTechnologistNotes.Count, model.TechnologistNotes.Count);
        for (int i = 0; i < expectedTechnologistNotes.Count; i++)
        {
            Assert.Equal(expectedTechnologistNotes[i], model.TechnologistNotes[i]);
        }
        Assert.Equal(expectedTechnologistTechnique, model.TechnologistTechnique);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyRetrieveResponse
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
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyRetrieveResponse
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
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        StudyReportMetadata expectedReportMetadata = new()
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
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyReportStatus> expectedStudyReportStatus = StudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        UserReference expectedAssignedTo = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        string expectedClinicalHistory = "clinicalHistory";
        string expectedClinicalIndication = "clinicalIndication";
        ApiKeyReference expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        UserReference expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        ExpressCustomerReference expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalPatientID = "externalPatientId";
        bool expectedIsCritical = true;
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "modality";
        List<PriorReport> expectedPriorReports =
        [
            new()
            {
                ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                ExternalStudyID = "EXT-2024-001",
                Modality = "CT",
                StudyDate = "2024-01-15",
                StudyDescription = "CT Chest without contrast",
            },
        ];
        List<ReportIDWithStatus> expectedReportIds =
        [
            new()
            {
                IsCritical = null,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                Status = ReportStatus.InProgress,
            },
        ];
        List<string> expectedTechnologistNotes = ["x"];
        string expectedTechnologistTechnique = "technologistTechnique";

        Assert.Null(deserialized.CancelledAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsCancelled, deserialized.IsCancelled);
        Assert.Equal(expectedReportMetadata, deserialized.ReportMetadata);
        Assert.Equal(expectedSeverity, deserialized.Severity);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedStudyReportStatus, deserialized.StudyReportStatus);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedAssignedTo, deserialized.AssignedTo);
        Assert.Equal(expectedClinicalHistory, deserialized.ClinicalHistory);
        Assert.Equal(expectedClinicalIndication, deserialized.ClinicalIndication);
        Assert.Equal(expectedCreatedByApiKey, deserialized.CreatedByApiKey);
        Assert.Equal(expectedCreatedByUser, deserialized.CreatedByUser);
        Assert.Equal(expectedExpressCustomer, deserialized.ExpressCustomer);
        Assert.Equal(expectedExternalPatientID, deserialized.ExternalPatientID);
        Assert.Equal(expectedIsCritical, deserialized.IsCritical);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.NotNull(deserialized.PriorReports);
        Assert.Equal(expectedPriorReports.Count, deserialized.PriorReports.Count);
        for (int i = 0; i < expectedPriorReports.Count; i++)
        {
            Assert.Equal(expectedPriorReports[i], deserialized.PriorReports[i]);
        }
        Assert.NotNull(deserialized.ReportIds);
        Assert.Equal(expectedReportIds.Count, deserialized.ReportIds.Count);
        for (int i = 0; i < expectedReportIds.Count; i++)
        {
            Assert.Equal(expectedReportIds[i], deserialized.ReportIds[i]);
        }
        Assert.NotNull(deserialized.TechnologistNotes);
        Assert.Equal(expectedTechnologistNotes.Count, deserialized.TechnologistNotes.Count);
        for (int i = 0; i < expectedTechnologistNotes.Count; i++)
        {
            Assert.Equal(expectedTechnologistNotes[i], deserialized.TechnologistNotes[i]);
        }
        Assert.Equal(expectedTechnologistTechnique, deserialized.TechnologistTechnique);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyRetrieveResponse
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
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyRetrieveResponse
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
            Modality = "modality",
            TechnologistTechnique = "technologistTechnique",
        };

        Assert.Null(model.IsCritical);
        Assert.False(model.RawData.ContainsKey("isCritical"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PriorReports);
        Assert.False(model.RawData.ContainsKey("priorReports"));
        Assert.Null(model.ReportIds);
        Assert.False(model.RawData.ContainsKey("reportIds"));
        Assert.Null(model.TechnologistNotes);
        Assert.False(model.RawData.ContainsKey("technologistNotes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyRetrieveResponse
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
            Modality = "modality",
            TechnologistTechnique = "technologistTechnique",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyRetrieveResponse
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
            Modality = "modality",
            TechnologistTechnique = "technologistTechnique",

            // Null should be interpreted as omitted for these properties
            IsCritical = null,
            Metadata = null,
            PriorReports = null,
            ReportIds = null,
            TechnologistNotes = null,
        };

        Assert.Null(model.IsCritical);
        Assert.False(model.RawData.ContainsKey("isCritical"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PriorReports);
        Assert.False(model.RawData.ContainsKey("priorReports"));
        Assert.Null(model.ReportIds);
        Assert.False(model.RawData.ContainsKey("reportIds"));
        Assert.Null(model.TechnologistNotes);
        Assert.False(model.RawData.ContainsKey("technologistNotes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyRetrieveResponse
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
            Modality = "modality",
            TechnologistTechnique = "technologistTechnique",

            // Null should be interpreted as omitted for these properties
            IsCritical = null,
            Metadata = null,
            PriorReports = null,
            ReportIds = null,
            TechnologistNotes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyRetrieveResponse
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
            IsCritical = true,
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
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
            TechnologistNotes = ["x"],
        };

        Assert.Null(model.AssignedTo);
        Assert.False(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.ClinicalHistory);
        Assert.False(model.RawData.ContainsKey("clinicalHistory"));
        Assert.Null(model.ClinicalIndication);
        Assert.False(model.RawData.ContainsKey("clinicalIndication"));
        Assert.Null(model.CreatedByApiKey);
        Assert.False(model.RawData.ContainsKey("createdByApiKey"));
        Assert.Null(model.CreatedByUser);
        Assert.False(model.RawData.ContainsKey("createdByUser"));
        Assert.Null(model.ExpressCustomer);
        Assert.False(model.RawData.ContainsKey("expressCustomer"));
        Assert.Null(model.ExternalPatientID);
        Assert.False(model.RawData.ContainsKey("externalPatientId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.TechnologistTechnique);
        Assert.False(model.RawData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyRetrieveResponse
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
            IsCritical = true,
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
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
            TechnologistNotes = ["x"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StudyRetrieveResponse
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
            IsCritical = true,
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
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
            TechnologistNotes = ["x"],

            AssignedTo = null,
            ClinicalHistory = null,
            ClinicalIndication = null,
            CreatedByApiKey = null,
            CreatedByUser = null,
            ExpressCustomer = null,
            ExternalPatientID = null,
            Modality = null,
            TechnologistTechnique = null,
        };

        Assert.Null(model.AssignedTo);
        Assert.True(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.ClinicalHistory);
        Assert.True(model.RawData.ContainsKey("clinicalHistory"));
        Assert.Null(model.ClinicalIndication);
        Assert.True(model.RawData.ContainsKey("clinicalIndication"));
        Assert.Null(model.CreatedByApiKey);
        Assert.True(model.RawData.ContainsKey("createdByApiKey"));
        Assert.Null(model.CreatedByUser);
        Assert.True(model.RawData.ContainsKey("createdByUser"));
        Assert.Null(model.ExpressCustomer);
        Assert.True(model.RawData.ContainsKey("expressCustomer"));
        Assert.Null(model.ExternalPatientID);
        Assert.True(model.RawData.ContainsKey("externalPatientId"));
        Assert.Null(model.Modality);
        Assert.True(model.RawData.ContainsKey("modality"));
        Assert.Null(model.TechnologistTechnique);
        Assert.True(model.RawData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyRetrieveResponse
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
            IsCritical = true,
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
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
            TechnologistNotes = ["x"],

            AssignedTo = null,
            ClinicalHistory = null,
            ClinicalIndication = null,
            CreatedByApiKey = null,
            CreatedByUser = null,
            ExpressCustomer = null,
            ExternalPatientID = null,
            Modality = null,
            TechnologistTechnique = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyRetrieveResponse
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
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        StudyRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
