using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ModalityWorklistRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
            Error = "Worklist not available for this AE title",
        };

        bool expectedAuthorized = true;
        List<ModalityWorklistItem> expectedItems =
        [
            new()
            {
                AccessionNumber = "ACC-98765",
                Modality = "CT",
                PatientBirthDate = "19850101",
                PatientID = "MRN-12345",
                PatientName = "DOE^JOHN",
                PatientSex = "M",
                PatientSize = "1.75",
                PatientWeight = "80",
                ProtocolName = "CHEST_WITH",
                RequestedProcedureDescription = "CT Chest w/ contrast",
                ScheduledProcedureStepSequence =
                [
                    new()
                    {
                        Modality = "CT",
                        ScheduledProcedureStepDescription = "CT Chest with contrast",
                        ScheduledProcedureStepID = "SPS-1001",
                        ScheduledProcedureStepStartDate = "20260813",
                        ScheduledProcedureStepStartTime = "090000",
                    },
                ],
                StudyDescription = "CT Chest with contrast",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        ];
        string expectedError = "Worklist not available for this AE title";

        Assert.Equal(expectedAuthorized, model.Authorized);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
            Error = "Worklist not available for this AE title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
            Error = "Worklist not available for this AE title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAuthorized = true;
        List<ModalityWorklistItem> expectedItems =
        [
            new()
            {
                AccessionNumber = "ACC-98765",
                Modality = "CT",
                PatientBirthDate = "19850101",
                PatientID = "MRN-12345",
                PatientName = "DOE^JOHN",
                PatientSex = "M",
                PatientSize = "1.75",
                PatientWeight = "80",
                ProtocolName = "CHEST_WITH",
                RequestedProcedureDescription = "CT Chest w/ contrast",
                ScheduledProcedureStepSequence =
                [
                    new()
                    {
                        Modality = "CT",
                        ScheduledProcedureStepDescription = "CT Chest with contrast",
                        ScheduledProcedureStepID = "SPS-1001",
                        ScheduledProcedureStepStartDate = "20260813",
                        ScheduledProcedureStepStartTime = "090000",
                    },
                ],
                StudyDescription = "CT Chest with contrast",
                StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
            },
        ];
        string expectedError = "Worklist not available for this AE title";

        Assert.Equal(expectedAuthorized, deserialized.Authorized);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
            Error = "Worklist not available for this AE title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
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
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModalityWorklistRequestedResponse
        {
            Authorized = true,
            Items =
            [
                new()
                {
                    AccessionNumber = "ACC-98765",
                    Modality = "CT",
                    PatientBirthDate = "19850101",
                    PatientID = "MRN-12345",
                    PatientName = "DOE^JOHN",
                    PatientSex = "M",
                    PatientSize = "1.75",
                    PatientWeight = "80",
                    ProtocolName = "CHEST_WITH",
                    RequestedProcedureDescription = "CT Chest w/ contrast",
                    ScheduledProcedureStepSequence =
                    [
                        new()
                        {
                            Modality = "CT",
                            ScheduledProcedureStepDescription = "CT Chest with contrast",
                            ScheduledProcedureStepID = "SPS-1001",
                            ScheduledProcedureStepStartDate = "20260813",
                            ScheduledProcedureStepStartTime = "090000",
                        },
                    ],
                    StudyDescription = "CT Chest with contrast",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.1234567890",
                },
            ],
            Error = "Worklist not available for this AE title",
        };

        ModalityWorklistRequestedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
