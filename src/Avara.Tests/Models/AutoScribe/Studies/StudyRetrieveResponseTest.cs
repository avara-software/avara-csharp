using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies;
using AutoScribe = Avara.Models.AutoScribe;

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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
            ReferringPhysicianName = "Dr. Michael Chen",
            ScanDate = "2024-03-15",
            ScanTime = "14:30",
            ScanType = "MRI Brain with Contrast",
            Sex = AutoScribe::Sex.Female,
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, StudyRetrieveResponseSeverity> expectedSeverity =
            StudyRetrieveResponseSeverity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyRetrieveResponseStudyReportStatus> expectedStudyReportStatus =
            StudyRetrieveResponseStudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        StudyRetrieveResponseAssignedTo expectedAssignedTo = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyRetrieveResponseCreatedByApiKey expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        StudyRetrieveResponseCreatedByUser expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyRetrieveResponseExpressCustomer expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        List<string> expectedPriorReportTexts = ["Previous imaging shows stable findings."];
        List<string> expectedPriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"];
        List<ReportIDWithStatus> expectedReportIds =
        [
            new() { ReportID = "rep_1234567890abcdef1234567890abcdef", Status = Status.InProgress },
        ];

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
        Assert.Equal(expectedCreatedByApiKey, model.CreatedByApiKey);
        Assert.Equal(expectedCreatedByUser, model.CreatedByUser);
        Assert.Equal(expectedExpressCustomer, model.ExpressCustomer);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.NotNull(model.PriorReportTexts);
        Assert.Equal(expectedPriorReportTexts.Count, model.PriorReportTexts.Count);
        for (int i = 0; i < expectedPriorReportTexts.Count; i++)
        {
            Assert.Equal(expectedPriorReportTexts[i], model.PriorReportTexts[i]);
        }
        Assert.NotNull(model.PriorStudyIds);
        Assert.Equal(expectedPriorStudyIds.Count, model.PriorStudyIds.Count);
        for (int i = 0; i < expectedPriorStudyIds.Count; i++)
        {
            Assert.Equal(expectedPriorStudyIds[i], model.PriorStudyIds[i]);
        }
        Assert.NotNull(model.ReportIds);
        Assert.Equal(expectedReportIds.Count, model.ReportIds.Count);
        for (int i = 0; i < expectedReportIds.Count; i++)
        {
            Assert.Equal(expectedReportIds[i], model.ReportIds[i]);
        }
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponse>(
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
            ReferringPhysicianName = "Dr. Michael Chen",
            ScanDate = "2024-03-15",
            ScanTime = "14:30",
            ScanType = "MRI Brain with Contrast",
            Sex = AutoScribe::Sex.Female,
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, StudyRetrieveResponseSeverity> expectedSeverity =
            StudyRetrieveResponseSeverity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyRetrieveResponseStudyReportStatus> expectedStudyReportStatus =
            StudyRetrieveResponseStudyReportStatus.InProgress;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z");
        StudyRetrieveResponseAssignedTo expectedAssignedTo = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyRetrieveResponseCreatedByApiKey expectedCreatedByApiKey = new()
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };
        StudyRetrieveResponseCreatedByUser expectedCreatedByUser = new()
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };
        StudyRetrieveResponseExpressCustomer expectedExpressCustomer = new()
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        List<string> expectedPriorReportTexts = ["Previous imaging shows stable findings."];
        List<string> expectedPriorStudyIds = ["stu_abcdef1234567890abcdef1234567890"];
        List<ReportIDWithStatus> expectedReportIds =
        [
            new() { ReportID = "rep_1234567890abcdef1234567890abcdef", Status = Status.InProgress },
        ];

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
        Assert.Equal(expectedCreatedByApiKey, deserialized.CreatedByApiKey);
        Assert.Equal(expectedCreatedByUser, deserialized.CreatedByUser);
        Assert.Equal(expectedExpressCustomer, deserialized.ExpressCustomer);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.NotNull(deserialized.PriorReportTexts);
        Assert.Equal(expectedPriorReportTexts.Count, deserialized.PriorReportTexts.Count);
        for (int i = 0; i < expectedPriorReportTexts.Count; i++)
        {
            Assert.Equal(expectedPriorReportTexts[i], deserialized.PriorReportTexts[i]);
        }
        Assert.NotNull(deserialized.PriorStudyIds);
        Assert.Equal(expectedPriorStudyIds.Count, deserialized.PriorStudyIds.Count);
        for (int i = 0; i < expectedPriorStudyIds.Count; i++)
        {
            Assert.Equal(expectedPriorStudyIds[i], deserialized.PriorStudyIds[i]);
        }
        Assert.NotNull(deserialized.ReportIds);
        Assert.Equal(expectedReportIds.Count, deserialized.ReportIds.Count);
        for (int i = 0; i < expectedReportIds.Count; i++)
        {
            Assert.Equal(expectedReportIds[i], deserialized.ReportIds[i]);
        }
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PriorReportTexts);
        Assert.False(model.RawData.ContainsKey("priorReportTexts"));
        Assert.Null(model.PriorStudyIds);
        Assert.False(model.RawData.ContainsKey("priorStudyIds"));
        Assert.Null(model.ReportIds);
        Assert.False(model.RawData.ContainsKey("reportIds"));
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            PriorReportTexts = null,
            PriorStudyIds = null,
            ReportIds = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PriorReportTexts);
        Assert.False(model.RawData.ContainsKey("priorReportTexts"));
        Assert.Null(model.PriorStudyIds);
        Assert.False(model.RawData.ContainsKey("priorStudyIds"));
        Assert.Null(model.ReportIds);
        Assert.False(model.RawData.ContainsKey("reportIds"));
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            PriorReportTexts = null,
            PriorStudyIds = null,
            ReportIds = null,
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
        };

        Assert.Null(model.AssignedTo);
        Assert.False(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CreatedByApiKey);
        Assert.False(model.RawData.ContainsKey("createdByApiKey"));
        Assert.Null(model.CreatedByUser);
        Assert.False(model.RawData.ContainsKey("createdByUser"));
        Assert.Null(model.ExpressCustomer);
        Assert.False(model.RawData.ContainsKey("expressCustomer"));
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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

            AssignedTo = null,
            CreatedByApiKey = null,
            CreatedByUser = null,
            ExpressCustomer = null,
        };

        Assert.Null(model.AssignedTo);
        Assert.True(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CreatedByApiKey);
        Assert.True(model.RawData.ContainsKey("createdByApiKey"));
        Assert.Null(model.CreatedByUser);
        Assert.True(model.RawData.ContainsKey("createdByUser"));
        Assert.Null(model.ExpressCustomer);
        Assert.True(model.RawData.ContainsKey("expressCustomer"));
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
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

            AssignedTo = null,
            CreatedByApiKey = null,
            CreatedByUser = null,
            ExpressCustomer = null,
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
            Severity = StudyRetrieveResponseSeverity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyReportStatus = StudyRetrieveResponseStudyReportStatus.InProgress,
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
        };

        StudyRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyRetrieveResponseSeverityTest : TestBase
{
    [Theory]
    [InlineData(StudyRetrieveResponseSeverity.Normal)]
    [InlineData(StudyRetrieveResponseSeverity.High)]
    [InlineData(StudyRetrieveResponseSeverity.Stat)]
    public void Validation_Works(StudyRetrieveResponseSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseSeverity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyRetrieveResponseSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyRetrieveResponseSeverity.Normal)]
    [InlineData(StudyRetrieveResponseSeverity.High)]
    [InlineData(StudyRetrieveResponseSeverity.Stat)]
    public void SerializationRoundtrip_Works(StudyRetrieveResponseSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseSeverity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseSeverity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyRetrieveResponseSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseSeverity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StudyRetrieveResponseStudyReportStatusTest : TestBase
{
    [Theory]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Unassigned)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Assigned)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.InProgress)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Completed)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.AddendumActive)]
    public void Validation_Works(StudyRetrieveResponseStudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseStudyReportStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyReportStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Unassigned)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Assigned)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.InProgress)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.Completed)]
    [InlineData(StudyRetrieveResponseStudyReportStatus.AddendumActive)]
    public void SerializationRoundtrip_Works(StudyRetrieveResponseStudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseStudyReportStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyReportStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyReportStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyReportStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StudyRetrieveResponseAssignedToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyRetrieveResponseAssignedTo
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
        var model = new StudyRetrieveResponseAssignedTo
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
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseAssignedTo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyRetrieveResponseAssignedTo
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
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseAssignedTo>(
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
        var model = new StudyRetrieveResponseAssignedTo
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
        var model = new StudyRetrieveResponseAssignedTo
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
        var model = new StudyRetrieveResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyRetrieveResponseAssignedTo
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
        var model = new StudyRetrieveResponseAssignedTo
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
        var model = new StudyRetrieveResponseAssignedTo
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        StudyRetrieveResponseAssignedTo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyRetrieveResponseCreatedByApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyRetrieveResponseCreatedByApiKey
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
        var model = new StudyRetrieveResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseCreatedByApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyRetrieveResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseCreatedByApiKey>(
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
        var model = new StudyRetrieveResponseCreatedByApiKey
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
        var model = new StudyRetrieveResponseCreatedByApiKey
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
        var model = new StudyRetrieveResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyRetrieveResponseCreatedByApiKey
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
        var model = new StudyRetrieveResponseCreatedByApiKey
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
        var model = new StudyRetrieveResponseCreatedByApiKey
        {
            ApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            Description = "Production API Key",
            IsViewerEnabled = true,
        };

        StudyRetrieveResponseCreatedByApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyRetrieveResponseCreatedByUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyRetrieveResponseCreatedByUser
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
        var model = new StudyRetrieveResponseCreatedByUser
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
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseCreatedByUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyRetrieveResponseCreatedByUser
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
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseCreatedByUser>(
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
        var model = new StudyRetrieveResponseCreatedByUser
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
        var model = new StudyRetrieveResponseCreatedByUser
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
        var model = new StudyRetrieveResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyRetrieveResponseCreatedByUser
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
        var model = new StudyRetrieveResponseCreatedByUser
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
        var model = new StudyRetrieveResponseCreatedByUser
        {
            Email = "dr.smith@radiology.com",
            UserID = "usr_1234567890abcdef1234567890abcdef",
            FirstName = "John",
            LastName = "Smith",
            MiddleName = "Robert",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        StudyRetrieveResponseCreatedByUser copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StudyRetrieveResponseExpressCustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyRetrieveResponseExpressCustomer
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
        var model = new StudyRetrieveResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseExpressCustomer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyRetrieveResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponseExpressCustomer>(
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
        var model = new StudyRetrieveResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyRetrieveResponseExpressCustomer
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        StudyRetrieveResponseExpressCustomer copied = new(model);

        Assert.Equal(model, copied);
    }
}
