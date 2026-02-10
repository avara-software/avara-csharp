using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserInviteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        bool expectedCanManageStudies = true;
        ApiEnum<string, UserInviteResponseClinicRole> expectedClinicRole =
            UserInviteResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z");
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        ApiEnum<string, UserInviteResponseInvitedSource> expectedInvitedSource =
            UserInviteResponseInvitedSource.Api;
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z");
        string expectedLastName = "Johnson";
        ApiEnum<string, UserInviteResponseLevel> expectedLevel = UserInviteResponseLevel.Member;
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInviteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInviteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanManageStudies = true;
        ApiEnum<string, UserInviteResponseClinicRole> expectedClinicRole =
            UserInviteResponseClinicRole.Radiologist;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z");
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        ApiEnum<string, UserInviteResponseInvitedSource> expectedInvitedSource =
            UserInviteResponseInvitedSource.Api;
        DateTimeOffset expectedLastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z");
        string expectedLastName = "Johnson";
        ApiEnum<string, UserInviteResponseLevel> expectedLevel = UserInviteResponseLevel.Member;
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
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
        var model = new UserInviteResponse
        {
            CanManageStudies = true,
            ClinicRole = UserInviteResponseClinicRole.Radiologist,
            CreatedAt = DateTimeOffset.Parse("2024-01-15T10:00:00Z"),
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            InvitedSource = UserInviteResponseInvitedSource.Api,
            LastLoginAt = DateTimeOffset.Parse("2024-03-15T09:00:00Z"),
            LastName = "Johnson",
            Level = UserInviteResponseLevel.Member,
            UserID = "usr_1234567890abcdef1234567890abcdef",
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        UserInviteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserInviteResponseClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(UserInviteResponseClinicRole.Radiologist)]
    [InlineData(UserInviteResponseClinicRole.Cardiologist)]
    [InlineData(UserInviteResponseClinicRole.Neurologist)]
    [InlineData(UserInviteResponseClinicRole.Urologist)]
    [InlineData(UserInviteResponseClinicRole.Gynecologist)]
    [InlineData(UserInviteResponseClinicRole.Endocrinologist)]
    [InlineData(UserInviteResponseClinicRole.Doctor)]
    [InlineData(UserInviteResponseClinicRole.Surgeon)]
    [InlineData(UserInviteResponseClinicRole.Physician)]
    [InlineData(UserInviteResponseClinicRole.PhysicianAssistant)]
    [InlineData(UserInviteResponseClinicRole.NursePractitioner)]
    [InlineData(UserInviteResponseClinicRole.RegisteredNurse)]
    [InlineData(UserInviteResponseClinicRole.PatientCareCoordinator)]
    [InlineData(UserInviteResponseClinicRole.FrontDeskOperator)]
    [InlineData(UserInviteResponseClinicRole.ImagingTechnologist)]
    [InlineData(UserInviteResponseClinicRole.PacsAdministrator)]
    [InlineData(UserInviteResponseClinicRole.SoftwareEngineer)]
    [InlineData(UserInviteResponseClinicRole.RevenueCycleManager)]
    [InlineData(UserInviteResponseClinicRole.AdministrativeDirector)]
    [InlineData(UserInviteResponseClinicRole.AdministrativeAssistant)]
    [InlineData(UserInviteResponseClinicRole.Other)]
    public void Validation_Works(UserInviteResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInviteResponseClinicRole.Radiologist)]
    [InlineData(UserInviteResponseClinicRole.Cardiologist)]
    [InlineData(UserInviteResponseClinicRole.Neurologist)]
    [InlineData(UserInviteResponseClinicRole.Urologist)]
    [InlineData(UserInviteResponseClinicRole.Gynecologist)]
    [InlineData(UserInviteResponseClinicRole.Endocrinologist)]
    [InlineData(UserInviteResponseClinicRole.Doctor)]
    [InlineData(UserInviteResponseClinicRole.Surgeon)]
    [InlineData(UserInviteResponseClinicRole.Physician)]
    [InlineData(UserInviteResponseClinicRole.PhysicianAssistant)]
    [InlineData(UserInviteResponseClinicRole.NursePractitioner)]
    [InlineData(UserInviteResponseClinicRole.RegisteredNurse)]
    [InlineData(UserInviteResponseClinicRole.PatientCareCoordinator)]
    [InlineData(UserInviteResponseClinicRole.FrontDeskOperator)]
    [InlineData(UserInviteResponseClinicRole.ImagingTechnologist)]
    [InlineData(UserInviteResponseClinicRole.PacsAdministrator)]
    [InlineData(UserInviteResponseClinicRole.SoftwareEngineer)]
    [InlineData(UserInviteResponseClinicRole.RevenueCycleManager)]
    [InlineData(UserInviteResponseClinicRole.AdministrativeDirector)]
    [InlineData(UserInviteResponseClinicRole.AdministrativeAssistant)]
    [InlineData(UserInviteResponseClinicRole.Other)]
    public void SerializationRoundtrip_Works(UserInviteResponseClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserInviteResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserInviteResponseClinicRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserInviteResponseInvitedSourceTest : TestBase
{
    [Theory]
    [InlineData(UserInviteResponseInvitedSource.Dashboard)]
    [InlineData(UserInviteResponseInvitedSource.Api)]
    public void Validation_Works(UserInviteResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseInvitedSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseInvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInviteResponseInvitedSource.Dashboard)]
    [InlineData(UserInviteResponseInvitedSource.Api)]
    public void SerializationRoundtrip_Works(UserInviteResponseInvitedSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseInvitedSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserInviteResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseInvitedSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserInviteResponseInvitedSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserInviteResponseLevelTest : TestBase
{
    [Theory]
    [InlineData(UserInviteResponseLevel.Admin)]
    [InlineData(UserInviteResponseLevel.Member)]
    public void Validation_Works(UserInviteResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInviteResponseLevel.Admin)]
    [InlineData(UserInviteResponseLevel.Member)]
    public void SerializationRoundtrip_Works(UserInviteResponseLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteResponseLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteResponseLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
