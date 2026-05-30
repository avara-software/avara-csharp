using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class ReportIDWithStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportIDWithStatus
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            Status = ReportStatus.Completed,
        };

        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        ApiEnum<string, ReportStatus> expectedStatus = ReportStatus.Completed;

        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportIDWithStatus
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            Status = ReportStatus.Completed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportIDWithStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportIDWithStatus
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            Status = ReportStatus.Completed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportIDWithStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        ApiEnum<string, ReportStatus> expectedStatus = ReportStatus.Completed;

        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportIDWithStatus
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            Status = ReportStatus.Completed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportIDWithStatus
        {
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            Status = ReportStatus.Completed,
        };

        ReportIDWithStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
