using System;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Models.AutoScribe.Users;

public class UserInviteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserInviteParams
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicRole = UserInviteParamsClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = UserInviteParamsLevel.Member,
            MiddleName = "Marie",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        bool expectedCanCreateReports = true;
        bool expectedCanManageStudies = true;
        ApiEnum<string, UserInviteParamsClinicRole> expectedClinicRole =
            UserInviteParamsClinicRole.Radiologist;
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        string expectedLastName = "Johnson";
        ApiEnum<string, UserInviteParamsLevel> expectedLevel = UserInviteParamsLevel.Member;
        string expectedMiddleName = "Marie";
        string expectedNpiNumber = "1234567893";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedCanCreateReports, parameters.CanCreateReports);
        Assert.Equal(expectedCanManageStudies, parameters.CanManageStudies);
        Assert.Equal(expectedClinicRole, parameters.ClinicRole);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedHasDashboardAccess, parameters.HasDashboardAccess);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedLevel, parameters.Level);
        Assert.Equal(expectedMiddleName, parameters.MiddleName);
        Assert.Equal(expectedNpiNumber, parameters.NpiNumber);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedSuffix1, parameters.Suffix1);
        Assert.Equal(expectedSuffix2, parameters.Suffix2);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicRole = UserInviteParamsClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = UserInviteParamsLevel.Member,
        };

        Assert.Null(parameters.MiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("middleName"));
        Assert.Null(parameters.NpiNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("npiNumber"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Suffix1);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix1"));
        Assert.Null(parameters.Suffix2);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix2"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicRole = UserInviteParamsClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = UserInviteParamsLevel.Member,

            // Null should be interpreted as omitted for these properties
            MiddleName = null,
            NpiNumber = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(parameters.MiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("middleName"));
        Assert.Null(parameters.NpiNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("npiNumber"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Suffix1);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix1"));
        Assert.Null(parameters.Suffix2);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix2"));
    }

    [Fact]
    public void Url_Works()
    {
        UserInviteParams parameters = new()
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicRole = UserInviteParamsClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = UserInviteParamsLevel.Member,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.avarasoftware.com/v1/autoScribe/users"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserInviteParams
        {
            CanCreateReports = true,
            CanManageStudies = true,
            ClinicRole = UserInviteParamsClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = UserInviteParamsLevel.Member,
            MiddleName = "Marie",
            NpiNumber = "1234567893",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        UserInviteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UserInviteParamsClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(UserInviteParamsClinicRole.Radiologist)]
    [InlineData(UserInviteParamsClinicRole.Cardiologist)]
    [InlineData(UserInviteParamsClinicRole.Neurologist)]
    [InlineData(UserInviteParamsClinicRole.Urologist)]
    [InlineData(UserInviteParamsClinicRole.Gynecologist)]
    [InlineData(UserInviteParamsClinicRole.Endocrinologist)]
    [InlineData(UserInviteParamsClinicRole.Doctor)]
    [InlineData(UserInviteParamsClinicRole.Surgeon)]
    [InlineData(UserInviteParamsClinicRole.Physician)]
    [InlineData(UserInviteParamsClinicRole.PhysicianAssistant)]
    [InlineData(UserInviteParamsClinicRole.NursePractitioner)]
    [InlineData(UserInviteParamsClinicRole.RegisteredNurse)]
    [InlineData(UserInviteParamsClinicRole.PatientCareCoordinator)]
    [InlineData(UserInviteParamsClinicRole.FrontDeskOperator)]
    [InlineData(UserInviteParamsClinicRole.ImagingTechnologist)]
    [InlineData(UserInviteParamsClinicRole.PacsAdministrator)]
    [InlineData(UserInviteParamsClinicRole.SoftwareEngineer)]
    [InlineData(UserInviteParamsClinicRole.RevenueCycleManager)]
    [InlineData(UserInviteParamsClinicRole.AdministrativeDirector)]
    [InlineData(UserInviteParamsClinicRole.AdministrativeAssistant)]
    [InlineData(UserInviteParamsClinicRole.Other)]
    public void Validation_Works(UserInviteParamsClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteParamsClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInviteParamsClinicRole.Radiologist)]
    [InlineData(UserInviteParamsClinicRole.Cardiologist)]
    [InlineData(UserInviteParamsClinicRole.Neurologist)]
    [InlineData(UserInviteParamsClinicRole.Urologist)]
    [InlineData(UserInviteParamsClinicRole.Gynecologist)]
    [InlineData(UserInviteParamsClinicRole.Endocrinologist)]
    [InlineData(UserInviteParamsClinicRole.Doctor)]
    [InlineData(UserInviteParamsClinicRole.Surgeon)]
    [InlineData(UserInviteParamsClinicRole.Physician)]
    [InlineData(UserInviteParamsClinicRole.PhysicianAssistant)]
    [InlineData(UserInviteParamsClinicRole.NursePractitioner)]
    [InlineData(UserInviteParamsClinicRole.RegisteredNurse)]
    [InlineData(UserInviteParamsClinicRole.PatientCareCoordinator)]
    [InlineData(UserInviteParamsClinicRole.FrontDeskOperator)]
    [InlineData(UserInviteParamsClinicRole.ImagingTechnologist)]
    [InlineData(UserInviteParamsClinicRole.PacsAdministrator)]
    [InlineData(UserInviteParamsClinicRole.SoftwareEngineer)]
    [InlineData(UserInviteParamsClinicRole.RevenueCycleManager)]
    [InlineData(UserInviteParamsClinicRole.AdministrativeDirector)]
    [InlineData(UserInviteParamsClinicRole.AdministrativeAssistant)]
    [InlineData(UserInviteParamsClinicRole.Other)]
    public void SerializationRoundtrip_Works(UserInviteParamsClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteParamsClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsClinicRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsClinicRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserInviteParamsLevelTest : TestBase
{
    [Theory]
    [InlineData(UserInviteParamsLevel.Admin)]
    [InlineData(UserInviteParamsLevel.Member)]
    public void Validation_Works(UserInviteParamsLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteParamsLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInviteParamsLevel.Admin)]
    [InlineData(UserInviteParamsLevel.Member)]
    public void SerializationRoundtrip_Works(UserInviteParamsLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInviteParamsLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInviteParamsLevel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
