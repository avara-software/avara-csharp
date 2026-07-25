using System;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.ClinicalReferences;

namespace Avara.Tests.Models.AutoScribe.ClinicalReferences;

public class ClinicalReferenceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClinicalReferenceListParams
        {
            Cursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsActive = true,
            Limit = 20,
            Type = ClinicalReferenceType.Facility,
        };

        string expectedCursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        bool expectedIsActive = true;
        double expectedLimit = 20;
        ApiEnum<string, ClinicalReferenceType> expectedType = ClinicalReferenceType.Facility;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceListParams { IsActive = true };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceListParams
        {
            IsActive = true,

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            ExpressCustomerID = null,
            Limit = null,
            Type = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClinicalReferenceListParams
        {
            Cursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Limit = 20,
            Type = ClinicalReferenceType.Facility,
        };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawQueryData.ContainsKey("isActive"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ClinicalReferenceListParams
        {
            Cursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Limit = 20,
            Type = ClinicalReferenceType.Facility,

            IsActive = null,
        };

        Assert.Null(parameters.IsActive);
        Assert.True(parameters.RawQueryData.ContainsKey("isActive"));
    }

    [Fact]
    public void Url_Works()
    {
        ClinicalReferenceListParams parameters = new()
        {
            Cursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsActive = true,
            Limit = 20,
            Type = ClinicalReferenceType.Facility,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/clinicalReferences?cursor=eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9&expressCustomerId=cus_1234567890abcdef1234567890abcdef&isActive=true&limit=20&type=facility"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClinicalReferenceListParams
        {
            Cursor = "eyJjcmVhdGVkQXQiOiIyMDI0LTAxLTE1VDA5OjAwOjAwWiJ9",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            IsActive = true,
            Limit = 20,
            Type = ClinicalReferenceType.Facility,
        };

        ClinicalReferenceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
