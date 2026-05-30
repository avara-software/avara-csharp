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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "Hypertension; prior migraine history",
            ClinicalIndication = "Persistent headaches, rule out intracranial mass",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "PAT-2024-7731",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute intracranial abnormality.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Head without contrast",
                },
            ],
            TechnologistNotes =
            [
                "Patient tolerated contrast well",
                "Slight motion on initial sequence, repeated",
            ],
            TechnologistTechnique =
                "Multiplanar multisequence MRI of the brain with and without IV contrast",
        };

        AutoScribe::StudyReportMetadata expectedReportMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = AutoScribe::Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = AutoScribe::Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
        };
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        string expectedStudyDescription = "Brain MRI with Contrast";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        string expectedClinicalHistory = "Hypertension; prior migraine history";
        string expectedClinicalIndication = "Persistent headaches, rule out intracranial mass";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalPatientID = "PAT-2024-7731";
        Dictionary<string, string> expectedMetadata = new()
        {
            { "department", "radiology" },
            { "priority", "routine" },
        };
        string expectedModality = "MRI";
        List<PriorReport> expectedPriorReports =
        [
            new()
            {
                ReportText = "IMPRESSION: No acute intracranial abnormality.",
                ExternalStudyID = "EXT-2024-001",
                Modality = "CT",
                StudyDate = "2024-01-15",
                StudyDescription = "CT Head without contrast",
            },
        ];
        List<string> expectedTechnologistNotes =
        [
            "Patient tolerated contrast well",
            "Slight motion on initial sequence, repeated",
        ];
        string expectedTechnologistTechnique =
            "Multiplanar multisequence MRI of the brain with and without IV contrast";

        Assert.Equal(expectedReportMetadata, parameters.ReportMetadata);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
        Assert.Equal(expectedStudyInstanceUid, parameters.StudyInstanceUid);
        Assert.Equal(expectedAssignedTo, parameters.AssignedTo);
        Assert.Equal(expectedClinicalHistory, parameters.ClinicalHistory);
        Assert.Equal(expectedClinicalIndication, parameters.ClinicalIndication);
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
        Assert.NotNull(parameters.PriorReports);
        Assert.Equal(expectedPriorReports.Count, parameters.PriorReports.Count);
        for (int i = 0; i < expectedPriorReports.Count; i++)
        {
            Assert.Equal(expectedPriorReports[i], parameters.PriorReports[i]);
        }
        Assert.NotNull(parameters.TechnologistNotes);
        Assert.Equal(expectedTechnologistNotes.Count, parameters.TechnologistNotes.Count);
        for (int i = 0; i < expectedTechnologistNotes.Count; i++)
        {
            Assert.Equal(expectedTechnologistNotes[i], parameters.TechnologistNotes[i]);
        }
        Assert.Equal(expectedTechnologistTechnique, parameters.TechnologistTechnique);
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ClinicalHistory = "Hypertension; prior migraine history",
            ClinicalIndication = "Persistent headaches, rule out intracranial mass",
            ExternalPatientID = "PAT-2024-7731",
            Modality = "MRI",
            TechnologistTechnique =
                "Multiplanar multisequence MRI of the brain with and without IV contrast",
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriorReports);
        Assert.False(parameters.RawBodyData.ContainsKey("priorReports"));
        Assert.Null(parameters.TechnologistNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("technologistNotes"));
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            ClinicalHistory = "Hypertension; prior migraine history",
            ClinicalIndication = "Persistent headaches, rule out intracranial mass",
            ExternalPatientID = "PAT-2024-7731",
            Modality = "MRI",
            TechnologistTechnique =
                "Multiplanar multisequence MRI of the brain with and without IV contrast",

            // Null should be interpreted as omitted for these properties
            AssignedTo = null,
            ExpressCustomerID = null,
            Metadata = null,
            PriorReports = null,
            TechnologistNotes = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriorReports);
        Assert.False(parameters.RawBodyData.ContainsKey("priorReports"));
        Assert.Null(parameters.TechnologistNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("technologistNotes"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute intracranial abnormality.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Head without contrast",
                },
            ],
            TechnologistNotes =
            [
                "Patient tolerated contrast well",
                "Slight motion on initial sequence, repeated",
            ],
        };

        Assert.Null(parameters.ClinicalHistory);
        Assert.False(parameters.RawBodyData.ContainsKey("clinicalHistory"));
        Assert.Null(parameters.ClinicalIndication);
        Assert.False(parameters.RawBodyData.ContainsKey("clinicalIndication"));
        Assert.Null(parameters.ExternalPatientID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Modality);
        Assert.False(parameters.RawBodyData.ContainsKey("modality"));
        Assert.Null(parameters.TechnologistTechnique);
        Assert.False(parameters.RawBodyData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute intracranial abnormality.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Head without contrast",
                },
            ],
            TechnologistNotes =
            [
                "Patient tolerated contrast well",
                "Slight motion on initial sequence, repeated",
            ],

            ClinicalHistory = null,
            ClinicalIndication = null,
            ExternalPatientID = null,
            Modality = null,
            TechnologistTechnique = null,
        };

        Assert.Null(parameters.ClinicalHistory);
        Assert.True(parameters.RawBodyData.ContainsKey("clinicalHistory"));
        Assert.Null(parameters.ClinicalIndication);
        Assert.True(parameters.RawBodyData.ContainsKey("clinicalIndication"));
        Assert.Null(parameters.ExternalPatientID);
        Assert.True(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Modality);
        Assert.True(parameters.RawBodyData.ContainsKey("modality"));
        Assert.Null(parameters.TechnologistTechnique);
        Assert.True(parameters.RawBodyData.ContainsKey("technologistTechnique"));
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
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
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = AutoScribe::Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = AutoScribe::WeightUnit.Kg, Value = 62 },
            },
            Severity = Severity.Normal,
            StudyDescription = "Brain MRI with Contrast",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "Hypertension; prior migraine history",
            ClinicalIndication = "Persistent headaches, rule out intracranial mass",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "PAT-2024-7731",
            Metadata = new Dictionary<string, string>()
            {
                { "department", "radiology" },
                { "priority", "routine" },
            },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute intracranial abnormality.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Head without contrast",
                },
            ],
            TechnologistNotes =
            [
                "Patient tolerated contrast well",
                "Slight motion on initial sequence, repeated",
            ],
            TechnologistTechnique =
                "Multiplanar multisequence MRI of the brain with and without IV contrast",
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

public class PriorReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, model.ReportText);
        Assert.Equal(expectedExternalStudyID, model.ExternalStudyID);
        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedStudyDate, model.StudyDate);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriorReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriorReport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReportText = "IMPRESSION: No acute cardiopulmonary process.";
        string expectedExternalStudyID = "EXT-2024-001";
        string expectedModality = "CT";
        string expectedStudyDate = "2024-01-15";
        string expectedStudyDescription = "CT Chest without contrast";

        Assert.Equal(expectedReportText, deserialized.ReportText);
        Assert.Equal(expectedExternalStudyID, deserialized.ExternalStudyID);
        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedStudyDate, deserialized.StudyDate);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        Assert.Null(model.ExternalStudyID);
        Assert.False(model.RawData.ContainsKey("externalStudyId"));
        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",

            // Null should be interpreted as omitted for these properties
            ExternalStudyID = null,
            Modality = null,
            StudyDate = null,
            StudyDescription = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        PriorReport copied = new(model);

        Assert.Equal(model, copied);
    }
}
