using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class EphemeralAccessRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Retrieval handle not found",
            Manifests =
            [
                new()
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
                },
            ],
            MediaUrls =
            [
                new()
                {
                    MimeType = "application/pdf",
                    Url = "https://storage.example.com/media/report.pdf?token=abc123",
                    FileName = "clinical-report.pdf",
                },
            ],
        };

        bool expectedAuthorized = true;
        List<string> expectedUrls =
        [
            "https://storage.example.com/dicom/image1.dcm?token=abc123",
            "https://storage.example.com/dicom/image2.dcm?token=def456",
        ];
        string expectedError = "Retrieval handle not found";
        List<StudyAccessRequestedManifest> expectedManifests =
        [
            new()
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
            },
        ];
        List<StudyAccessRequestedMediaUrl> expectedMediaUrls =
        [
            new()
            {
                MimeType = "application/pdf",
                Url = "https://storage.example.com/media/report.pdf?token=abc123",
                FileName = "clinical-report.pdf",
            },
        ];

        Assert.Equal(expectedAuthorized, model.Authorized);
        Assert.Equal(expectedUrls.Count, model.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], model.Urls[i]);
        }
        Assert.Equal(expectedError, model.Error);
        Assert.NotNull(model.Manifests);
        Assert.Equal(expectedManifests.Count, model.Manifests.Count);
        for (int i = 0; i < expectedManifests.Count; i++)
        {
            Assert.Equal(expectedManifests[i], model.Manifests[i]);
        }
        Assert.NotNull(model.MediaUrls);
        Assert.Equal(expectedMediaUrls.Count, model.MediaUrls.Count);
        for (int i = 0; i < expectedMediaUrls.Count; i++)
        {
            Assert.Equal(expectedMediaUrls[i], model.MediaUrls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Retrieval handle not found",
            Manifests =
            [
                new()
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
                },
            ],
            MediaUrls =
            [
                new()
                {
                    MimeType = "application/pdf",
                    Url = "https://storage.example.com/media/report.pdf?token=abc123",
                    FileName = "clinical-report.pdf",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Retrieval handle not found",
            Manifests =
            [
                new()
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
                },
            ],
            MediaUrls =
            [
                new()
                {
                    MimeType = "application/pdf",
                    Url = "https://storage.example.com/media/report.pdf?token=abc123",
                    FileName = "clinical-report.pdf",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralAccessRequestedResponse>(
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
        string expectedError = "Retrieval handle not found";
        List<StudyAccessRequestedManifest> expectedManifests =
        [
            new()
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
            },
        ];
        List<StudyAccessRequestedMediaUrl> expectedMediaUrls =
        [
            new()
            {
                MimeType = "application/pdf",
                Url = "https://storage.example.com/media/report.pdf?token=abc123",
                FileName = "clinical-report.pdf",
            },
        ];

        Assert.Equal(expectedAuthorized, deserialized.Authorized);
        Assert.Equal(expectedUrls.Count, deserialized.Urls.Count);
        for (int i = 0; i < expectedUrls.Count; i++)
        {
            Assert.Equal(expectedUrls[i], deserialized.Urls[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.NotNull(deserialized.Manifests);
        Assert.Equal(expectedManifests.Count, deserialized.Manifests.Count);
        for (int i = 0; i < expectedManifests.Count; i++)
        {
            Assert.Equal(expectedManifests[i], deserialized.Manifests[i]);
        }
        Assert.NotNull(deserialized.MediaUrls);
        Assert.Equal(expectedMediaUrls.Count, deserialized.MediaUrls.Count);
        for (int i = 0; i < expectedMediaUrls.Count; i++)
        {
            Assert.Equal(expectedMediaUrls[i], deserialized.MediaUrls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Retrieval handle not found",
            Manifests =
            [
                new()
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
                },
            ],
            MediaUrls =
            [
                new()
                {
                    MimeType = "application/pdf",
                    Url = "https://storage.example.com/media/report.pdf?token=abc123",
                    FileName = "clinical-report.pdf",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EphemeralAccessRequestedResponse
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
        Assert.Null(model.Manifests);
        Assert.False(model.RawData.ContainsKey("manifests"));
        Assert.Null(model.MediaUrls);
        Assert.False(model.RawData.ContainsKey("mediaUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EphemeralAccessRequestedResponse
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
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],

            // Null should be interpreted as omitted for these properties
            Error = null,
            Manifests = null,
            MediaUrls = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Manifests);
        Assert.False(model.RawData.ContainsKey("manifests"));
        Assert.Null(model.MediaUrls);
        Assert.False(model.RawData.ContainsKey("mediaUrls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],

            // Null should be interpreted as omitted for these properties
            Error = null,
            Manifests = null,
            MediaUrls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EphemeralAccessRequestedResponse
        {
            Authorized = true,
            Urls =
            [
                "https://storage.example.com/dicom/image1.dcm?token=abc123",
                "https://storage.example.com/dicom/image2.dcm?token=def456",
            ],
            Error = "Retrieval handle not found",
            Manifests =
            [
                new()
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
                },
            ],
            MediaUrls =
            [
                new()
                {
                    MimeType = "application/pdf",
                    Url = "https://storage.example.com/media/report.pdf?token=abc123",
                    FileName = "clinical-report.pdf",
                },
            ],
        };

        EphemeralAccessRequestedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
