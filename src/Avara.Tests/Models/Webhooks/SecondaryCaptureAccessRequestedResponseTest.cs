using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class SecondaryCaptureAccessRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
            ContentCreatorName = "Dr. Jane Smith",
            Error = "Study not found in PACS",
        };

        bool expectedAuthorized = true;
        List<string> expectedUploadUrls =
        [
            "https://storage.example.com/dicom/sc-object.dcm?token=put123",
        ];
        string expectedContentCreatorName = "Dr. Jane Smith";
        string expectedError = "Study not found in PACS";

        Assert.Equal(expectedAuthorized, model.Authorized);
        Assert.Equal(expectedUploadUrls.Count, model.UploadUrls.Count);
        for (int i = 0; i < expectedUploadUrls.Count; i++)
        {
            Assert.Equal(expectedUploadUrls[i], model.UploadUrls[i]);
        }
        Assert.Equal(expectedContentCreatorName, model.ContentCreatorName);
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
            ContentCreatorName = "Dr. Jane Smith",
            Error = "Study not found in PACS",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
            ContentCreatorName = "Dr. Jane Smith",
            Error = "Study not found in PACS",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecondaryCaptureAccessRequestedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAuthorized = true;
        List<string> expectedUploadUrls =
        [
            "https://storage.example.com/dicom/sc-object.dcm?token=put123",
        ];
        string expectedContentCreatorName = "Dr. Jane Smith";
        string expectedError = "Study not found in PACS";

        Assert.Equal(expectedAuthorized, deserialized.Authorized);
        Assert.Equal(expectedUploadUrls.Count, deserialized.UploadUrls.Count);
        for (int i = 0; i < expectedUploadUrls.Count; i++)
        {
            Assert.Equal(expectedUploadUrls[i], deserialized.UploadUrls[i]);
        }
        Assert.Equal(expectedContentCreatorName, deserialized.ContentCreatorName);
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
            ContentCreatorName = "Dr. Jane Smith",
            Error = "Study not found in PACS",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
        };

        Assert.Null(model.ContentCreatorName);
        Assert.False(model.RawData.ContainsKey("contentCreatorName"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],

            // Null should be interpreted as omitted for these properties
            ContentCreatorName = null,
            Error = null,
        };

        Assert.Null(model.ContentCreatorName);
        Assert.False(model.RawData.ContainsKey("contentCreatorName"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],

            // Null should be interpreted as omitted for these properties
            ContentCreatorName = null,
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecondaryCaptureAccessRequestedResponse
        {
            Authorized = true,
            UploadUrls = ["https://storage.example.com/dicom/sc-object.dcm?token=put123"],
            ContentCreatorName = "Dr. Jane Smith",
            Error = "Study not found in PACS",
        };

        SecondaryCaptureAccessRequestedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
