using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Users.Invitations;

namespace Avara.Tests.Models.AutoScribe.Users.Invitations;

public class InvitationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        bool expectedCanCreateReports = true;
        bool expectedCanManageStudies = true;
        string expectedClinicID = "550e8400-e29b-41d4-a716-446655440000";
        ApiEnum<string, InvitationListResponseClinicRole> expectedClinicRole =
            InvitationListResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitationListResponseInvitedSource> expectedInvitedSource =
            InvitationListResponseInvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationListResponseLevel> expectedLevel =
            InvitationListResponseLevel.Member;
        ApiEnum<string, InvitationListResponseStatus> expectedStatus =
            InvitationListResponseStatus.Sent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedInvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedMiddleName = "David";
        string expectedNpiNumber = "1234567893";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";

        Assert.Equal(expectedCanCreateReports, model.CanCreateReports);
        Assert.Equal(expectedCanManageStudies, model.CanManageStudies);
        Assert.Equal(expectedClinicID, model.ClinicID);
        Assert.Equal(expectedClinicRole, model.ClinicRole);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedExpiry, model.Expiry);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedHasDashboardAccess, model.HasDashboardAccess);
        Assert.Equal(expectedInvitationID, model.InvitationID);
        Assert.Equal(expectedInvitedSource, model.InvitedSource);
        Assert.Equal(expectedInviterID, model.InviterID);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedLevel, model.Level);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedInvitedByApiKeyID, model.InvitedByApiKeyID);
        Assert.Equal(expectedMiddleName, model.MiddleName);
        Assert.Equal(expectedNpiNumber, model.NpiNumber);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSuffix1, model.Suffix1);
        Assert.Null(model.Suffix2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanCreateReports = true;
        bool expectedCanManageStudies = true;
        string expectedClinicID = "550e8400-e29b-41d4-a716-446655440000";
        ApiEnum<string, InvitationListResponseClinicRole> expectedClinicRole =
            InvitationListResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitationListResponseInvitedSource> expectedInvitedSource =
            InvitationListResponseInvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationListResponseLevel> expectedLevel =
            InvitationListResponseLevel.Member;
        ApiEnum<string, InvitationListResponseStatus> expectedStatus =
            InvitationListResponseStatus.Sent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedInvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedMiddleName = "David";
        string expectedNpiNumber = "1234567893";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";

        Assert.Equal(expectedCanCreateReports, deserialized.CanCreateReports);
        Assert.Equal(expectedCanManageStudies, deserialized.CanManageStudies);
        Assert.Equal(expectedClinicID, deserialized.ClinicID);
        Assert.Equal(expectedClinicRole, deserialized.ClinicRole);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedExpiry, deserialized.Expiry);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedHasDashboardAccess, deserialized.HasDashboardAccess);
        Assert.Equal(expectedInvitationID, deserialized.InvitationID);
        Assert.Equal(expectedInvitedSource, deserialized.InvitedSource);
        Assert.Equal(expectedInviterID, deserialized.InviterID);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedLevel, deserialized.Level);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedInvitedByApiKeyID, deserialized.InvitedByApiKeyID);
        Assert.Equal(expectedMiddleName, deserialized.MiddleName);
        Assert.Equal(expectedNpiNumber, deserialized.NpiNumber);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSuffix1, deserialized.Suffix1);
        Assert.Null(deserialized.Suffix2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        Assert.Null(model.InvitedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("invitedByApiKeyId"));
        Assert.Null(model.NpiNumber);
        Assert.False(model.RawData.ContainsKey("npiNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,

            // Null should be interpreted as omitted for these properties
            InvitedByApiKeyID = null,
            NpiNumber = null,
        };

        Assert.Null(model.InvitedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("invitedByApiKeyId"));
        Assert.Null(model.NpiNumber);
        Assert.False(model.RawData.ContainsKey("npiNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,

            // Null should be interpreted as omitted for these properties
            InvitedByApiKeyID = null,
            NpiNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            NpiNumber = "1234567893",
        };

        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.Suffix1);
        Assert.False(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.False(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            NpiNumber = "1234567893",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            NpiNumber = "1234567893",

            MiddleName = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(model.MiddleName);
        Assert.True(model.RawData.ContainsKey("middleName"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.Suffix1);
        Assert.True(model.RawData.ContainsKey("suffix1"));
        Assert.Null(model.Suffix2);
        Assert.True(model.RawData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            NpiNumber = "1234567893",

            MiddleName = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvitationListResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationListResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationListResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationListResponseLevel.Member,
            Status = InvitationListResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        InvitationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvitationListResponseClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(InvitationListResponseClinicRole.Radiologist)]
    [InlineData(InvitationListResponseClinicRole.Cardiologist)]
    [InlineData(InvitationListResponseClinicRole.Neurologist)]
    [InlineData(InvitationListResponseClinicRole.Urologist)]
    [InlineData(InvitationListResponseClinicRole.Gynecologist)]
    [InlineData(InvitationListResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationListResponseClinicRole.Doctor)]
    [InlineData(InvitationListResponseClinicRole.Surgeon)]
    [InlineData(InvitationListResponseClinicRole.Physician)]
    [InlineData(InvitationListResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationListResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationListResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationListResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationListResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationListResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationListResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationListResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationListResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationListResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationListResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationListResponseClinicRole.Other)]
    public void Validation_Works(InvitationListResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationListResponseClinicRole.Radiologist)]
    [InlineData(InvitationListResponseClinicRole.Cardiologist)]
    [InlineData(InvitationListResponseClinicRole.Neurologist)]
    [InlineData(InvitationListResponseClinicRole.Urologist)]
    [InlineData(InvitationListResponseClinicRole.Gynecologist)]
    [InlineData(InvitationListResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationListResponseClinicRole.Doctor)]
    [InlineData(InvitationListResponseClinicRole.Surgeon)]
    [InlineData(InvitationListResponseClinicRole.Physician)]
    [InlineData(InvitationListResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationListResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationListResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationListResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationListResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationListResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationListResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationListResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationListResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationListResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationListResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationListResponseClinicRole.Other)]
    public void SerializationRoundtrip_Works(InvitationListResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationListResponseInvitedSourceTest : TestBase
{
    [Theory]
    [InlineData(InvitationListResponseInvitedSource.Dashboard)]
    [InlineData(InvitationListResponseInvitedSource.Api)]
    public void Validation_Works(InvitationListResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseInvitedSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseInvitedSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationListResponseInvitedSource.Dashboard)]
    [InlineData(InvitationListResponseInvitedSource.Api)]
    public void SerializationRoundtrip_Works(InvitationListResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseInvitedSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseInvitedSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationListResponseLevelTest : TestBase
{
    [Theory]
    [InlineData(InvitationListResponseLevel.Owner)]
    [InlineData(InvitationListResponseLevel.Admin)]
    [InlineData(InvitationListResponseLevel.Member)]
    public void Validation_Works(InvitationListResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationListResponseLevel.Owner)]
    [InlineData(InvitationListResponseLevel.Admin)]
    [InlineData(InvitationListResponseLevel.Member)]
    public void SerializationRoundtrip_Works(InvitationListResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvitationListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(InvitationListResponseStatus.Sent)]
    [InlineData(InvitationListResponseStatus.Accepted)]
    [InlineData(InvitationListResponseStatus.Rejected)]
    [InlineData(InvitationListResponseStatus.Revoked)]
    public void Validation_Works(InvitationListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationListResponseStatus.Sent)]
    [InlineData(InvitationListResponseStatus.Accepted)]
    [InlineData(InvitationListResponseStatus.Rejected)]
    [InlineData(InvitationListResponseStatus.Revoked)]
    public void SerializationRoundtrip_Works(InvitationListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
