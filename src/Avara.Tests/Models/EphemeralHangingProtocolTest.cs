using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models;

namespace Avara.Tests.Models;

public class EphemeralHangingProtocolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EphemeralHangingProtocol
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };

        ApiEnum<string, ViewerLayout> expectedLayout = ViewerLayout.TwoByTwo;
        List<string?> expectedViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"];

        Assert.Equal(expectedLayout, model.Layout);
        Assert.Equal(expectedViewportAssignments.Count, model.ViewportAssignments.Count);
        for (int i = 0; i < expectedViewportAssignments.Count; i++)
        {
            Assert.Equal(expectedViewportAssignments[i], model.ViewportAssignments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EphemeralHangingProtocol
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralHangingProtocol>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EphemeralHangingProtocol
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EphemeralHangingProtocol>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ViewerLayout> expectedLayout = ViewerLayout.TwoByTwo;
        List<string?> expectedViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"];

        Assert.Equal(expectedLayout, deserialized.Layout);
        Assert.Equal(expectedViewportAssignments.Count, deserialized.ViewportAssignments.Count);
        for (int i = 0; i < expectedViewportAssignments.Count; i++)
        {
            Assert.Equal(expectedViewportAssignments[i], deserialized.ViewportAssignments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EphemeralHangingProtocol
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EphemeralHangingProtocol
        {
            Layout = ViewerLayout.TwoByTwo,
            ViewportAssignments = ["Axial T1", "Axial T2", null, "Sagittal T2"],
        };

        EphemeralHangingProtocol copied = new(model);

        Assert.Equal(model, copied);
    }
}
