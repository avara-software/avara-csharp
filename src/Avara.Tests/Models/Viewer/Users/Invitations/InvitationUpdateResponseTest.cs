using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        bool expectedCanManageStudies = true;
        string expectedClinicID = "550e8400-e29b-41d4-a716-446655440000";
        ApiEnum<string, InvitationUpdateResponseClinicRole> expectedClinicRole =
            InvitationUpdateResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitationUpdateResponseInvitedSource> expectedInvitedSource =
            InvitationUpdateResponseInvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationUpdateResponseLevel> expectedLevel =
            InvitationUpdateResponseLevel.Member;
        ApiEnum<string, InvitationUpdateResponseStatus> expectedStatus =
            InvitationUpdateResponseStatus.Sent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedInvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedMiddleName = "David";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";

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
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSuffix1, model.Suffix1);
        Assert.Null(model.Suffix2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanManageStudies = true;
        string expectedClinicID = "550e8400-e29b-41d4-a716-446655440000";
        ApiEnum<string, InvitationUpdateResponseClinicRole> expectedClinicRole =
            InvitationUpdateResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedEmail = "dr.chen@hospital.org";
        DateTimeOffset expectedExpiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z");
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        ApiEnum<string, InvitationUpdateResponseInvitedSource> expectedInvitedSource =
            InvitationUpdateResponseInvitedSource.Api;
        string expectedInviterID = "usr_1234567890abcdef1234567890abcdef";
        string expectedLastName = "Chen";
        ApiEnum<string, InvitationUpdateResponseLevel> expectedLevel =
            InvitationUpdateResponseLevel.Member;
        ApiEnum<string, InvitationUpdateResponseStatus> expectedStatus =
            InvitationUpdateResponseStatus.Sent;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z");
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedInvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000";
        string expectedMiddleName = "David";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";

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
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSuffix1, deserialized.Suffix1);
        Assert.Null(deserialized.Suffix2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        Assert.Null(model.InvitedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("invitedByApiKeyId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
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
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,

            // Null should be interpreted as omitted for these properties
            InvitedByApiKeyID = null,
        };

        Assert.Null(model.InvitedByApiKeyID);
        Assert.False(model.RawData.ContainsKey("invitedByApiKeyId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,

            // Null should be interpreted as omitted for these properties
            InvitedByApiKeyID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
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
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",

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
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",

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
        var model = new InvitationUpdateResponse
        {
            CanManageStudies = true,
            ClinicID = "550e8400-e29b-41d4-a716-446655440000",
            ClinicRole = InvitationUpdateResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            Email = "dr.chen@hospital.org",
            Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
            FirstName = "Michael",
            HasDashboardAccess = true,
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            InvitedSource = InvitationUpdateResponseInvitedSource.Api,
            InviterID = "usr_1234567890abcdef1234567890abcdef",
            LastName = "Chen",
            Level = InvitationUpdateResponseLevel.Member,
            Status = InvitationUpdateResponseStatus.Sent,
            UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
            UserID = "usr_1234567890abcdef1234567890abcdef",
            InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
            MiddleName = "David",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = null,
        };

        InvitationUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvitationUpdateResponseClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(InvitationUpdateResponseClinicRole.Radiologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Cardiologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Neurologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Urologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Gynecologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Doctor)]
    [InlineData(InvitationUpdateResponseClinicRole.Surgeon)]
    [InlineData(InvitationUpdateResponseClinicRole.Physician)]
    [InlineData(InvitationUpdateResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationUpdateResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationUpdateResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationUpdateResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationUpdateResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationUpdateResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationUpdateResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationUpdateResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationUpdateResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationUpdateResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationUpdateResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationUpdateResponseClinicRole.Other)]
    public void Validation_Works(InvitationUpdateResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationUpdateResponseClinicRole.Radiologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Cardiologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Neurologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Urologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Gynecologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Endocrinologist)]
    [InlineData(InvitationUpdateResponseClinicRole.Doctor)]
    [InlineData(InvitationUpdateResponseClinicRole.Surgeon)]
    [InlineData(InvitationUpdateResponseClinicRole.Physician)]
    [InlineData(InvitationUpdateResponseClinicRole.PhysicianAssistant)]
    [InlineData(InvitationUpdateResponseClinicRole.NursePractitioner)]
    [InlineData(InvitationUpdateResponseClinicRole.RegisteredNurse)]
    [InlineData(InvitationUpdateResponseClinicRole.PatientCareCoordinator)]
    [InlineData(InvitationUpdateResponseClinicRole.FrontDeskOperator)]
    [InlineData(InvitationUpdateResponseClinicRole.ImagingTechnologist)]
    [InlineData(InvitationUpdateResponseClinicRole.PacsAdministrator)]
    [InlineData(InvitationUpdateResponseClinicRole.SoftwareEngineer)]
    [InlineData(InvitationUpdateResponseClinicRole.RevenueCycleManager)]
    [InlineData(InvitationUpdateResponseClinicRole.AdministrativeDirector)]
    [InlineData(InvitationUpdateResponseClinicRole.AdministrativeAssistant)]
    [InlineData(InvitationUpdateResponseClinicRole.Other)]
    public void SerializationRoundtrip_Works(InvitationUpdateResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationUpdateResponseInvitedSourceTest : TestBase
{
    [Theory]
    [InlineData(InvitationUpdateResponseInvitedSource.Dashboard)]
    [InlineData(InvitationUpdateResponseInvitedSource.Api)]
    public void Validation_Works(InvitationUpdateResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseInvitedSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseInvitedSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationUpdateResponseInvitedSource.Dashboard)]
    [InlineData(InvitationUpdateResponseInvitedSource.Api)]
    public void SerializationRoundtrip_Works(InvitationUpdateResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseInvitedSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseInvitedSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationUpdateResponseLevelTest : TestBase
{
    [Theory]
    [InlineData(InvitationUpdateResponseLevel.Owner)]
    [InlineData(InvitationUpdateResponseLevel.Admin)]
    [InlineData(InvitationUpdateResponseLevel.Member)]
    public void Validation_Works(InvitationUpdateResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationUpdateResponseLevel.Owner)]
    [InlineData(InvitationUpdateResponseLevel.Admin)]
    [InlineData(InvitationUpdateResponseLevel.Member)]
    public void SerializationRoundtrip_Works(InvitationUpdateResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvitationUpdateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(InvitationUpdateResponseStatus.Sent)]
    [InlineData(InvitationUpdateResponseStatus.Accepted)]
    [InlineData(InvitationUpdateResponseStatus.Rejected)]
    [InlineData(InvitationUpdateResponseStatus.Revoked)]
    public void Validation_Works(InvitationUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationUpdateResponseStatus.Sent)]
    [InlineData(InvitationUpdateResponseStatus.Accepted)]
    [InlineData(InvitationUpdateResponseStatus.Rejected)]
    [InlineData(InvitationUpdateResponseStatus.Revoked)]
    public void SerializationRoundtrip_Works(InvitationUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationUpdateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvitationUpdateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
