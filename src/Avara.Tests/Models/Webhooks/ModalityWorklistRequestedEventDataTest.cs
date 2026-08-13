using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ModalityWorklistRequestedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };

        string expectedCallingAe = "CT_SCANNER_01";
        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedDateEnd = "2026-08-13";
        string expectedDateStart = "2026-08-13";
        string expectedSourceIP = "10.0.0.25";
        string expectedModality = "CT";

        Assert.Equal(expectedCallingAe, model.CallingAe);
        Assert.Equal(expectedClinicID, model.ClinicID);
        Assert.Equal(expectedDateEnd, model.DateEnd);
        Assert.Equal(expectedDateStart, model.DateStart);
        Assert.Equal(expectedSourceIP, model.SourceIP);
        Assert.Equal(expectedModality, model.Modality);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModalityWorklistRequestedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallingAe = "CT_SCANNER_01";
        string expectedClinicID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedDateEnd = "2026-08-13";
        string expectedDateStart = "2026-08-13";
        string expectedSourceIP = "10.0.0.25";
        string expectedModality = "CT";

        Assert.Equal(expectedCallingAe, deserialized.CallingAe);
        Assert.Equal(expectedClinicID, deserialized.ClinicID);
        Assert.Equal(expectedDateEnd, deserialized.DateEnd);
        Assert.Equal(expectedDateStart, deserialized.DateStart);
        Assert.Equal(expectedSourceIP, deserialized.SourceIP);
        Assert.Equal(expectedModality, deserialized.Modality);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",

            // Null should be interpreted as omitted for these properties
            Modality = null,
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",

            // Null should be interpreted as omitted for these properties
            Modality = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModalityWorklistRequestedEventData
        {
            CallingAe = "CT_SCANNER_01",
            ClinicID = "123e4567-e89b-12d3-a456-426614174000",
            DateEnd = "2026-08-13",
            DateStart = "2026-08-13",
            SourceIP = "10.0.0.25",
            Modality = "CT",
        };

        ModalityWorklistRequestedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
