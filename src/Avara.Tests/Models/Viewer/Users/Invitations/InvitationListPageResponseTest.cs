using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer.Users.Invitations;

namespace Avara.Tests.Models.Viewer.Users.Invitations;

public class InvitationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
            Cursor = "cursor",
        };

        bool expectedHasMore = true;
        List<InvitationListResponse> expectedInvitations =
        [
            new()
            {
                CanManageStudies = true,
                ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                ClinicRole = ClinicRole.Radiologist,
                CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                Email = "dr.chen@hospital.org",
                Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                FirstName = "Michael",
                HasDashboardAccess = true,
                InvitationID = "inv_1234567890abcdef1234567890abcdef",
                InvitedSource = InvitedSource.Api,
                InviterID = "usr_1234567890abcdef1234567890abcdef",
                LastName = "Chen",
                Level = UserLevel.Member,
                Status = InvitationStatus.Sent,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                UserID = "usr_1234567890abcdef1234567890abcdef",
                InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                MiddleName = "David",
                PhoneNumber = "5551234567",
                Suffix1 = "MD",
                Suffix2 = null,
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedInvitations.Count, model.Invitations.Count);
        for (int i = 0; i < expectedInvitations.Count; i++)
        {
            Assert.Equal(expectedInvitations[i], model.Invitations[i]);
        }
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<InvitationListResponse> expectedInvitations =
        [
            new()
            {
                CanManageStudies = true,
                ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                ClinicRole = ClinicRole.Radiologist,
                CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                Email = "dr.chen@hospital.org",
                Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                FirstName = "Michael",
                HasDashboardAccess = true,
                InvitationID = "inv_1234567890abcdef1234567890abcdef",
                InvitedSource = InvitedSource.Api,
                InviterID = "usr_1234567890abcdef1234567890abcdef",
                LastName = "Chen",
                Level = UserLevel.Member,
                Status = InvitationStatus.Sent,
                UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                UserID = "usr_1234567890abcdef1234567890abcdef",
                InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                MiddleName = "David",
                PhoneNumber = "5551234567",
                Suffix1 = "MD",
                Suffix2 = null,
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedInvitations.Count, deserialized.Invitations.Count);
        for (int i = 0; i < expectedInvitations.Count; i++)
        {
            Assert.Equal(expectedInvitations[i], deserialized.Invitations[i]);
        }
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
            Cursor = "cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
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
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
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
        var model = new InvitationListPageResponse
        {
            HasMore = true,
            Invitations =
            [
                new()
                {
                    CanManageStudies = true,
                    ClinicID = "550e8400-e29b-41d4-a716-446655440000",
                    ClinicRole = ClinicRole.Radiologist,
                    CreatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    Email = "dr.chen@hospital.org",
                    Expiry = DateTimeOffset.Parse("2024-04-15T00:00:00Z"),
                    FirstName = "Michael",
                    HasDashboardAccess = true,
                    InvitationID = "inv_1234567890abcdef1234567890abcdef",
                    InvitedSource = InvitedSource.Api,
                    InviterID = "usr_1234567890abcdef1234567890abcdef",
                    LastName = "Chen",
                    Level = UserLevel.Member,
                    Status = InvitationStatus.Sent,
                    UpdatedAt = DateTimeOffset.Parse("2024-03-15T10:00:00Z"),
                    UserID = "usr_1234567890abcdef1234567890abcdef",
                    InvitedByApiKeyID = "550e8400-e29b-41d4-a716-446655440000",
                    MiddleName = "David",
                    PhoneNumber = "5551234567",
                    Suffix1 = "MD",
                    Suffix2 = null,
                },
            ],
            Cursor = "cursor",
        };

        InvitationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
