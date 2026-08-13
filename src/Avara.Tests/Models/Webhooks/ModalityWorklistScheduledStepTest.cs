using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ModalityWorklistScheduledStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModalityWorklistScheduledStep
        {
            Modality = "CT",
            ScheduledProcedureStepDescription = "CT Chest with contrast",
            ScheduledProcedureStepID = "SPS-1001",
            ScheduledProcedureStepStartDate = "20260813",
            ScheduledProcedureStepStartTime = "090000",
        };

        string expectedModality = "CT";
        string expectedScheduledProcedureStepDescription = "CT Chest with contrast";
        string expectedScheduledProcedureStepID = "SPS-1001";
        string expectedScheduledProcedureStepStartDate = "20260813";
        string expectedScheduledProcedureStepStartTime = "090000";

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(
            expectedScheduledProcedureStepDescription,
            model.ScheduledProcedureStepDescription
        );
        Assert.Equal(expectedScheduledProcedureStepID, model.ScheduledProcedureStepID);
        Assert.Equal(
            expectedScheduledProcedureStepStartDate,
            model.ScheduledProcedureStepStartDate
        );
        Assert.Equal(
            expectedScheduledProcedureStepStartTime,
            model.ScheduledProcedureStepStartTime
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModalityWorklistScheduledStep
        {
            Modality = "CT",
            ScheduledProcedureStepDescription = "CT Chest with contrast",
            ScheduledProcedureStepID = "SPS-1001",
            ScheduledProcedureStepStartDate = "20260813",
            ScheduledProcedureStepStartTime = "090000",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistScheduledStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModalityWorklistScheduledStep
        {
            Modality = "CT",
            ScheduledProcedureStepDescription = "CT Chest with contrast",
            ScheduledProcedureStepID = "SPS-1001",
            ScheduledProcedureStepStartDate = "20260813",
            ScheduledProcedureStepStartTime = "090000",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistScheduledStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModality = "CT";
        string expectedScheduledProcedureStepDescription = "CT Chest with contrast";
        string expectedScheduledProcedureStepID = "SPS-1001";
        string expectedScheduledProcedureStepStartDate = "20260813";
        string expectedScheduledProcedureStepStartTime = "090000";

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(
            expectedScheduledProcedureStepDescription,
            deserialized.ScheduledProcedureStepDescription
        );
        Assert.Equal(expectedScheduledProcedureStepID, deserialized.ScheduledProcedureStepID);
        Assert.Equal(
            expectedScheduledProcedureStepStartDate,
            deserialized.ScheduledProcedureStepStartDate
        );
        Assert.Equal(
            expectedScheduledProcedureStepStartTime,
            deserialized.ScheduledProcedureStepStartTime
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModalityWorklistScheduledStep
        {
            Modality = "CT",
            ScheduledProcedureStepDescription = "CT Chest with contrast",
            ScheduledProcedureStepID = "SPS-1001",
            ScheduledProcedureStepStartDate = "20260813",
            ScheduledProcedureStepStartTime = "090000",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModalityWorklistScheduledStep
        {
            Modality = "CT",
            ScheduledProcedureStepDescription = "CT Chest with contrast",
            ScheduledProcedureStepID = "SPS-1001",
            ScheduledProcedureStepStartDate = "20260813",
            ScheduledProcedureStepStartTime = "090000",
        };

        ModalityWorklistScheduledStep copied = new(model);

        Assert.Equal(model, copied);
    }
}
