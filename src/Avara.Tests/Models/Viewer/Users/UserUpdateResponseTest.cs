using System;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        bool expectedCanManageStudies = true;
        ApiEnum<string, ClinicRole> expectedClinicRole = ClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z");
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        ApiEnum<string, InvitedSource> expectedInvitedSource = InvitedSource.Api;
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z");
        string expectedLastName = "Johnson";
        ApiEnum<string, UserLevel> expectedLevel = UserLevel.Member;
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedMiddleName = "Marie";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedCanManageStudies, model.CanManageStudies);
        Assert.Equal(expectedClinicRole, model.ClinicRole);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedHasDashboardAccess, model.HasDashboardAccess);
        Assert.Equal(expectedInvitedSource, model.InvitedSource);
        Assert.Equal(expectedLastLoginAt, model.LastLoginAt);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedLevel, model.Level);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedMiddleName, model.MiddleName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSuffix1, model.Suffix1);
        Assert.Equal(expectedSuffix2, model.Suffix2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanManageStudies = true;
        ApiEnum<string, ClinicRole> expectedClinicRole = ClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z");
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        ApiEnum<string, InvitedSource> expectedInvitedSource = InvitedSource.Api;
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z");
        string expectedLastName = "Johnson";
        ApiEnum<string, UserLevel> expectedLevel = UserLevel.Member;
        string expectedUserID = "usr_1234567890abcdef1234567890abcdef";
        string expectedMiddleName = "Marie";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedCanManageStudies, deserialized.CanManageStudies);
        Assert.Equal(expectedClinicRole, deserialized.ClinicRole);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedHasDashboardAccess, deserialized.HasDashboardAccess);
        Assert.Equal(expectedInvitedSource, deserialized.InvitedSource);
        Assert.Equal(expectedLastLoginAt, deserialized.LastLoginAt);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedLevel, deserialized.Level);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedMiddleName, deserialized.MiddleName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSuffix1, deserialized.Suffix1);
        Assert.Equal(expectedSuffix2, deserialized.Suffix2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
            MiddleName = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
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
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",

            // Null should be interpreted as omitted for these properties
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
        var model = new UserUpdateResponse
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = InvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        UserUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
