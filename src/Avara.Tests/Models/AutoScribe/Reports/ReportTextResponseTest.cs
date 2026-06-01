using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportTextResponseTest : TestBase
{
    [Fact]
    public void SingleValidationWorks()
    {
        ReportTextResponse value = new SingleReportTextResponse()
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };
        value.Validate();
    }

    [Fact]
    public void ListReportsValidationWorks()
    {
        ReportTextResponse value = new ListReportsTextResponse()
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };
        value.Validate();
    }

    [Fact]
    public void SingleSerializationRoundtripWorks()
    {
        ReportTextResponse value = new SingleReportTextResponse()
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportTextResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListReportsSerializationRoundtripWorks()
    {
        ReportTextResponse value = new ListReportsTextResponse()
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportTextResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SingleReportTextResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = HeightUnit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedIsCritical, model.IsCritical);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedPlainText, model.PlainText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleReportTextResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleReportTextResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsCritical = false;
        string expectedReportID = "rep_1234567890abcdef1234567890abcdef";
        StudyReportMetadata expectedSnapshotMetadata = new()
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = HeightUnit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPlainText =
            "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.";

        Assert.Equal(expectedIsCritical, deserialized.IsCritical);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedPlainText, deserialized.PlainText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        Assert.Null(model.PlainText);
        Assert.False(model.RawData.ContainsKey("plainText"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",

            // Null should be interpreted as omitted for these properties
            PlainText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SingleReportTextResponse
        {
            IsCritical = false,
            ReportID = "rep_1234567890abcdef1234567890abcdef",
            SnapshotMetadata = new()
            {
                Age = "38 years",
                DateOfBirth = "1985-07-20",
                FacilityName = "City Medical Center",
                Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                Mrn = "MRN-2024-001234",
                PatientName = "Jane Doe",
                Procedure = "MRI Brain with Contrast",
                ReferringPhysicianName = "Dr. Michael Chen",
                Sex = Sex.Female,
                StudyDate = "2024-03-15",
                StudyTime = "14:30",
                Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
            },
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PlainText =
                "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
        };

        SingleReportTextResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ListReportsTextResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListReportsTextResponse
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        List<ReportTextItem> expectedReports =
        [
            new()
            {
                IsCritical = false,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                SnapshotMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    Procedure = "MRI Brain with Contrast",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    Sex = Sex.Female,
                    StudyDate = "2024-03-15",
                    StudyTime = "14:30",
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                PlainText =
                    "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
            },
        ];
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedReports.Count, model.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], model.Reports[i]);
        }
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListReportsTextResponse
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsTextResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListReportsTextResponse
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsTextResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ReportTextItem> expectedReports =
        [
            new()
            {
                IsCritical = false,
                ReportID = "rep_1234567890abcdef1234567890abcdef",
                SnapshotMetadata = new()
                {
                    Age = "38 years",
                    DateOfBirth = "1985-07-20",
                    FacilityName = "City Medical Center",
                    Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                    Mrn = "MRN-2024-001234",
                    PatientName = "Jane Doe",
                    Procedure = "MRI Brain with Contrast",
                    ReferringPhysicianName = "Dr. Michael Chen",
                    Sex = Sex.Female,
                    StudyDate = "2024-03-15",
                    StudyTime = "14:30",
                    Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                },
                StudyID = "stu_1234567890abcdef1234567890abcdef",
                StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                PlainText =
                    "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
            },
        ];
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";

        Assert.Equal(expectedReports.Count, deserialized.Reports.Count);
        for (int i = 0; i < expectedReports.Count; i++)
        {
            Assert.Equal(expectedReports[i], deserialized.Reports[i]);
        }
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListReportsTextResponse
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ListReportsTextResponse
        {
            Reports =
            [
                new()
                {
                    IsCritical = false,
                    ReportID = "rep_1234567890abcdef1234567890abcdef",
                    SnapshotMetadata = new()
                    {
                        Age = "38 years",
                        DateOfBirth = "1985-07-20",
                        FacilityName = "City Medical Center",
                        Height = new() { Unit = HeightUnit.Cm, Value = 165 },
                        Mrn = "MRN-2024-001234",
                        PatientName = "Jane Doe",
                        Procedure = "MRI Brain with Contrast",
                        ReferringPhysicianName = "Dr. Michael Chen",
                        Sex = Sex.Female,
                        StudyDate = "2024-03-15",
                        StudyTime = "14:30",
                        Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
                    },
                    StudyID = "stu_1234567890abcdef1234567890abcdef",
                    StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
                    PlainText =
                        "FINDINGS: Normal brain MRI. No acute intracranial abnormality. IMPRESSION: Unremarkable brain MRI.",
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        ListReportsTextResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
