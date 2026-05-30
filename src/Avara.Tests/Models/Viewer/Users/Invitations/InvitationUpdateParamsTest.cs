using System;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            FirstName = "Michael",
            HasDashboardAccess = true,
            LastName = "Chen",
            Level = AssignableUserLevel.Member,
            MiddleName = "x",
            PhoneNumber = "5551234567",
            Suffix1 = "x",
            Suffix2 = "x",
        };

        string expectedInvitationID = "inv_1234567890abcdef1234567890abcdef";
        bool expectedCanManageStudies = true;
        ApiEnum<string, ClinicRole> expectedClinicRole = ClinicRole.Radiologist;
        string expectedFirstName = "Michael";
        bool expectedHasDashboardAccess = true;
        string expectedLastName = "Chen";
        ApiEnum<string, AssignableUserLevel> expectedLevel = AssignableUserLevel.Member;
        string expectedMiddleName = "x";
        string expectedPhoneNumber = "5551234567";
        string expectedSuffix1 = "x";
        string expectedSuffix2 = "x";

        Assert.Equal(expectedInvitationID, parameters.InvitationID);
        Assert.Equal(expectedCanManageStudies, parameters.CanManageStudies);
        Assert.Equal(expectedClinicRole, parameters.ClinicRole);
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
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            ClinicRole = ClinicRole.Radiologist,
            MiddleName = "x",
            PhoneNumber = "5551234567",
            Suffix1 = "x",
            Suffix2 = "x",
        };

        Assert.Null(parameters.CanManageStudies);
        Assert.False(parameters.RawBodyData.ContainsKey("canManageStudies"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.HasDashboardAccess);
        Assert.False(parameters.RawBodyData.ContainsKey("hasDashboardAccess"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Level);
        Assert.False(parameters.RawBodyData.ContainsKey("level"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            ClinicRole = ClinicRole.Radiologist,
            MiddleName = "x",
            PhoneNumber = "5551234567",
            Suffix1 = "x",
            Suffix2 = "x",

            // Null should be interpreted as omitted for these properties
            CanManageStudies = null,
            FirstName = null,
            HasDashboardAccess = null,
            LastName = null,
            Level = null,
        };

        Assert.Null(parameters.CanManageStudies);
        Assert.False(parameters.RawBodyData.ContainsKey("canManageStudies"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.HasDashboardAccess);
        Assert.False(parameters.RawBodyData.ContainsKey("hasDashboardAccess"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Level);
        Assert.False(parameters.RawBodyData.ContainsKey("level"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            CanManageStudies = true,
            FirstName = "Michael",
            HasDashboardAccess = true,
            LastName = "Chen",
            Level = AssignableUserLevel.Member,
        };

        Assert.Null(parameters.ClinicRole);
        Assert.False(parameters.RawBodyData.ContainsKey("clinicRole"));
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
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            CanManageStudies = true,
            FirstName = "Michael",
            HasDashboardAccess = true,
            LastName = "Chen",
            Level = AssignableUserLevel.Member,

            ClinicRole = null,
            MiddleName = null,
            PhoneNumber = null,
            Suffix1 = null,
            Suffix2 = null,
        };

        Assert.Null(parameters.ClinicRole);
        Assert.True(parameters.RawBodyData.ContainsKey("clinicRole"));
        Assert.Null(parameters.MiddleName);
        Assert.True(parameters.RawBodyData.ContainsKey("middleName"));
        Assert.Null(parameters.PhoneNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Suffix1);
        Assert.True(parameters.RawBodyData.ContainsKey("suffix1"));
        Assert.Null(parameters.Suffix2);
        Assert.True(parameters.RawBodyData.ContainsKey("suffix2"));
    }

    [Fact]
    public void Url_Works()
    {
        InvitationUpdateParams parameters = new()
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/users/invitations/inv_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationUpdateParams
        {
            InvitationID = "inv_1234567890abcdef1234567890abcdef",
            CanManageStudies = true,
            ClinicRole = ClinicRole.Radiologist,
            FirstName = "Michael",
            HasDashboardAccess = true,
            LastName = "Chen",
            Level = AssignableUserLevel.Member,
            MiddleName = "x",
            PhoneNumber = "5551234567",
            Suffix1 = "x",
            Suffix2 = "x",
        };

        InvitationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
