using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

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
            Severity = StudyListParamsSeverity.Normal,
            StudyDescription = "CT Head",
            StudyReportStatus = [StudyReportStatus.Completed],
        };

        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        string expectedCursor = "eyJvZmZzZXQiOjIwfQ==";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        bool expectedIsCancelled = false;
        double expectedLimit = 20;
        ApiEnum<string, StudyListParamsSeverity> expectedSeverity = StudyListParamsSeverity.Normal;
        string expectedStudyDescription = "CT Head";
        List<ApiEnum<string, StudyReportStatus>> expectedStudyReportStatus =
        [
            StudyReportStatus.Completed,
        ];

        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedIsCancelled, parameters.IsCancelled);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.NotNull(parameters.StudyReportStatus);
        Assert.Equal(expectedStudyReportStatus.Count, parameters.StudyReportStatus.Count);
        for (int i = 0; i < expectedStudyReportStatus.Count; i++)
        {
            Assert.Equal(expectedStudyReportStatus[i], parameters.StudyReportStatus[i]);
        }
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
        Assert.Null(parameters.StudyReportStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("studyReportStatus"));
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
            StudyReportStatus = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawQueryData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawQueryData.ContainsKey("studyDescription"));
        Assert.Null(parameters.StudyReportStatus);
        Assert.False(parameters.RawQueryData.ContainsKey("studyReportStatus"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyListParams
        {
            Cursor = "eyJvZmZzZXQiOjIwfQ==",
            Limit = 20,
            Severity = StudyListParamsSeverity.Normal,
            StudyDescription = "CT Head",
            StudyReportStatus = [StudyReportStatus.Completed],
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
            Severity = StudyListParamsSeverity.Normal,
            StudyDescription = "CT Head",
            StudyReportStatus = [StudyReportStatus.Completed],

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
            Severity = StudyListParamsSeverity.Normal,
            StudyDescription = "CT Head",
            StudyReportStatus = [StudyReportStatus.Completed],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/studies?assignedTo=usr_1234567890abcdef1234567890abcdef&cursor=eyJvZmZzZXQiOjIwfQ%3d%3d&expressCustomerId=cus_1234567890abcdef1234567890abcdef&isCancelled=false&limit=20&severity=normal&studyDescription=CT+Head&studyReportStatus=completed"
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
            Severity = StudyListParamsSeverity.Normal,
            StudyDescription = "CT Head",
            StudyReportStatus = [StudyReportStatus.Completed],
        };

        StudyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StudyListParamsSeverityTest : TestBase
{
    [Theory]
    [InlineData(StudyListParamsSeverity.Normal)]
    [InlineData(StudyListParamsSeverity.High)]
    [InlineData(StudyListParamsSeverity.Stat)]
    public void Validation_Works(StudyListParamsSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListParamsSeverity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListParamsSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyListParamsSeverity.Normal)]
    [InlineData(StudyListParamsSeverity.High)]
    [InlineData(StudyListParamsSeverity.Stat)]
    public void SerializationRoundtrip_Works(StudyListParamsSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyListParamsSeverity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyListParamsSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyListParamsSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyListParamsSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StudyReportStatusTest : TestBase
{
    [Theory]
    [InlineData(StudyReportStatus.Unassigned)]
    [InlineData(StudyReportStatus.Assigned)]
    [InlineData(StudyReportStatus.InProgress)]
    [InlineData(StudyReportStatus.Completed)]
    [InlineData(StudyReportStatus.AddendumActive)]
    public void Validation_Works(StudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyReportStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyReportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyReportStatus.Unassigned)]
    [InlineData(StudyReportStatus.Assigned)]
    [InlineData(StudyReportStatus.InProgress)]
    [InlineData(StudyReportStatus.Completed)]
    [InlineData(StudyReportStatus.AddendumActive)]
    public void SerializationRoundtrip_Works(StudyReportStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyReportStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyReportStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyReportStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyReportStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
