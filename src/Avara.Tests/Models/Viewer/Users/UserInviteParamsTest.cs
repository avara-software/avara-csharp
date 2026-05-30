using System;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer.Users;

namespace Avara.Tests.Models.Viewer.Users;

public class UserInviteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserInviteParams
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = AssignableUserLevel.Member,
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        bool expectedCanManageStudies = true;
        ApiEnum<string, ClinicRole> expectedClinicRole = ClinicRole.Radiologist;
        string expectedEmail = "dr.johnson@hospital.org";
        string expectedFirstName = "Sarah";
        bool expectedHasDashboardAccess = true;
        string expectedLastName = "Johnson";
        ApiEnum<string, AssignableUserLevel> expectedLevel = AssignableUserLevel.Member;
        string expectedMiddleName = "Marie";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "MD";
        string expectedSuffix2 = "FACR";

        Assert.Equal(expectedCanManageStudies, parameters.CanManageStudies);
        Assert.Equal(expectedClinicRole, parameters.ClinicRole);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedHasDashboardAccess, parameters.HasDashboardAccess);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedLevel, parameters.Level);
        Assert.Equal(expectedMiddleName, parameters.MiddleName);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedSuffix1, parameters.Suffix1);
        Assert.Equal(expectedSuffix2, parameters.Suffix2);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserInviteParams
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = AssignableUserLevel.Member,
        };

        Assert.Null(parameters.MiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("middleName"));
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
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = AssignableUserLevel.Member,

            // Null should be interpreted as omitted for these properties
            MiddleName = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(parameters.MiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("middleName"));
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
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = AssignableUserLevel.Member,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.avarasoftware.com/v1/viewer/users"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserInviteParams
        {
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            Email = "dr.johnson@hospital.org",
            FirstName = "Sarah",
            HasDashboardAccess = true,
            LastName = "Johnson",
            Level = AssignableUserLevel.Member,
            MiddleName = "Marie",
            PhoneNumber = "5551234567",
            Suffix1 = "MD",
            Suffix2 = "FACR",
        };

        UserInviteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
