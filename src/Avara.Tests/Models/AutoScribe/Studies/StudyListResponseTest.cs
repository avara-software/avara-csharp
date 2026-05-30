using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies;
using AutoScribe = Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        AutoScribe::StudyReportMetadata expectedReportMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = AutoScribe::Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, StudyListResponseSeverity> expectedSeverity =
            StudyListResponseSeverity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyListResponseStudyReportStatus> expectedStudyReportStatus =
            StudyListResponseStudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        StudyListResponseAssignedTo expectedAssignedTo = new()
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
        StudyListResponseCreatedByApiKey expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        StudyListResponseCreatedByUser expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyListResponseExpressCustomer expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalPatientID = "externalPatientId";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "modality";
        List<StudyListResponsePriorReport> expectedPriorReports =
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
            new() { ReportID = "rep_1234567890abcdef1234567890abcdef", Status = Status.InProgress },
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        AutoScribe::StudyReportMetadata expectedReportMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = AutoScribe::Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, StudyListResponseSeverity> expectedSeverity =
            StudyListResponseSeverity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyListResponseStudyReportStatus> expectedStudyReportStatus =
            StudyListResponseStudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        StudyListResponseAssignedTo expectedAssignedTo = new()
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
        StudyListResponseCreatedByApiKey expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        StudyListResponseCreatedByUser expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyListResponseExpressCustomer expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        string expectedExternalPatientID = "externalPatientId";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "modality";
        List<StudyListResponsePriorReport> expectedPriorReports =
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
            new() { ReportID = "rep_1234567890abcdef1234567890abcdef", Status = Status.InProgress },
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
            Metadata = null,
            PriorReports = null,
            ReportIds = null,
            TechnologistNotes = null,
        };

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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = StudyListResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = StudyListResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
                },
            ],
            TechnologistNotes = ["x"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = StudyListResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = StudyListResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyListResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
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
        var model = new StudyListResponse
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    Status = Status.InProgress,
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        StudyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyListResponseSeverityTest : TestBase
{
    [Theory]
    [InlineData(StudyListResponseSeverity.Normal)]
    [InlineData(StudyListResponseSeverity.High)]
    [InlineData(StudyListResponseSeverity.Stat)]
    public void Validation_Works(StudyListResponseSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListResponseSeverity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyListResponseSeverity.Normal)]
    [InlineData(StudyListResponseSeverity.High)]
    [InlineData(StudyListResponseSeverity.Stat)]
    public void SerializationRoundtrip_Works(StudyListResponseSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListResponseSeverity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StudyListResponseStudyReportStatusTest : TestBase
{
    [Theory]
    [InlineData(StudyListResponseStudyReportStatus.Unassigned)]
    [InlineData(StudyListResponseStudyReportStatus.Assigned)]
    [InlineData(StudyListResponseStudyReportStatus.InProgress)]
    [InlineData(StudyListResponseStudyReportStatus.Completed)]
    [InlineData(StudyListResponseStudyReportStatus.AddendumActive)]
    public void Validation_Works(StudyListResponseStudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListResponseStudyReportStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseStudyReportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyListResponseStudyReportStatus.Unassigned)]
    [InlineData(StudyListResponseStudyReportStatus.Assigned)]
    [InlineData(StudyListResponseStudyReportStatus.InProgress)]
    [InlineData(StudyListResponseStudyReportStatus.Completed)]
    [InlineData(StudyListResponseStudyReportStatus.AddendumActive)]
    public void SerializationRoundtrip_Works(StudyListResponseStudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListResponseStudyReportStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyListResponseStudyReportStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListResponseStudyReportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyListResponseStudyReportStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StudyListResponseAssignedToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string expectedEmail = "dr.smith@radiology.com";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedFirstName = "John";
        string expectedLastName = "Smith";
        string expectedMiddleName = "Robert";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMiddleName, model.MiddleName);
        Assert.Equal(expectedSuffix1, model.Suffix1);
        Assert.Equal(expectedSuffix2, model.Suffix2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseAssignedTo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseAssignedTo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dr.smith@radiology.com";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedFirstName = "John";
        string expectedLastName = "Smith";
        string expectedMiddleName = "Robert";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMiddleName, deserialized.MiddleName);
        Assert.Equal(expectedSuffix1, deserialized.Suffix1);
        Assert.Equal(expectedSuffix2, deserialized.Suffix2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.Suffix1);
        Assert.False(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.False(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            FirstName = null,
            LastName = null,
            MiddleName = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.Suffix1);
        Assert.False(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.False(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            FirstName = null,
            LastName = null,
            MiddleName = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        StudyListResponseAssignedTo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyListResponseCreatedByApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        string expectedApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedDescription = "Production API Key";
        bool expectedIsViewerEnabled = true;

        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedIsViewerEnabled, model.IsViewerEnabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseCreatedByApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseCreatedByApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedDescription = "Production API Key";
        bool expectedIsViewerEnabled = true;

        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedIsViewerEnabled, deserialized.IsViewerEnabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
        };

        Assert.Null(model.IsViewerEnabled);
        Assert.False(model.RawData.ContainsKey("isViewerEnabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",

            // Null should be interpreted as omitted for these properties
            IsViewerEnabled = null,
        };

        Assert.Null(model.IsViewerEnabled);
        Assert.False(model.RawData.ContainsKey("isViewerEnabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",

            // Null should be interpreted as omitted for these properties
            IsViewerEnabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        StudyListResponseCreatedByApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyListResponseCreatedByUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string expectedEmail = "dr.smith@radiology.com";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedFirstName = "John";
        string expectedLastName = "Smith";
        string expectedMiddleName = "Robert";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMiddleName, model.MiddleName);
        Assert.Equal(expectedSuffix1, model.Suffix1);
        Assert.Equal(expectedSuffix2, model.Suffix2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseCreatedByUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseCreatedByUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "dr.smith@radiology.com";
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedFirstName = "John";
        string expectedLastName = "Smith";
        string expectedMiddleName = "Robert";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMiddleName, deserialized.MiddleName);
        Assert.Equal(expectedSuffix1, deserialized.Suffix1);
        Assert.Equal(expectedSuffix2, deserialized.Suffix2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.Suffix1);
        Assert.False(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.False(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            FirstName = null,
            LastName = null,
            MiddleName = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.Suffix1);
        Assert.False(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.False(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            FirstName = null,
            LastName = null,
            MiddleName = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        StudyListResponseCreatedByUser copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyListResponseExpressCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center";

        Assert.Equal(expectedExpressCustomerID, model.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, model.ExpressCustomerName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseExpressCustomer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponseExpressCustomer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center";

        Assert.Equal(expectedExpressCustomerID, deserialized.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, deserialized.ExpressCustomerName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        StudyListResponseExpressCustomer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyListResponsePriorReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, model.ReportText);
        Assert.Equal(expectedExternalStudyID, model.ExternalStudyID);
        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedStudyDate, model.StudyDate);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponsePriorReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyListResponsePriorReport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, deserialized.ReportText);
        Assert.Equal(expectedExternalStudyID, deserialized.ExternalStudyID);
        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedStudyDate, deserialized.StudyDate);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyListResponsePriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        StudyListResponsePriorReport copied = new(model);

        Assert.Equal(model, copied);
    }
}
