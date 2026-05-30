using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe.Users;

namespace Avara.Tests.Models.AutoScribe.Users;

public class UserListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
            Cursor = "cursor",
        };

        bool expectedHasMore = true;
        List<UserListResponse> expectedUsers =
        [
            new()
            {
                CanCreateReports = true,
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
                NpiNumber = "1234567893",
                PhoneNumber = "5551234567",
                Suffix1 = "MD",
                Suffix2 = "FACR",
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], model.Users[i]);
        }
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<UserListResponse> expectedUsers =
        [
            new()
            {
                CanCreateReports = true,
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
                NpiNumber = "1234567893",
                PhoneNumber = "5551234567",
                Suffix1 = "MD",
                Suffix2 = "FACR",
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], deserialized.Users[i]);
        }
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
            Cursor = "cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserListPageResponse
        {
            HasMore = true,
            Users =
            [
                new()
                {
                    CanCreateReports = true,
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
                    NpiNumber = "1234567893",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = "FACR",
                },
            ],
            Cursor = "cursor",
        };

        UserListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
