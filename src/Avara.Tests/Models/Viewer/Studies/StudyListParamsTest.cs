using System;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Models.Viewer.Studies;

public class StudyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyListParams
        {
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsCancelled = false,
            Limit = 20,
            Severity = Severity.Normal,
            StudyDescription = "CT Head",
            StudyViewerStatus = StudyViewerStatus.Incomplete,
        };

        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        bool expectedIsCancelled = false;
        double expectedLimit = 20;
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "CT Head";
        ApiEnum<string, StudyViewerStatus> expectedStudyViewerStatus = StudyViewerStatus.Incomplete;

        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedIsCancelled, parameters.IsCancelled);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.Equal(expectedStudyViewerStatus, parameters.StudyViewerStatus);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyListParams
        {
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsCancelled = false,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawQueryData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawQueryData.ContainsKey("studyDescription"));
        Assert.Null(parameters.StudyViewerStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("studyViewerStatus"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyListParams
        {
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsCancelled = false,

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            Severity = null,
            StudyDescription = null,
            StudyViewerStatus = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawQueryData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawQueryData.ContainsKey("studyDescription"));
        Assert.Null(parameters.StudyViewerStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("studyViewerStatus"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Limit = 20,
            Severity = Severity.Normal,
            StudyDescription = "CT Head",
            StudyViewerStatus = StudyViewerStatus.Incomplete,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawQueryData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.IsCancelled);
        Assert.False(parameters.RawQueryData.ContainsKey("isCancelled"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new StudyListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Limit = 20,
            Severity = Severity.Normal,
            StudyDescription = "CT Head",
            StudyViewerStatus = StudyViewerStatus.Incomplete,

            AssignedTo = null,
            ExpressCustomerID = null,
            IsCancelled = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.True(parameters.RawQueryData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.True(parameters.RawQueryData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.IsCancelled);
        Assert.True(parameters.RawQueryData.ContainsKey("isCancelled"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyListParams parameters = new()
        {
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsCancelled = false,
            Limit = 20,
            Severity = Severity.Normal,
            StudyDescription = "CT Head",
            StudyViewerStatus = StudyViewerStatus.Incomplete,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/studies?assignedTo=usr_1234567890abcdef1234567890abcdef&cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&expressCustomerId=cus_1234567890abcdef1234567890abcdef&isCancelled=false&limit=20&severity=normal&studyDescription=CT+Head&studyViewerStatus=incomplete"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyListParams
        {
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsCancelled = false,
            Limit = 20,
            Severity = Severity.Normal,
            StudyDescription = "CT Head",
            StudyViewerStatus = StudyViewerStatus.Incomplete,
        };

        StudyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
