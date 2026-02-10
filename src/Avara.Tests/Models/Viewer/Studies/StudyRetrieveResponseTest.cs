using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Models.Viewer.Studies;

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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
                { "priority", "urgent" },
            },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        ApiEnum<string, StudyRetrieveResponseSeverity> expectedSeverity =
            StudyRetrieveResponseSeverity.High;
        string expectedStudyDescription = "CT Chest/Abdomen/Pelvis";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyRetrieveResponseStudyViewerStatus> expectedStudyViewerStatus =
            StudyRetrieveResponseStudyViewerStatus.Incomplete;
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
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "urgent" },
        };

        Assert.Null(model.CancelledAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsCancelled, model.IsCancelled);
        Assert.Equal(expectedSeverity, model.Severity);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedStudyViewerStatus, model.StudyViewerStatus);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyRetrieveResponse
        {
            CancelledAt = null,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
            IsCancelled = false,
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
                { "priority", "urgent" },
            },
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
                { "priority", "urgent" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z");
        bool expectedIsCancelled = false;
        ApiEnum<string, StudyRetrieveResponseSeverity> expectedSeverity =
            StudyRetrieveResponseSeverity.High;
        string expectedStudyDescription = "CT Chest/Abdomen/Pelvis";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        ApiEnum<string, StudyRetrieveResponseStudyViewerStatus> expectedStudyViewerStatus =
            StudyRetrieveResponseStudyViewerStatus.Incomplete;
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
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "urgent" },
        };

        Assert.Null(deserialized.CancelledAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsCancelled, deserialized.IsCancelled);
        Assert.Equal(expectedSeverity, deserialized.Severity);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedStudyViewerStatus, deserialized.StudyViewerStatus);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyRetrieveResponse
        {
            CancelledAt = null,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
            IsCancelled = false,
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
                { "priority", "urgent" },
            },
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyRetrieveResponse
        {
            CancelledAt = null,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
            IsCancelled = false,
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyRetrieveResponse
        {
            CancelledAt = null,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:30:00Z"),
            IsCancelled = false,
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "urgent" },
            },
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "urgent" },
            },
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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "urgent" },
            },

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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T14:20:00Z"),
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "urgent" },
            },

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
            Severity = StudyRetrieveResponseSeverity.High,
            StudyDescription = "CT Chest/Abdomen/Pelvis",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            StudyViewerStatus = StudyRetrieveResponseStudyViewerStatus.Incomplete,
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
                { "priority", "urgent" },
            },
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

public class StudyRetrieveResponseStudyViewerStatusTest : TestBase
{
    [Theory]
    [InlineData(StudyRetrieveResponseStudyViewerStatus.Incomplete)]
    [InlineData(StudyRetrieveResponseStudyViewerStatus.Complete)]
    public void Validation_Works(StudyRetrieveResponseStudyViewerStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseStudyViewerStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyViewerStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyRetrieveResponseStudyViewerStatus.Incomplete)]
    [InlineData(StudyRetrieveResponseStudyViewerStatus.Complete)]
    public void SerializationRoundtrip_Works(StudyRetrieveResponseStudyViewerStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyRetrieveResponseStudyViewerStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyViewerStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyViewerStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, StudyRetrieveResponseStudyViewerStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
