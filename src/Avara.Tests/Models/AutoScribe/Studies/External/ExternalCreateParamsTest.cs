using System;
using System.Collections.Generic;
using Avara.Core;
using Avara.Models;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Studies.External;

namespace Avara.Tests.Models.AutoScribe.Studies.External;

public class ExternalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "PAT-2024-7731",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            Modality = "modality",
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            SignedAt = "x",
        };

        StudyReportMetadata expectedReportMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = HeightUnit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "CT Chest",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-01-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "CT Chest without contrast";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalPatientID = "PAT-2024-7731";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "modality";
        string expectedReaderName = "x";
        string expectedReportFileName = "x";
        string expectedReportFileUrl = "https://example.com";
        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedSignedAt = "x";

        Assert.Equal(expectedReportMetadata, parameters.ReportMetadata);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
        Assert.Equal(expectedExpressCustomerID, parameters.ExpressCustomerID);
        Assert.Equal(expectedExternalPatientID, parameters.ExternalPatientID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedModality, parameters.Modality);
        Assert.Equal(expectedReaderName, parameters.ReaderName);
        Assert.Equal(expectedReportFileName, parameters.ReportFileName);
        Assert.Equal(expectedReportFileUrl, parameters.ReportFileUrl);
        Assert.Equal(expectedReportText, parameters.ReportText);
        Assert.Equal(expectedSignedAt, parameters.SignedAt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExternalPatientID = "PAT-2024-7731",
            Modality = "modality",
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReaderName);
        Assert.False(parameters.RawBodyData.ContainsKey("readerName"));
        Assert.Null(parameters.ReportFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileName"));
        Assert.Null(parameters.ReportFileUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileUrl"));
        Assert.Null(parameters.ReportText);
        Assert.False(parameters.RawBodyData.ContainsKey("reportText"));
        Assert.Null(parameters.SignedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExternalPatientID = "PAT-2024-7731",
            Modality = "modality",

            // Null should be interpreted as omitted for these properties
            ExpressCustomerID = null,
            Metadata = null,
            ReaderName = null,
            ReportFileName = null,
            ReportFileUrl = null,
            ReportText = null,
            SignedAt = null,
        };

        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReaderName);
        Assert.False(parameters.RawBodyData.ContainsKey("readerName"));
        Assert.Null(parameters.ReportFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileName"));
        Assert.Null(parameters.ReportFileUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("reportFileUrl"));
        Assert.Null(parameters.ReportText);
        Assert.False(parameters.RawBodyData.ContainsKey("reportText"));
        Assert.Null(parameters.SignedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            SignedAt = "x",
        };

        Assert.Null(parameters.ExternalPatientID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Modality);
        Assert.False(parameters.RawBodyData.ContainsKey("modality"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            SignedAt = "x",

            ExternalPatientID = null,
            Modality = null,
        };

        Assert.Null(parameters.ExternalPatientID);
        Assert.True(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Modality);
        Assert.True(parameters.RawBodyData.ContainsKey("modality"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalCreateParams parameters = new()
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.avarasoftware.com/v1/autoScribe/studies/external"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalCreateParams
        {
            ReportMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "CT Chest",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-01-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "CT Chest without contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "PAT-2024-7731",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            Modality = "modality",
            ReaderName = "x",
            ReportFileName = "x",
            ReportFileUrl = "https://example.com",
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            SignedAt = "x",
        };

        ExternalCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
