using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedManifestSopTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
            BitsAllocated = 16,
            BitsStored = 16,
            Columns = 512,
            HighBit = 15,
            InstanceNumber = 1,
            IsDoubleFloatPixelData = true,
            IsFloatPixelData = true,
            NumberOfFrames = 1,
            PhotometricInterpretation = "MONOCHROME2",
            PixelRepresentation = 0,
            RescaleIntercept = -1024,
            RescaleSlope = 1,
            Rows = 512,
            SamplesPerPixel = 1,
        };

        string expectedSopClassUid = "1.2.840.10008.5.1.4.1.1.2";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1.4.1";
        double expectedBitsAllocated = 16;
        double expectedBitsStored = 16;
        double expectedColumns = 512;
        double expectedHighBit = 15;
        double expectedInstanceNumber = 1;
        bool expectedIsDoubleFloatPixelData = true;
        bool expectedIsFloatPixelData = true;
        double expectedNumberOfFrames = 1;
        string expectedPhotometricInterpretation = "MONOCHROME2";
        double expectedPixelRepresentation = 0;
        double expectedRescaleIntercept = -1024;
        double expectedRescaleSlope = 1;
        double expectedRows = 512;
        double expectedSamplesPerPixel = 1;

        Assert.Equal(expectedSopClassUid, model.SopClassUid);
        Assert.Equal(expectedSopInstanceUid, model.SopInstanceUid);
        Assert.Equal(expectedBitsAllocated, model.BitsAllocated);
        Assert.Equal(expectedBitsStored, model.BitsStored);
        Assert.Equal(expectedColumns, model.Columns);
        Assert.Equal(expectedHighBit, model.HighBit);
        Assert.Equal(expectedInstanceNumber, model.InstanceNumber);
        Assert.Equal(expectedIsDoubleFloatPixelData, model.IsDoubleFloatPixelData);
        Assert.Equal(expectedIsFloatPixelData, model.IsFloatPixelData);
        Assert.Equal(expectedNumberOfFrames, model.NumberOfFrames);
        Assert.Equal(expectedPhotometricInterpretation, model.PhotometricInterpretation);
        Assert.Equal(expectedPixelRepresentation, model.PixelRepresentation);
        Assert.Equal(expectedRescaleIntercept, model.RescaleIntercept);
        Assert.Equal(expectedRescaleSlope, model.RescaleSlope);
        Assert.Equal(expectedRows, model.Rows);
        Assert.Equal(expectedSamplesPerPixel, model.SamplesPerPixel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
            BitsAllocated = 16,
            BitsStored = 16,
            Columns = 512,
            HighBit = 15,
            InstanceNumber = 1,
            IsDoubleFloatPixelData = true,
            IsFloatPixelData = true,
            NumberOfFrames = 1,
            PhotometricInterpretation = "MONOCHROME2",
            PixelRepresentation = 0,
            RescaleIntercept = -1024,
            RescaleSlope = 1,
            Rows = 512,
            SamplesPerPixel = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifestSop>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
            BitsAllocated = 16,
            BitsStored = 16,
            Columns = 512,
            HighBit = 15,
            InstanceNumber = 1,
            IsDoubleFloatPixelData = true,
            IsFloatPixelData = true,
            NumberOfFrames = 1,
            PhotometricInterpretation = "MONOCHROME2",
            PixelRepresentation = 0,
            RescaleIntercept = -1024,
            RescaleSlope = 1,
            Rows = 512,
            SamplesPerPixel = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifestSop>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSopClassUid = "1.2.840.10008.5.1.4.1.1.2";
        string expectedSopInstanceUid = "1.2.840.113619.2.55.3.1.4.1";
        double expectedBitsAllocated = 16;
        double expectedBitsStored = 16;
        double expectedColumns = 512;
        double expectedHighBit = 15;
        double expectedInstanceNumber = 1;
        bool expectedIsDoubleFloatPixelData = true;
        bool expectedIsFloatPixelData = true;
        double expectedNumberOfFrames = 1;
        string expectedPhotometricInterpretation = "MONOCHROME2";
        double expectedPixelRepresentation = 0;
        double expectedRescaleIntercept = -1024;
        double expectedRescaleSlope = 1;
        double expectedRows = 512;
        double expectedSamplesPerPixel = 1;

        Assert.Equal(expectedSopClassUid, deserialized.SopClassUid);
        Assert.Equal(expectedSopInstanceUid, deserialized.SopInstanceUid);
        Assert.Equal(expectedBitsAllocated, deserialized.BitsAllocated);
        Assert.Equal(expectedBitsStored, deserialized.BitsStored);
        Assert.Equal(expectedColumns, deserialized.Columns);
        Assert.Equal(expectedHighBit, deserialized.HighBit);
        Assert.Equal(expectedInstanceNumber, deserialized.InstanceNumber);
        Assert.Equal(expectedIsDoubleFloatPixelData, deserialized.IsDoubleFloatPixelData);
        Assert.Equal(expectedIsFloatPixelData, deserialized.IsFloatPixelData);
        Assert.Equal(expectedNumberOfFrames, deserialized.NumberOfFrames);
        Assert.Equal(expectedPhotometricInterpretation, deserialized.PhotometricInterpretation);
        Assert.Equal(expectedPixelRepresentation, deserialized.PixelRepresentation);
        Assert.Equal(expectedRescaleIntercept, deserialized.RescaleIntercept);
        Assert.Equal(expectedRescaleSlope, deserialized.RescaleSlope);
        Assert.Equal(expectedRows, deserialized.Rows);
        Assert.Equal(expectedSamplesPerPixel, deserialized.SamplesPerPixel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
            BitsAllocated = 16,
            BitsStored = 16,
            Columns = 512,
            HighBit = 15,
            InstanceNumber = 1,
            IsDoubleFloatPixelData = true,
            IsFloatPixelData = true,
            NumberOfFrames = 1,
            PhotometricInterpretation = "MONOCHROME2",
            PixelRepresentation = 0,
            RescaleIntercept = -1024,
            RescaleSlope = 1,
            Rows = 512,
            SamplesPerPixel = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
        };

        Assert.Null(model.BitsAllocated);
        Assert.False(model.RawData.ContainsKey("bitsAllocated"));
        Assert.Null(model.BitsStored);
        Assert.False(model.RawData.ContainsKey("bitsStored"));
        Assert.Null(model.Columns);
        Assert.False(model.RawData.ContainsKey("columns"));
        Assert.Null(model.HighBit);
        Assert.False(model.RawData.ContainsKey("highBit"));
        Assert.Null(model.InstanceNumber);
        Assert.False(model.RawData.ContainsKey("instanceNumber"));
        Assert.Null(model.IsDoubleFloatPixelData);
        Assert.False(model.RawData.ContainsKey("isDoubleFloatPixelData"));
        Assert.Null(model.IsFloatPixelData);
        Assert.False(model.RawData.ContainsKey("isFloatPixelData"));
        Assert.Null(model.NumberOfFrames);
        Assert.False(model.RawData.ContainsKey("numberOfFrames"));
        Assert.Null(model.PhotometricInterpretation);
        Assert.False(model.RawData.ContainsKey("photometricInterpretation"));
        Assert.Null(model.PixelRepresentation);
        Assert.False(model.RawData.ContainsKey("pixelRepresentation"));
        Assert.Null(model.RescaleIntercept);
        Assert.False(model.RawData.ContainsKey("rescaleIntercept"));
        Assert.Null(model.RescaleSlope);
        Assert.False(model.RawData.ContainsKey("rescaleSlope"));
        Assert.Null(model.Rows);
        Assert.False(model.RawData.ContainsKey("rows"));
        Assert.Null(model.SamplesPerPixel);
        Assert.False(model.RawData.ContainsKey("samplesPerPixel"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",

            // Null should be interpreted as omitted for these properties
            BitsAllocated = null,
            BitsStored = null,
            Columns = null,
            HighBit = null,
            InstanceNumber = null,
            IsDoubleFloatPixelData = null,
            IsFloatPixelData = null,
            NumberOfFrames = null,
            PhotometricInterpretation = null,
            PixelRepresentation = null,
            RescaleIntercept = null,
            RescaleSlope = null,
            Rows = null,
            SamplesPerPixel = null,
        };

        Assert.Null(model.BitsAllocated);
        Assert.False(model.RawData.ContainsKey("bitsAllocated"));
        Assert.Null(model.BitsStored);
        Assert.False(model.RawData.ContainsKey("bitsStored"));
        Assert.Null(model.Columns);
        Assert.False(model.RawData.ContainsKey("columns"));
        Assert.Null(model.HighBit);
        Assert.False(model.RawData.ContainsKey("highBit"));
        Assert.Null(model.InstanceNumber);
        Assert.False(model.RawData.ContainsKey("instanceNumber"));
        Assert.Null(model.IsDoubleFloatPixelData);
        Assert.False(model.RawData.ContainsKey("isDoubleFloatPixelData"));
        Assert.Null(model.IsFloatPixelData);
        Assert.False(model.RawData.ContainsKey("isFloatPixelData"));
        Assert.Null(model.NumberOfFrames);
        Assert.False(model.RawData.ContainsKey("numberOfFrames"));
        Assert.Null(model.PhotometricInterpretation);
        Assert.False(model.RawData.ContainsKey("photometricInterpretation"));
        Assert.Null(model.PixelRepresentation);
        Assert.False(model.RawData.ContainsKey("pixelRepresentation"));
        Assert.Null(model.RescaleIntercept);
        Assert.False(model.RawData.ContainsKey("rescaleIntercept"));
        Assert.Null(model.RescaleSlope);
        Assert.False(model.RawData.ContainsKey("rescaleSlope"));
        Assert.Null(model.Rows);
        Assert.False(model.RawData.ContainsKey("rows"));
        Assert.Null(model.SamplesPerPixel);
        Assert.False(model.RawData.ContainsKey("samplesPerPixel"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",

            // Null should be interpreted as omitted for these properties
            BitsAllocated = null,
            BitsStored = null,
            Columns = null,
            HighBit = null,
            InstanceNumber = null,
            IsDoubleFloatPixelData = null,
            IsFloatPixelData = null,
            NumberOfFrames = null,
            PhotometricInterpretation = null,
            PixelRepresentation = null,
            RescaleIntercept = null,
            RescaleSlope = null,
            Rows = null,
            SamplesPerPixel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedManifestSop
        {
            SopClassUid = "1.2.840.10008.5.1.4.1.1.2",
            SopInstanceUid = "1.2.840.113619.2.55.3.1.4.1",
            BitsAllocated = 16,
            BitsStored = 16,
            Columns = 512,
            HighBit = 15,
            InstanceNumber = 1,
            IsDoubleFloatPixelData = true,
            IsFloatPixelData = true,
            NumberOfFrames = 1,
            PhotometricInterpretation = "MONOCHROME2",
            PixelRepresentation = 0,
            RescaleIntercept = -1024,
            RescaleSlope = 1,
            Rows = 512,
            SamplesPerPixel = 1,
        };

        StudyAccessRequestedManifestSop copied = new(model);

        Assert.Equal(model, copied);
    }
}
