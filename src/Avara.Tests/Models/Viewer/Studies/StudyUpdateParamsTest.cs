using System;
using System.Collections.Generic;
using Avara.Core;
using Avara.Models;
using Avara.Models.Viewer;
using Avara.Models.Viewer.Studies;

namespace Avara.Tests.Models.Viewer.Studies;

public class StudyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Severity = Severity.Stat,
            StudyDescription = "CT Chest/Abdomen/Pelvis with Contrast",
            StudyViewerStatus = StudyViewerStatus.Complete,
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Severity> expectedSeverity = Severity.Stat;
        string expectedStudyDescription = "CT Chest/Abdomen/Pelvis with Contrast";
        ApiEnum<string, StudyViewerStatus> expectedStudyViewerStatus = StudyViewerStatus.Complete;

        Assert.Equal(expectedStudyID, parameters.StudyID);
        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.Equal(expectedStudyViewerStatus, parameters.StudyViewerStatus);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawBodyData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("studyDescription"));
        Assert.Null(parameters.StudyViewerStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("studyViewerStatus"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            AssignedTo = null,
            Severity = null,
            StudyDescription = null,
            StudyViewerStatus = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawBodyData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("studyDescription"));
        Assert.Null(parameters.StudyViewerStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("studyViewerStatus"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Severity = Severity.Stat,
            StudyDescription = "CT Chest/Abdomen/Pelvis with Contrast",
            StudyViewerStatus = StudyViewerStatus.Complete,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Severity = Severity.Stat,
            StudyDescription = "CT Chest/Abdomen/Pelvis with Contrast",
            StudyViewerStatus = StudyViewerStatus.Complete,

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyUpdateParams parameters = new() { StudyID = "stu_1234567890abcdef1234567890abcdef" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/viewer/studies/stu_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Severity = Severity.Stat,
            StudyDescription = "CT Chest/Abdomen/Pelvis with Contrast",
            StudyViewerStatus = StudyViewerStatus.Complete,
        };

        StudyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
