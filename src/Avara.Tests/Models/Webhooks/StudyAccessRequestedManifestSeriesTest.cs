using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedManifestSeriesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifestSeries
        {
            Modality = "CT",
            SeriesDescription = "AXIAL CT",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1",
            SeriesNumber = 1,
            Sops =
            [
                new()
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
                    RescaleIntercept = 0,
                    RescaleSlope = 0,
                    Rows = 512,
                    SamplesPerPixel = 1,
                },
            ],
        };

        string expectedModality = "CT";
        string expectedSeriesDescription = "AXIAL CT";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1";
        SeriesNumber expectedSeriesNumber = 1;
        List<StudyAccessRequestedManifestSop> expectedSops =
        [
            new()
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
                RescaleIntercept = 0,
                RescaleSlope = 0,
                Rows = 512,
                SamplesPerPixel = 1,
            },
        ];

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedSeriesDescription, model.SeriesDescription);
        Assert.Equal(expectedSeriesInstanceUid, model.SeriesInstanceUid);
        Assert.Equal(expectedSeriesNumber, model.SeriesNumber);
        Assert.Equal(expectedSops.Count, model.Sops.Count);
        for (int i = 0; i < expectedSops.Count; i++)
        {
            Assert.Equal(expectedSops[i], model.Sops[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifestSeries
        {
            Modality = "CT",
            SeriesDescription = "AXIAL CT",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1",
            SeriesNumber = 1,
            Sops =
            [
                new()
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
                    RescaleIntercept = 0,
                    RescaleSlope = 0,
                    Rows = 512,
                    SamplesPerPixel = 1,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifestSeries>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedManifestSeries
        {
            Modality = "CT",
            SeriesDescription = "AXIAL CT",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1",
            SeriesNumber = 1,
            Sops =
            [
                new()
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
                    RescaleIntercept = 0,
                    RescaleSlope = 0,
                    Rows = 512,
                    SamplesPerPixel = 1,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifestSeries>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModality = "CT";
        string expectedSeriesDescription = "AXIAL CT";
        string expectedSeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1";
        SeriesNumber expectedSeriesNumber = 1;
        List<StudyAccessRequestedManifestSop> expectedSops =
        [
            new()
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
                RescaleIntercept = 0,
                RescaleSlope = 0,
                Rows = 512,
                SamplesPerPixel = 1,
            },
        ];

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedSeriesDescription, deserialized.SeriesDescription);
        Assert.Equal(expectedSeriesInstanceUid, deserialized.SeriesInstanceUid);
        Assert.Equal(expectedSeriesNumber, deserialized.SeriesNumber);
        Assert.Equal(expectedSops.Count, deserialized.Sops.Count);
        for (int i = 0; i < expectedSops.Count; i++)
        {
            Assert.Equal(expectedSops[i], deserialized.Sops[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedManifestSeries
        {
            Modality = "CT",
            SeriesDescription = "AXIAL CT",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1",
            SeriesNumber = 1,
            Sops =
            [
                new()
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
                    RescaleIntercept = 0,
                    RescaleSlope = 0,
                    Rows = 512,
                    SamplesPerPixel = 1,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedManifestSeries
        {
            Modality = "CT",
            SeriesDescription = "AXIAL CT",
            SeriesInstanceUid = "1.2.840.113619.2.55.3.1.3.1",
            SeriesNumber = 1,
            Sops =
            [
                new()
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
                    RescaleIntercept = 0,
                    RescaleSlope = 0,
                    Rows = 512,
                    SamplesPerPixel = 1,
                },
            ],
        };

        StudyAccessRequestedManifestSeries copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SeriesNumberTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SeriesNumber value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        SeriesNumber value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SeriesNumber value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SeriesNumber>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SeriesNumber value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SeriesNumber>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
