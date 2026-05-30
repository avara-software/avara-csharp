using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Reports;

namespace Avara.Tests.Models.AutoScribe.Reports;

public class ReportPdfResponseTest : TestBase
{
    [Fact]
    public void SingleValidationWorks()
    {
        ReportPdfResponse value = new SingleReportPdfResponse()
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        value.Validate();
    }

    [Fact]
    public void ListReportsValidationWorks()
    {
        ReportPdfResponse value = new ListReportsPdfResponse()
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        ReportPdfResponse value = new SingleReportPdfResponse()
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportPdfResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListReportsSerializationRoundtripWorks()
    {
        ReportPdfResponse value = new ListReportsPdfResponse()
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportPdfResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SingleReportPdfResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SingleReportPdfResponse
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123";
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

        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SingleReportPdfResponse
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleReportPdfResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SingleReportPdfResponse
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SingleReportPdfResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123";
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

        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SingleReportPdfResponse
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
    public void CopyConstructor_Works()
    {
        var model = new SingleReportPdfResponse
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        SingleReportPdfResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ListReportsPdfResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListReportsPdfResponse
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        List<ListReportsPdfResponseReport> expectedReports =
        [
            new()
            {
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        var model = new ListReportsPdfResponse
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsPdfResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListReportsPdfResponse
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsPdfResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ListReportsPdfResponseReport> expectedReports =
        [
            new()
            {
                PresignedUrl =
                    "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        var model = new ListReportsPdfResponse
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
        var model = new ListReportsPdfResponse
        {
            Reports =
            [
                new()
                {
                    PresignedUrl =
                        "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
                },
            ],
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
        };

        ListReportsPdfResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ListReportsPdfResponseReportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListReportsPdfResponseReport
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123";
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

        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedReportID, model.ReportID);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListReportsPdfResponseReport
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsPdfResponseReport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListReportsPdfResponseReport
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListReportsPdfResponseReport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPresignedUrl =
            "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123";
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

        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedReportID, deserialized.ReportID);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListReportsPdfResponseReport
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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
    public void CopyConstructor_Works()
    {
        var model = new ListReportsPdfResponseReport
        {
            PresignedUrl = "https://storage.avarasoftware.com/reports/rep_1234.pdf?token=abc123",
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

        ListReportsPdfResponseReport copied = new(model);

        Assert.Equal(model, copied);
    }
}
