using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.AutoScribe;

namespace Avara.Tests.Models.AutoScribe;

public class StudyReportMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StudyReportMetadata
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };

        string expectedAge = "38 years";
        string expectedDateOfBirth = "1985-07-20";
        string expectedFacilityName = "City Medical Center";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 165 };
        string expectedMrn = "MRN-2024-001234";
        string expectedPatientName = "Jane Doe";
        string expectedProcedure = "MRI Brain with Contrast";
        string expectedReferringPhysicianName = "Dr. Michael Chen";
        ApiEnum<string, Sex> expectedSex = Sex.Female;
        string expectedStudyDate = "2024-03-15";
        string expectedStudyTime = "14:30";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 62 };

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
        var model = new StudyReportMetadata
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyReportMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StudyReportMetadata
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StudyReportMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAge = "38 years";
        string expectedDateOfBirth = "1985-07-20";
        string expectedFacilityName = "City Medical Center";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 165 };
        string expectedMrn = "MRN-2024-001234";
        string expectedPatientName = "Jane Doe";
        string expectedProcedure = "MRI Brain with Contrast";
        string expectedReferringPhysicianName = "Dr. Michael Chen";
        ApiEnum<string, Sex> expectedSex = Sex.Female;
        string expectedStudyDate = "2024-03-15";
        string expectedStudyTime = "14:30";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 62 };

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
        var model = new StudyReportMetadata
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StudyReportMetadata { };

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
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StudyReportMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StudyReportMetadata
        {
            // Null should be interpreted as omitted for these properties
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
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StudyReportMetadata
        {
            // Null should be interpreted as omitted for these properties
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
        var model = new StudyReportMetadata
        {
            Age = "38 years",
            DateOfBirth = "1985-07-20",
            FacilityName = "City Medical Center",
            Height = new() { Unit = Unit.Cm, Value = 165 },
            Mrn = "MRN-2024-001234",
            PatientName = "Jane Doe",
            Procedure = "MRI Brain with Contrast",
            ReferringPhysicianName = "Dr. Michael Chen",
            Sex = Sex.Female,
            StudyDate = "2024-03-15",
            StudyTime = "14:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 62 },
        };

        StudyReportMetadata copied = new(model);

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
