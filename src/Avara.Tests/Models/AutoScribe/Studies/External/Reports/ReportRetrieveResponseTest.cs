using System;
using System.Text.Json;
using Avara.Core;
using Avara.Models.AutoScribe;
using Avara.Models.AutoScribe.Studies.External.Reports;

namespace Avara.Tests.Models.AutoScribe.Studies.External.Reports;

public class ReportRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
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
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalReportID = "ext_1234567890abcdef1234567890abcdef";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234";
        string expectedReaderName = "readerName";
        string expectedReportText = "reportText";
        string expectedSignedAt = "signedAt";
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

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExternalReportID, model.ExternalReportID);
        Assert.Equal(expectedStudyID, model.StudyID);
        Assert.Equal(expectedStudyInstanceUid, model.StudyInstanceUid);
        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedReaderName, model.ReaderName);
        Assert.Equal(expectedReportText, model.ReportText);
        Assert.Equal(expectedSignedAt, model.SignedAt);
        Assert.Equal(expectedSnapshotMetadata, model.SnapshotMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReportRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalReportID = "ext_1234567890abcdef1234567890abcdef";
        string expectedStudyID = "stu_1234567890abcdef1234567890abcdef";
        string expectedStudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123";
        string expectedPresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234";
        string expectedReaderName = "readerName";
        string expectedReportText = "reportText";
        string expectedSignedAt = "signedAt";
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

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExternalReportID, deserialized.ExternalReportID);
        Assert.Equal(expectedStudyID, deserialized.StudyID);
        Assert.Equal(expectedStudyInstanceUid, deserialized.StudyInstanceUid);
        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedReaderName, deserialized.ReaderName);
        Assert.Equal(expectedReportText, deserialized.ReportText);
        Assert.Equal(expectedSignedAt, deserialized.SignedAt);
        Assert.Equal(expectedSnapshotMetadata, deserialized.SnapshotMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
        };

        Assert.Null(model.SnapshotMetadata);
        Assert.False(model.RawData.ContainsKey("snapshotMetadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",

            // Null should be interpreted as omitted for these properties
            SnapshotMetadata = null,
        };

        Assert.Null(model.SnapshotMetadata);
        Assert.False(model.RawData.ContainsKey("snapshotMetadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",

            // Null should be interpreted as omitted for these properties
            SnapshotMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
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
        };

        Assert.Null(model.PresignedUrl);
        Assert.False(model.RawData.ContainsKey("presignedUrl"));
        Assert.Null(model.ReaderName);
        Assert.False(model.RawData.ContainsKey("readerName"));
        Assert.Null(model.ReportText);
        Assert.False(model.RawData.ContainsKey("reportText"));
        Assert.Null(model.SignedAt);
        Assert.False(model.RawData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
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

            PresignedUrl = null,
            ReaderName = null,
            ReportText = null,
            SignedAt = null,
        };

        Assert.Null(model.PresignedUrl);
        Assert.True(model.RawData.ContainsKey("presignedUrl"));
        Assert.Null(model.ReaderName);
        Assert.True(model.RawData.ContainsKey("readerName"));
        Assert.Null(model.ReportText);
        Assert.True(model.RawData.ContainsKey("reportText"));
        Assert.Null(model.SignedAt);
        Assert.True(model.RawData.ContainsKey("signedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
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

            PresignedUrl = null,
            ReaderName = null,
            ReportText = null,
            SignedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReportRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalReportID = "ext_1234567890abcdef1234567890abcdef",
            StudyID = "stu_1234567890abcdef1234567890abcdef",
            StudyInstanceUid = "1.2.840.113619.2.55.3.604688119.868.1234567890.123",
            PresignedUrl = "https://viewer.avarasoftware.com/study/stu_1234",
            ReaderName = "readerName",
            ReportText = "reportText",
            SignedAt = "signedAt",
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
        };

        ReportRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
