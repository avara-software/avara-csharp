using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Study not found in PACS",
        };

        bool expectedAuthorized = true;
        List<string> expectedUrls =
        [
            "https://storage.example.com/dicom/image1.dcm?token=abc123",
            "https://storage.example.com/dicom/image2.dcm?token=def456",
        ];
        string expectedError = "Study not found in PACS";

        Assert.Equal(expectedAuthorized, model.Authorized);
        Assert.Equal(expectedUrls.Count, model.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], model.Urls[i]);
        }
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Study not found in PACS",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Study not found in PACS",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAuthorized = true;
        List<string> expectedUrls =
        [
            "https://storage.example.com/dicom/image1.dcm?token=abc123",
            "https://storage.example.com/dicom/image2.dcm?token=def456",
        ];
        string expectedError = "Study not found in PACS";

        Assert.Equal(expectedAuthorized, deserialized.Authorized);
        Assert.Equal(expectedUrls.Count, deserialized.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], deserialized.Urls[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Study not found in PACS",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],

            // Null should be interpreted as omitted for these properties
            Error = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],

            // Null should be interpreted as omitted for these properties
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Study not found in PACS",
        };

        StudyAccessRequestedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
