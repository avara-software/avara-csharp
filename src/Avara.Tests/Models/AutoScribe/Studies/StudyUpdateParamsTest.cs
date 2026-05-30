using System;
using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe.Studies;

namespace Avara.Tests.Models.AutoScribe.Studies;

public class StudyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "clinicalHistory",
            ClinicalIndication = "Follow-up of previously noted lesion",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "externalPatientId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Chest without contrast",
                },
            ],
            ReportMetadata = new()
            {
                Age = "age",
                DateOfBirth = "7321-69-10",
                FacilityName = "facilityName",
                Height = new() { Unit = Unit.Cm, Value = 170 },
                Mrn = "mrn",
                PatientName = "Jane M. Doe",
                Procedure = "procedure",
                ReferringPhysicianName = "referringPhysicianName",
                Sex = Sex.Female,
                StudyDate = "7321-69-10",
                StudyTime = "studyTime",
                Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
            },
            Severity = StudyUpdateParamsSeverity.High,
            StudyDescription = "Brain MRI with and without Contrast",
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedAssignedTo = "usr_1234567890abcdef1234567890abcdef";
        string expectedClinicalHistory = "clinicalHistory";
        string expectedClinicalIndication = "Follow-up of previously noted lesion";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalPatientID = "externalPatientId";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedModality = "MRI";
        List<StudyUpdateParamsPriorReport> expectedPriorReports =
        [
            new()
            {
                ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                ExternalStudyID = "EXT-2024-001",
                Modality = "CT",
                StudyDate = "2024-01-15",
                StudyDescription = "CT Chest without contrast",
            },
        ];
        ReportMetadata expectedReportMetadata = new()
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "Jane M. Doe",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };
        ApiEnum<string, StudyUpdateParamsSeverity> expectedSeverity =
            StudyUpdateParamsSeverity.High;
        string expectedStudyDescription = "Brain MRI with and without Contrast";
        List<string> expectedTechnologistNotes = ["x"];
        string expectedTechnologistTechnique = "technologistTechnique";

        Assert.Equal(expectedStudyID, parameters.StudyID);
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
        Assert.Equal(expectedReportMetadata, parameters.ReportMetadata);
        Assert.Equal(expectedSeverity, parameters.Severity);
        Assert.Equal(expectedStudyDescription, parameters.StudyDescription);
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
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "clinicalHistory",
            ClinicalIndication = "Follow-up of previously noted lesion",
            ExternalPatientID = "externalPatientId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Chest without contrast",
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.ReportMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("reportMetadata"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawBodyData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "clinicalHistory",
            ClinicalIndication = "Follow-up of previously noted lesion",
            ExternalPatientID = "externalPatientId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Chest without contrast",
                },
            ],
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",

            // Null should be interpreted as omitted for these properties
            AssignedTo = null,
            ExpressCustomerID = null,
            ReportMetadata = null,
            Severity = null,
            StudyDescription = null,
        };

        Assert.Null(parameters.AssignedTo);
        Assert.False(parameters.RawBodyData.ContainsKey("assignedTo"));
        Assert.Null(parameters.ExpressCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("expressCustomerId"));
        Assert.Null(parameters.ReportMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("reportMetadata"));
        Assert.Null(parameters.Severity);
        Assert.False(parameters.RawBodyData.ContainsKey("severity"));
        Assert.Null(parameters.StudyDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("studyDescription"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ReportMetadata = new()
            {
                Age = "age",
                DateOfBirth = "7321-69-10",
                FacilityName = "facilityName",
                Height = new() { Unit = Unit.Cm, Value = 170 },
                Mrn = "mrn",
                PatientName = "Jane M. Doe",
                Procedure = "procedure",
                ReferringPhysicianName = "referringPhysicianName",
                Sex = Sex.Female,
                StudyDate = "7321-69-10",
                StudyTime = "studyTime",
                Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
            },
            Severity = StudyUpdateParamsSeverity.High,
            StudyDescription = "Brain MRI with and without Contrast",
        };

        Assert.Null(parameters.ClinicalHistory);
        Assert.False(parameters.RawBodyData.ContainsKey("clinicalHistory"));
        Assert.Null(parameters.ClinicalIndication);
        Assert.False(parameters.RawBodyData.ContainsKey("clinicalIndication"));
        Assert.Null(parameters.ExternalPatientID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Modality);
        Assert.False(parameters.RawBodyData.ContainsKey("modality"));
        Assert.Null(parameters.PriorReports);
        Assert.False(parameters.RawBodyData.ContainsKey("priorReports"));
        Assert.Null(parameters.TechnologistNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("technologistNotes"));
        Assert.Null(parameters.TechnologistTechnique);
        Assert.False(parameters.RawBodyData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ReportMetadata = new()
            {
                Age = "age",
                DateOfBirth = "7321-69-10",
                FacilityName = "facilityName",
                Height = new() { Unit = Unit.Cm, Value = 170 },
                Mrn = "mrn",
                PatientName = "Jane M. Doe",
                Procedure = "procedure",
                ReferringPhysicianName = "referringPhysicianName",
                Sex = Sex.Female,
                StudyDate = "7321-69-10",
                StudyTime = "studyTime",
                Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
            },
            Severity = StudyUpdateParamsSeverity.High,
            StudyDescription = "Brain MRI with and without Contrast",

            ClinicalHistory = null,
            ClinicalIndication = null,
            ExternalPatientID = null,
            Metadata = null,
            Modality = null,
            PriorReports = null,
            TechnologistNotes = null,
            TechnologistTechnique = null,
        };

        Assert.Null(parameters.ClinicalHistory);
        Assert.True(parameters.RawBodyData.ContainsKey("clinicalHistory"));
        Assert.Null(parameters.ClinicalIndication);
        Assert.True(parameters.RawBodyData.ContainsKey("clinicalIndication"));
        Assert.Null(parameters.ExternalPatientID);
        Assert.True(parameters.RawBodyData.ContainsKey("externalPatientId"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Modality);
        Assert.True(parameters.RawBodyData.ContainsKey("modality"));
        Assert.Null(parameters.PriorReports);
        Assert.True(parameters.RawBodyData.ContainsKey("priorReports"));
        Assert.Null(parameters.TechnologistNotes);
        Assert.True(parameters.RawBodyData.ContainsKey("technologistNotes"));
        Assert.Null(parameters.TechnologistTechnique);
        Assert.True(parameters.RawBodyData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void Url_Works()
    {
        StudyUpdateParams parameters = new() { StudyID = "stu_1234567890abcdef1234567890abcdef" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.avarasoftware.com/v1/autoScribe/studies/stu_1234567890abcdef1234567890abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StudyUpdateParams
        {
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            AssignedTo = "usr_1234567890abcdef1234567890abcdef",
            ClinicalHistory = "clinicalHistory",
            ClinicalIndication = "Follow-up of previously noted lesion",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "externalPatientId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Modality = "MRI",
            PriorReports =
            [
                new()
                {
                    ReportText = "IMPRESSION: No acute cardiopulmonary process.",
                    ExternalStudyID = "EXT-2024-001",
                    Modality = "CT",
                    StudyDate = "2024-01-15",
                    StudyDescription = "CT Chest without contrast",
                },
            ],
            ReportMetadata = new()
            {
                Age = "age",
                DateOfBirth = "7321-69-10",
                FacilityName = "facilityName",
                Height = new() { Unit = Unit.Cm, Value = 170 },
                Mrn = "mrn",
                PatientName = "Jane M. Doe",
                Procedure = "procedure",
                ReferringPhysicianName = "referringPhysicianName",
                Sex = Sex.Female,
                StudyDate = "7321-69-10",
                StudyTime = "studyTime",
                Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
            },
            Severity = StudyUpdateParamsSeverity.High,
            StudyDescription = "Brain MRI with and without Contrast",
            TechnologistNotes = ["x"],
            TechnologistTechnique = "technologistTechnique",
        };

        StudyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StudyUpdateParamsPriorReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyUpdateParamsPriorReport
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
        var model = new StudyUpdateParamsPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyUpdateParamsPriorReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyUpdateParamsPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyUpdateParamsPriorReport>(
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
        var model = new StudyUpdateParamsPriorReport
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
        var model = new StudyUpdateParamsPriorReport
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
        var model = new StudyUpdateParamsPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyUpdateParamsPriorReport
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
        var model = new StudyUpdateParamsPriorReport
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
        var model = new StudyUpdateParamsPriorReport
        {
            ReportText = "IMPRESSION: No acute cardiopulmonary process.",
            ExternalStudyID = "EXT-2024-001",
            Modality = "CT",
            StudyDate = "2024-01-15",
            StudyDescription = "CT Chest without contrast",
        };

        StudyUpdateParamsPriorReport copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReportMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportMetadata
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "patientName",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string expectedAge = "age";
        string expectedDateOfBirth = "7321-69-10";
        string expectedFacilityName = "facilityName";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 170 };
        string expectedMrn = "mrn";
        string expectedPatientName = "patientName";
        string expectedProcedure = "procedure";
        string expectedReferringPhysicianName = "referringPhysicianName";
        ApiEnum<string, Sex> expectedSex = Sex.Female;
        string expectedStudyDate = "7321-69-10";
        string expectedStudyTime = "studyTime";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 68 };

        Assert.Equal(expectedAge, model.Age);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedFacilityName, model.FacilityName);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedMrn, model.Mrn);
        Assert.Equal(expectedPatientName, model.PatientName);
        Assert.Equal(expectedProcedure, model.Procedure);
        Assert.Equal(expectedReferringPhysicianName, model.ReferringPhysicianName);
        Assert.Equal(expectedSex, model.Sex);
        Assert.Equal(expectedStudyDate, model.StudyDate);
        Assert.Equal(expectedStudyTime, model.StudyTime);
        Assert.Equal(expectedWeight, model.Weight);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportMetadata
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "patientName",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportMetadata
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "patientName",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAge = "age";
        string expectedDateOfBirth = "7321-69-10";
        string expectedFacilityName = "facilityName";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 170 };
        string expectedMrn = "mrn";
        string expectedPatientName = "patientName";
        string expectedProcedure = "procedure";
        string expectedReferringPhysicianName = "referringPhysicianName";
        ApiEnum<string, Sex> expectedSex = Sex.Female;
        string expectedStudyDate = "7321-69-10";
        string expectedStudyTime = "studyTime";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 68 };

        Assert.Equal(expectedAge, deserialized.Age);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedFacilityName, deserialized.FacilityName);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedMrn, deserialized.Mrn);
        Assert.Equal(expectedPatientName, deserialized.PatientName);
        Assert.Equal(expectedProcedure, deserialized.Procedure);
        Assert.Equal(expectedReferringPhysicianName, deserialized.ReferringPhysicianName);
        Assert.Equal(expectedSex, deserialized.Sex);
        Assert.Equal(expectedStudyDate, deserialized.StudyDate);
        Assert.Equal(expectedStudyTime, deserialized.StudyTime);
        Assert.Equal(expectedWeight, deserialized.Weight);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportMetadata
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "patientName",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportMetadata { };

        Assert.Null(model.Age);
        Assert.False(model.RawData.ContainsKey("age"));
        Assert.Null(model.DateOfBirth);
        Assert.False(model.RawData.ContainsKey("dateOfBirth"));
        Assert.Null(model.FacilityName);
        Assert.False(model.RawData.ContainsKey("facilityName"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Mrn);
        Assert.False(model.RawData.ContainsKey("mrn"));
        Assert.Null(model.PatientName);
        Assert.False(model.RawData.ContainsKey("patientName"));
        Assert.Null(model.Procedure);
        Assert.False(model.RawData.ContainsKey("procedure"));
        Assert.Null(model.ReferringPhysicianName);
        Assert.False(model.RawData.ContainsKey("referringPhysicianName"));
        Assert.Null(model.Sex);
        Assert.False(model.RawData.ContainsKey("sex"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyTime);
        Assert.False(model.RawData.ContainsKey("studyTime"));
        Assert.Null(model.Weight);
        Assert.False(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReportMetadata
        {
            Age = null,
            DateOfBirth = null,
            FacilityName = null,
            Height = null,
            Mrn = null,
            PatientName = null,
            Procedure = null,
            ReferringPhysicianName = null,
            Sex = null,
            StudyDate = null,
            StudyTime = null,
            Weight = null,
        };

        Assert.Null(model.Age);
        Assert.True(model.RawData.ContainsKey("age"));
        Assert.Null(model.DateOfBirth);
        Assert.True(model.RawData.ContainsKey("dateOfBirth"));
        Assert.Null(model.FacilityName);
        Assert.True(model.RawData.ContainsKey("facilityName"));
        Assert.Null(model.Height);
        Assert.True(model.RawData.ContainsKey("height"));
        Assert.Null(model.Mrn);
        Assert.True(model.RawData.ContainsKey("mrn"));
        Assert.Null(model.PatientName);
        Assert.True(model.RawData.ContainsKey("patientName"));
        Assert.Null(model.Procedure);
        Assert.True(model.RawData.ContainsKey("procedure"));
        Assert.Null(model.ReferringPhysicianName);
        Assert.True(model.RawData.ContainsKey("referringPhysicianName"));
        Assert.Null(model.Sex);
        Assert.True(model.RawData.ContainsKey("sex"));
        Assert.Null(model.StudyDate);
        Assert.True(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyTime);
        Assert.True(model.RawData.ContainsKey("studyTime"));
        Assert.Null(model.Weight);
        Assert.True(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportMetadata
        {
            Age = null,
            DateOfBirth = null,
            FacilityName = null,
            Height = null,
            Mrn = null,
            PatientName = null,
            Procedure = null,
            ReferringPhysicianName = null,
            Sex = null,
            StudyDate = null,
            StudyTime = null,
            Weight = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportMetadata
        {
            Age = "age",
            DateOfBirth = "7321-69-10",
            FacilityName = "facilityName",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "mrn",
            PatientName = "patientName",
            Procedure = "procedure",
            ReferringPhysicianName = "referringPhysicianName",
            Sex = Sex.Female,
            StudyDate = "7321-69-10",
            StudyTime = "studyTime",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        ReportMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeightTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Height { Unit = Unit.Cm, Value = 170 };

        ApiEnum<string, Unit> expectedUnit = Unit.Cm;
        double expectedValue = 170;

        Assert.Equal(expectedUnit, model.Unit);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Height { Unit = Unit.Cm, Value = 170 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Height>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Height { Unit = Unit.Cm, Value = 170 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Height>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Unit> expectedUnit = Unit.Cm;
        double expectedValue = 170;

        Assert.Equal(expectedUnit, deserialized.Unit);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Height { Unit = Unit.Cm, Value = 170 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Height { Unit = Unit.Cm, Value = 170 };

        Height copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitTest : TestBase
{
    [Theory]
    [InlineData(Unit.In)]
    [InlineData(Unit.Cm)]
    public void Validation_Works(Unit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Unit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Unit.In)]
    [InlineData(Unit.Cm)]
    public void SerializationRoundtrip_Works(Unit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Unit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SexTest : TestBase
{
    [Theory]
    [InlineData(Sex.Male)]
    [InlineData(Sex.Female)]
    [InlineData(Sex.Other)]
    public void Validation_Works(Sex rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sex> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sex.Male)]
    [InlineData(Sex.Female)]
    [InlineData(Sex.Other)]
    public void SerializationRoundtrip_Works(Sex rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sex> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sex>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WeightTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Weight { Unit = WeightUnit.Kg, Value = 68 };

        ApiEnum<string, WeightUnit> expectedUnit = WeightUnit.Kg;
        double expectedValue = 68;

        Assert.Equal(expectedUnit, model.Unit);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Weight { Unit = WeightUnit.Kg, Value = 68 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Weight>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Weight { Unit = WeightUnit.Kg, Value = 68 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Weight>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, WeightUnit> expectedUnit = WeightUnit.Kg;
        double expectedValue = 68;

        Assert.Equal(expectedUnit, deserialized.Unit);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Weight { Unit = WeightUnit.Kg, Value = 68 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Weight { Unit = WeightUnit.Kg, Value = 68 };

        Weight copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeightUnitTest : TestBase
{
    [Theory]
    [InlineData(WeightUnit.Lbs)]
    [InlineData(WeightUnit.Kg)]
    public void Validation_Works(WeightUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeightUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WeightUnit.Lbs)]
    [InlineData(WeightUnit.Kg)]
    public void SerializationRoundtrip_Works(WeightUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeightUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WeightUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StudyUpdateParamsSeverityTest : TestBase
{
    [Theory]
    [InlineData(StudyUpdateParamsSeverity.Normal)]
    [InlineData(StudyUpdateParamsSeverity.High)]
    [InlineData(StudyUpdateParamsSeverity.Stat)]
    public void Validation_Works(StudyUpdateParamsSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyUpdateParamsSeverity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyUpdateParamsSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StudyUpdateParamsSeverity.Normal)]
    [InlineData(StudyUpdateParamsSeverity.High)]
    [InlineData(StudyUpdateParamsSeverity.Stat)]
    public void SerializationRoundtrip_Works(StudyUpdateParamsSeverity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StudyUpdateParamsSeverity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyUpdateParamsSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StudyUpdateParamsSeverity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StudyUpdateParamsSeverity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
