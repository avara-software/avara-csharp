using System.Text.Json;
using Avara.Exceptions;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;
using Avara.Models.AutoScribe.Users;
using Avara.Models.Viewer.Studies;
using Invitations = Avara.Models.AutoScribe.Users.Invitations;
using Studies = Avara.Models.AutoScribe.Studies;
using Users = Avara.Models.Viewer.Users;
using UsersInvitations = Avara.Models.Viewer.Users.Invitations;

namespace Avara.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Unit>(),
            new ApiEnumConverter<string, Sex>(),
            new ApiEnumConverter<string, WeightUnit>(),
            new ApiEnumConverter<string, Studies::Status>(),
            new ApiEnumConverter<string, Studies::StudyCreateResponseSeverity>(),
            new ApiEnumConverter<string, Studies::StudyCreateResponseStudyReportStatus>(),
            new ApiEnumConverter<string, Studies::StudyRetrieveResponseSeverity>(),
            new ApiEnumConverter<string, Studies::StudyRetrieveResponseStudyReportStatus>(),
            new ApiEnumConverter<string, Studies::StudyUpdateResponseSeverity>(),
            new ApiEnumConverter<string, Studies::StudyUpdateResponseStudyReportStatus>(),
            new ApiEnumConverter<string, Studies::StudyListResponseSeverity>(),
            new ApiEnumConverter<string, Studies::StudyListResponseStudyReportStatus>(),
            new ApiEnumConverter<string, Studies::StudyRetrieveByUidResponseSeverity>(),
            new ApiEnumConverter<string, Studies::StudyRetrieveByUidResponseStudyReportStatus>(),
            new ApiEnumConverter<string, Studies::Severity>(),
            new ApiEnumConverter<string, Studies::Unit>(),
            new ApiEnumConverter<string, Studies::Sex>(),
            new ApiEnumConverter<string, Studies::WeightUnit>(),
            new ApiEnumConverter<string, Studies::StudyUpdateParamsSeverity>(),
            new ApiEnumConverter<string, Studies::StudyListParamsSeverity>(),
            new ApiEnumConverter<string, Studies::StudyReportStatus>(),
            new ApiEnumConverter<string, UserRetrieveResponseClinicRole>(),
            new ApiEnumConverter<string, UserRetrieveResponseInvitedSource>(),
            new ApiEnumConverter<string, UserRetrieveResponseLevel>(),
            new ApiEnumConverter<string, UserUpdateResponseClinicRole>(),
            new ApiEnumConverter<string, UserUpdateResponseInvitedSource>(),
            new ApiEnumConverter<string, UserUpdateResponseLevel>(),
            new ApiEnumConverter<string, UserListResponseClinicRole>(),
            new ApiEnumConverter<string, UserListResponseInvitedSource>(),
            new ApiEnumConverter<string, UserListResponseLevel>(),
            new ApiEnumConverter<string, UserInviteResponseClinicRole>(),
            new ApiEnumConverter<string, UserInviteResponseInvitedSource>(),
            new ApiEnumConverter<string, UserInviteResponseLevel>(),
            new ApiEnumConverter<string, ClinicRole>(),
            new ApiEnumConverter<string, Level>(),
            new ApiEnumConverter<string, InvitedSource>(),
            new ApiEnumConverter<string, UserListParamsLevel>(),
            new ApiEnumConverter<string, UserInviteParamsClinicRole>(),
            new ApiEnumConverter<string, UserInviteParamsLevel>(),
            new ApiEnumConverter<string, Invitations::InvitationRetrieveResponseClinicRole>(),
            new ApiEnumConverter<string, Invitations::InvitedSource>(),
            new ApiEnumConverter<string, Invitations::InvitationRetrieveResponseLevel>(),
            new ApiEnumConverter<string, Invitations::InvitationRetrieveResponseStatus>(),
            new ApiEnumConverter<string, Invitations::InvitationUpdateResponseClinicRole>(),
            new ApiEnumConverter<string, Invitations::InvitationUpdateResponseInvitedSource>(),
            new ApiEnumConverter<string, Invitations::InvitationUpdateResponseLevel>(),
            new ApiEnumConverter<string, Invitations::InvitationUpdateResponseStatus>(),
            new ApiEnumConverter<string, Invitations::InvitationListResponseClinicRole>(),
            new ApiEnumConverter<string, Invitations::InvitationListResponseInvitedSource>(),
            new ApiEnumConverter<string, Invitations::InvitationListResponseLevel>(),
            new ApiEnumConverter<string, Invitations::InvitationListResponseStatus>(),
            new ApiEnumConverter<string, Invitations::ClinicRole>(),
            new ApiEnumConverter<string, Invitations::Level>(),
            new ApiEnumConverter<string, Invitations::Expired>(),
            new ApiEnumConverter<string, Invitations::Status>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, StudyCreateResponseSeverity>(),
            new ApiEnumConverter<string, StudyCreateResponseStudyViewerStatus>(),
            new ApiEnumConverter<string, StudyRetrieveResponseSeverity>(),
            new ApiEnumConverter<string, StudyRetrieveResponseStudyViewerStatus>(),
            new ApiEnumConverter<string, StudyUpdateResponseSeverity>(),
            new ApiEnumConverter<string, StudyUpdateResponseStudyViewerStatus>(),
            new ApiEnumConverter<string, StudyListResponseSeverity>(),
            new ApiEnumConverter<string, StudyListResponseStudyViewerStatus>(),
            new ApiEnumConverter<string, StudyRetrieveByUidResponseSeverity>(),
            new ApiEnumConverter<string, StudyRetrieveByUidResponseStudyViewerStatus>(),
            new ApiEnumConverter<string, Severity>(),
            new ApiEnumConverter<string, StudyUpdateParamsSeverity>(),
            new ApiEnumConverter<string, StudyViewerStatus>(),
            new ApiEnumConverter<string, StudyListParamsSeverity>(),
            new ApiEnumConverter<string, StudyListParamsStudyViewerStatus>(),
            new ApiEnumConverter<string, Users::UserRetrieveResponseClinicRole>(),
            new ApiEnumConverter<string, Users::UserRetrieveResponseInvitedSource>(),
            new ApiEnumConverter<string, Users::UserRetrieveResponseLevel>(),
            new ApiEnumConverter<string, Users::UserUpdateResponseClinicRole>(),
            new ApiEnumConverter<string, Users::UserUpdateResponseInvitedSource>(),
            new ApiEnumConverter<string, Users::UserUpdateResponseLevel>(),
            new ApiEnumConverter<string, Users::UserListResponseClinicRole>(),
            new ApiEnumConverter<string, Users::UserListResponseInvitedSource>(),
            new ApiEnumConverter<string, Users::UserListResponseLevel>(),
            new ApiEnumConverter<string, Users::UserInviteResponseClinicRole>(),
            new ApiEnumConverter<string, Users::UserInviteResponseInvitedSource>(),
            new ApiEnumConverter<string, Users::UserInviteResponseLevel>(),
            new ApiEnumConverter<string, Users::ClinicRole>(),
            new ApiEnumConverter<string, Users::Level>(),
            new ApiEnumConverter<string, Users::InvitedSource>(),
            new ApiEnumConverter<string, Users::UserListParamsLevel>(),
            new ApiEnumConverter<string, Users::UserInviteParamsClinicRole>(),
            new ApiEnumConverter<string, Users::UserInviteParamsLevel>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationRetrieveResponseClinicRole>(),
            new ApiEnumConverter<string, UsersInvitations::InvitedSource>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationRetrieveResponseLevel>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationRetrieveResponseStatus>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationUpdateResponseClinicRole>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationUpdateResponseInvitedSource>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationUpdateResponseLevel>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationUpdateResponseStatus>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationListResponseClinicRole>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationListResponseInvitedSource>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationListResponseLevel>(),
            new ApiEnumConverter<string, UsersInvitations::InvitationListResponseStatus>(),
            new ApiEnumConverter<string, UsersInvitations::ClinicRole>(),
            new ApiEnumConverter<string, UsersInvitations::Level>(),
            new ApiEnumConverter<string, UsersInvitations::Expired>(),
            new ApiEnumConverter<string, UsersInvitations::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AvaraInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
