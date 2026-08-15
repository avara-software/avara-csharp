using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class StudyAccessRequestedManifestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifest
        {
            Series =
            [
                new()
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
                            RescaleIntercept = -1024,
                            RescaleSlope = 1,
                            Rows = 512,
                            SamplesPerPixel = 1,
                        },
                    ],
                },
            ],
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        List<StudyAccessRequestedManifestSeries> expectedSeries =
        [
            new()
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
                        RescaleIntercept = -1024,
                        RescaleSlope = 1,
                        Rows = 512,
                        SamplesPerPixel = 1,
                    },
                ],
            },
        ];
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedSeries.Count, model.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], model.Series[i]);
        }
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StudyAccessRequestedManifest
        {
            Series =
            [
                new()
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
                            RescaleIntercept = -1024,
                            RescaleSlope = 1,
                            Rows = 512,
                            SamplesPerPixel = 1,
                        },
                    ],
                },
            ],
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyAccessRequestedManifest
        {
            Series =
            [
                new()
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
                            RescaleIntercept = -1024,
                            RescaleSlope = 1,
                            Rows = 512,
                            SamplesPerPixel = 1,
                        },
                    ],
                },
            ],
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyAccessRequestedManifest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<StudyAccessRequestedManifestSeries> expectedSeries =
        [
            new()
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
                        RescaleIntercept = -1024,
                        RescaleSlope = 1,
                        Rows = 512,
                        SamplesPerPixel = 1,
                    },
                ],
            },
        ];
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedSeries.Count, deserialized.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], deserialized.Series[i]);
        }
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StudyAccessRequestedManifest
        {
            Series =
            [
                new()
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
                            RescaleIntercept = -1024,
                            RescaleSlope = 1,
                            Rows = 512,
                            SamplesPerPixel = 1,
                        },
                    ],
                },
            ],
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StudyAccessRequestedManifest
        {
            Series =
            [
                new()
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
                            RescaleIntercept = -1024,
                            RescaleSlope = 1,
                            Rows = 512,
                            SamplesPerPixel = 1,
                        },
                    ],
                },
            ],
            StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
        };

        StudyAccessRequestedManifest copied = new(model);

        Assert.Equal(model, copied);
    }
}
