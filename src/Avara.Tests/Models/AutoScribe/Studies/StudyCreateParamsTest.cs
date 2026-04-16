using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies;
using AutoScribe = Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = AutoScribe::Sex.Female,
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            PriorReportTexts = ["x"],
            PriorStudyIds = ["string"],
        };

        AutoScribe::StudyReportMetadata expectedReportMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            ReferringPhysicianName = "Dr. Michael Chen",
            ScanDate = "2024-03-15",
            ScanTime = "14:30",
            ScanType = "MRI Brain with Contrast",
            Sex = AutoScribe::Sex.Female,
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        List<string> expectedPriorReportTexts = ["x"];
        List<string> expectedPriorStudyIds = ["string"];

        Assert.Equal(expectedReportMetadata, parameters.ReportMetadata);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.NotNull(parameters.PriorReportTexts);
        Assert.Equal(expectedPriorReportTexts.Count, parameters.PriorReportTexts.Count);
        for (int i = 0; i < expectedPriorReportTexts.Count; i++)
        {
            Assert.Equal(expectedPriorReportTexts[i], parameters.PriorReportTexts[i]);
        }
        Assert.NotNull(parameters.PriorStudyIds);
        Assert.Equal(expectedPriorStudyIds.Count, parameters.PriorStudyIds.Count);
        for (int i = 0; i < expectedPriorStudyIds.Count; i++)
        {
            Assert.Equal(expectedPriorStudyIds[i], parameters.PriorStudyIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = AutoScribe::Sex.Female,
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriorReportTexts);
        Assert.False(parameters.RawBodyData.ContainsKey("priorReportTexts"));
        Assert.Null(parameters.PriorStudyIds);
        Assert.False(parameters.RawBodyData.ContainsKey("priorStudyIds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = AutoScribe::Sex.Female,
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            // Null should be interpreted as omitted for these properties
            AssignedTo = null,
            ExpressCustomerID = null,
            Metadata = null,
            PriorReportTexts = null,
            PriorStudyIds = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriorReportTexts);
        Assert.False(parameters.RawBodyData.ContainsKey("priorReportTexts"));
        Assert.Null(parameters.PriorStudyIds);
        Assert.False(parameters.RawBodyData.ContainsKey("priorStudyIds"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyCreateParams parameters = new()
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = AutoScribe::Sex.Female,
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.avarasoftware.com/v1/autoScribe/studies"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                ReferringPhysicianName = "Dr. Michael Chen",
                ScanDate = "2024-03-15",
                ScanTime = "14:30",
                ScanType = "MRI Brain with Contrast",
                Sex = AutoScribe::Sex.Female,
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            PriorReportTexts = ["x"],
            PriorStudyIds = ["string"],
        };

        StudyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SeverityTest : TestBase
{
    [Theory]
    [InlineData(Severity.Normal)]
    [InlineData(Severity.High)]
    [InlineData(Severity.Stat)]
    public void Validation_Works(Severity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Severity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Severity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Severity.Normal)]
    [InlineData(Severity.High)]
    [InlineData(Severity.Stat)]
    public void SerializationRoundtrip_Works(Severity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Severity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Severity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Severity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Severity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
