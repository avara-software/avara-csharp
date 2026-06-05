using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class SecondaryCaptureAccessRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1";

        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedSeriesInstanceUid, model.SeriesInstanceUid);
        Assert.Equal(expectedSopInstanceUid, model.SopInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1";

        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedSeriesInstanceUid, deserialized.SeriesInstanceUid);
        Assert.Equal(expectedSopInstanceUid, deserialized.SopInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        Assert.Null(model.SeriesInstanceUid);
        Assert.False(model.RawData.ContainsKey("seriesInstanceUid"));
        Assert.Null(model.SopInstanceUid);
        Assert.False(model.RawData.ContainsKey("sopInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            SeriesInstanceUid = null,
            SopInstanceUid = null,
        };

        Assert.Null(model.SeriesInstanceUid);
        Assert.False(model.RawData.ContainsKey("seriesInstanceUid"));
        Assert.Null(model.SopInstanceUid);
        Assert.False(model.RawData.ContainsKey("sopInstanceUid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",

            // Null should be interpreted as omitted for these properties
            SeriesInstanceUid = null,
            SopInstanceUid = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecondaryCaptureAccessRequestedEventData
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1234567890.1",
            SopInstanceUid = "1.2.840.113619.2.55.3.1234567890.1.1",
        };

        SecondaryCaptureAccessRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
