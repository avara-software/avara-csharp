using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedMediaUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
            FileName = "clinical-report.pdf",
        };

        string expectedMimeType = "application/pdf";
        string expectedUrl = "https://storage.example.com/media/report.pdf?token=abc123";
        string expectedFileName = "clinical-report.pdf";

        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedFileName, model.FileName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
            FileName = "clinical-report.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedMediaUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
            FileName = "clinical-report.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedMediaUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMimeType = "application/pdf";
        string expectedUrl = "https://storage.example.com/media/report.pdf?token=abc123";
        string expectedFileName = "clinical-report.pdf";

        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedFileName, deserialized.FileName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
            FileName = "clinical-report.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",

            // Null should be interpreted as omitted for these properties
            FileName = null,
        };

        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("fileName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",

            // Null should be interpreted as omitted for these properties
            FileName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedMediaUrl
        {
            MimeType = "application/pdf",
            Url = "https://storage.example.com/media/report.pdf?token=abc123",
            FileName = "clinical-report.pdf",
        };

        StudyAccessRequestedMediaUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}
