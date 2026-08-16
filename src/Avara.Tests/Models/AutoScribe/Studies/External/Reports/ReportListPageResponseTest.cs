using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
            Cursor = "cursor",
        };

        bool expectedHasMore = true;
        List<ReportListResponse> expectedReports =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                HasReportText = true,
                ReportPdfPresent = true,
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                ReaderName = "readerName",
                SignedAt = "signedAt",
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedReports.Count, model.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], model.Reports[i]);
        }
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
            Cursor = "cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
            Cursor = "cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        List<ReportListResponse> expectedReports =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                HasReportText = true,
                ReportPdfPresent = true,
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                ReaderName = "readerName",
                SignedAt = "signedAt",
            },
        ];
        string expectedCursor = "cursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedReports.Count, deserialized.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], deserialized.Reports[i]);
        }
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
            Cursor = "cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
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
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
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
        var model = new ReportListPageResponse
        {
            HasMore = true,
            Reports =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
                    HasReportText = true,
                    ReportPdfPresent = true,
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    ReaderName = "readerName",
                    SignedAt = "signedAt",
                },
            ],
            Cursor = "cursor",
        };

        ReportListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
