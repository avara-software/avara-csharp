using System.Text.Json;
using Avara.Core;
using Avara.Models;

namespace Avara.Tests.Models;

public class ExpressCustomerReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExpressCustomerReference
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center";

        Assert.Equal(expectedExpressCustomerID, model.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, model.ExpressCustomerName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExpressCustomerReference
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressCustomerReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExpressCustomerReference
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExpressCustomerReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerName = "City Medical Center";

        Assert.Equal(expectedExpressCustomerID, deserialized.ExpressCustomerID);
        Assert.Equal(expectedExpressCustomerName, deserialized.ExpressCustomerName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExpressCustomerReference
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExpressCustomerReference
        {
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExpressCustomerName = "City Medical Center",
        };

        ExpressCustomerReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
