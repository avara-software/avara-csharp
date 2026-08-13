using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ModalityWorklistItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModalityWorklistItem
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
        };

        string expectedAccessionNumber = "ACC-98765";
        string expectedModality = "CT";
        string expectedPatientBirthDate = "19850101";
        string expectedPatientID = "MRN-12345";
        string expectedPatientName = "DOE^JOHN";
        string expectedPatientSex = "M";
        string expectedPatientSize = "1.75";
        string expectedPatientWeight = "80";
        string expectedProtocolName = "CHEST_WITH";
        string expectedRequestedProcedureDescription = "CT Chest w/ contrast";
        List<ModalityWorklistScheduledStep> expectedScheduledProcedureStepSequence =
        [
            new()
            {
                Modality = "CT",
                ScheduledProcedureStepDescription = "CT Chest with contrast",
                ScheduledProcedureStepID = "SPS-1001",
                ScheduledProcedureStepStartDate = "20260813",
                ScheduledProcedureStepStartTime = "090000",
            },
        ];
        string expectedStudyDescription = "CT Chest with contrast";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedAccessionNumber, model.AccessionNumber);
        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedPatientBirthDate, model.PatientBirthDate);
        Assert.Equal(expectedPatientID, model.PatientID);
        Assert.Equal(expectedPatientName, model.PatientName);
        Assert.Equal(expectedPatientSex, model.PatientSex);
        Assert.Equal(expectedPatientSize, model.PatientSize);
        Assert.Equal(expectedPatientWeight, model.PatientWeight);
        Assert.Equal(expectedProtocolName, model.ProtocolName);
        Assert.Equal(expectedRequestedProcedureDescription, model.RequestedProcedureDescription);
        Assert.Equal(
            expectedScheduledProcedureStepSequence.Count,
            model.ScheduledProcedureStepSequence.Count
        );
        for (int i = 0; i < expectedScheduledProcedureStepSequence.Count; i++)
        {
            Assert.Equal(
                expectedScheduledProcedureStepSequence[i],
                model.ScheduledProcedureStepSequence[i]
            );
        }
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModalityWorklistItem
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModalityWorklistItem
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessionNumber = "ACC-98765";
        string expectedModality = "CT";
        string expectedPatientBirthDate = "19850101";
        string expectedPatientID = "MRN-12345";
        string expectedPatientName = "DOE^JOHN";
        string expectedPatientSex = "M";
        string expectedPatientSize = "1.75";
        string expectedPatientWeight = "80";
        string expectedProtocolName = "CHEST_WITH";
        string expectedRequestedProcedureDescription = "CT Chest w/ contrast";
        List<ModalityWorklistScheduledStep> expectedScheduledProcedureStepSequence =
        [
            new()
            {
                Modality = "CT",
                ScheduledProcedureStepDescription = "CT Chest with contrast",
                ScheduledProcedureStepID = "SPS-1001",
                ScheduledProcedureStepStartDate = "20260813",
                ScheduledProcedureStepStartTime = "090000",
            },
        ];
        string expectedStudyDescription = "CT Chest with contrast";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.1234567890";

        Assert.Equal(expectedAccessionNumber, deserialized.AccessionNumber);
        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedPatientBirthDate, deserialized.PatientBirthDate);
        Assert.Equal(expectedPatientID, deserialized.PatientID);
        Assert.Equal(expectedPatientName, deserialized.PatientName);
        Assert.Equal(expectedPatientSex, deserialized.PatientSex);
        Assert.Equal(expectedPatientSize, deserialized.PatientSize);
        Assert.Equal(expectedPatientWeight, deserialized.PatientWeight);
        Assert.Equal(expectedProtocolName, deserialized.ProtocolName);
        Assert.Equal(
            expectedRequestedProcedureDescription,
            deserialized.RequestedProcedureDescription
        );
        Assert.Equal(
            expectedScheduledProcedureStepSequence.Count,
            deserialized.ScheduledProcedureStepSequence.Count
        );
        for (int i = 0; i < expectedScheduledProcedureStepSequence.Count; i++)
        {
            Assert.Equal(
                expectedScheduledProcedureStepSequence[i],
                deserialized.ScheduledProcedureStepSequence[i]
            );
        }
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModalityWorklistItem
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModalityWorklistItem
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
        };

        ModalityWorklistItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
