using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Users.Invitations;

namespace Avara.Tests.Models.AutoScribe.Users.Invitations;

public class InvitationRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        ApiEnum<string, InvitationRetrieveResponseClinicRole> expectedClinicRole =
            InvitationRetrieveResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitedSource> expectedInvitedSource = InvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationRetrieveResponseLevel> expectedLevel =
            InvitationRetrieveResponseLevel.Member;
        ApiEnum<string, InvitationRetrieveResponseStatus> expectedStatus =
            InvitationRetrieveResponseStatus.Sent;
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var deserialized = JsonSerializer.Deserialize<InvitationRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var deserialized = JsonSerializer.Deserialize<InvitationRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanCreateReports = true;
        bool expectedCanManageStudies = true;
        string expectedClinicID = "550e8400-e29b-41d4-a716-446655440000";
        ApiEnum<string, InvitationRetrieveResponseClinicRole> expectedClinicRole =
            InvitationRetrieveResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitedSource> expectedInvitedSource = InvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationRetrieveResponseLevel> expectedLevel =
            InvitationRetrieveResponseLevel.Member;
        ApiEnum<string, InvitationRetrieveResponseStatus> expectedStatus =
            InvitationRetrieveResponseStatus.Sent;
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
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
        var model = new InvitationRetrieveResponse
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationRetrieveResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationRetrieveResponseLevel.Member,
            Status = InvitationRetrieveResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        InvitationRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvitationRetrieveResponseClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(InvitationRetrieveResponseClinicRole.Radiologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Cardiologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Neurologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Urologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Gynecologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Doctor)]
    [InlineData(InvitationRetrieveResponseClinicRole.Surgeon)]
    [InlineData(InvitationRetrieveResponseClinicRole.Physician)]
    [InlineData(InvitationRetrieveResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationRetrieveResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationRetrieveResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationRetrieveResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationRetrieveResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationRetrieveResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationRetrieveResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationRetrieveResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationRetrieveResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationRetrieveResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationRetrieveResponseClinicRole.Other)]
    public void Validation_Works(InvitationRetrieveResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseClinicRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationRetrieveResponseClinicRole.Radiologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Cardiologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Neurologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Urologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Gynecologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.Doctor)]
    [InlineData(InvitationRetrieveResponseClinicRole.Surgeon)]
    [InlineData(InvitationRetrieveResponseClinicRole.Physician)]
    [InlineData(InvitationRetrieveResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationRetrieveResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationRetrieveResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationRetrieveResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationRetrieveResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationRetrieveResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationRetrieveResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationRetrieveResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationRetrieveResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationRetrieveResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationRetrieveResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationRetrieveResponseClinicRole.Other)]
    public void SerializationRoundtrip_Works(InvitationRetrieveResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseClinicRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitedSourceTest : TestBase
{
    [Theory]
    [InlineData(InvitedSource.Dashboard)]
    [InlineData(InvitedSource.Api)]
    public void Validation_Works(InvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitedSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitedSource.Dashboard)]
    [InlineData(InvitedSource.Api)]
    public void SerializationRoundtrip_Works(InvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitedSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitedSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvitationRetrieveResponseLevelTest : TestBase
{
    [Theory]
    [InlineData(InvitationRetrieveResponseLevel.Owner)]
    [InlineData(InvitationRetrieveResponseLevel.Admin)]
    [InlineData(InvitationRetrieveResponseLevel.Member)]
    public void Validation_Works(InvitationRetrieveResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationRetrieveResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationRetrieveResponseLevel.Owner)]
    [InlineData(InvitationRetrieveResponseLevel.Admin)]
    [InlineData(InvitationRetrieveResponseLevel.Member)]
    public void SerializationRoundtrip_Works(InvitationRetrieveResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationRetrieveResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(InvitationRetrieveResponseStatus.Sent)]
    [InlineData(InvitationRetrieveResponseStatus.Accepted)]
    [InlineData(InvitationRetrieveResponseStatus.Rejected)]
    [InlineData(InvitationRetrieveResponseStatus.Revoked)]
    public void Validation_Works(InvitationRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationRetrieveResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationRetrieveResponseStatus.Sent)]
    [InlineData(InvitationRetrieveResponseStatus.Accepted)]
    [InlineData(InvitationRetrieveResponseStatus.Rejected)]
    [InlineData(InvitationRetrieveResponseStatus.Revoked)]
    public void SerializationRoundtrip_Works(InvitationRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationRetrieveResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
