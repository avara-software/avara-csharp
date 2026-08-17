using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class PatientStudyEnrichmentRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            DateOfBirth = "1985-01-01",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "EHR-999",
            FacilityName = "South Tampa Imaging",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "MRN-12345",
            PatientName = "John Doe",
            Procedure = "CT Chest with contrast",
            ReferringPhysicianName = "Dr. Smith",
            Severity = Severity.Normal,
            Sex = Sex.Male,
            StudyDate = "2026-08-13",
            StudyDescription = "CT Chest with contrast",
            StudyTime = "09:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string expectedDateOfBirth = "1985-01-01";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalPatientID = "EHR-999";
        string expectedFacilityName = "South Tampa Imaging";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 170 };
        string expectedMrn = "MRN-12345";
        string expectedPatientName = "John Doe";
        string expectedProcedure = "CT Chest with contrast";
        string expectedReferringPhysicianName = "Dr. Smith";
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        ApiEnum<string, Sex> expectedSex = Sex.Male;
        string expectedStudyDate = "2026-08-13";
        string expectedStudyDescription = "CT Chest with contrast";
        string expectedStudyTime = "09:30";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 68 };

        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedExpressCustomerID, model.ExpressCustomerID);
        Assert.Equal(expectedExternalPatientID, model.ExternalPatientID);
        Assert.Equal(expectedFacilityName, model.FacilityName);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedMrn, model.Mrn);
        Assert.Equal(expectedPatientName, model.PatientName);
        Assert.Equal(expectedProcedure, model.Procedure);
        Assert.Equal(expectedReferringPhysicianName, model.ReferringPhysicianName);
        Assert.Equal(expectedSeverity, model.Severity);
        Assert.Equal(expectedSex, model.Sex);
        Assert.Equal(expectedStudyDate, model.StudyDate);
        Assert.Equal(expectedStudyDescription, model.StudyDescription);
        Assert.Equal(expectedStudyTime, model.StudyTime);
        Assert.Equal(expectedWeight, model.Weight);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            DateOfBirth = "1985-01-01",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "EHR-999",
            FacilityName = "South Tampa Imaging",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "MRN-12345",
            PatientName = "John Doe",
            Procedure = "CT Chest with contrast",
            ReferringPhysicianName = "Dr. Smith",
            Severity = Severity.Normal,
            Sex = Sex.Male,
            StudyDate = "2026-08-13",
            StudyDescription = "CT Chest with contrast",
            StudyTime = "09:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            DateOfBirth = "1985-01-01",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "EHR-999",
            FacilityName = "South Tampa Imaging",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "MRN-12345",
            PatientName = "John Doe",
            Procedure = "CT Chest with contrast",
            ReferringPhysicianName = "Dr. Smith",
            Severity = Severity.Normal,
            Sex = Sex.Male,
            StudyDate = "2026-08-13",
            StudyDescription = "CT Chest with contrast",
            StudyTime = "09:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatientStudyEnrichmentRequestedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDateOfBirth = "1985-01-01";
        string expectedExpressCustomerID = "cus_1234567890abcdef1234567890abcdef";
        string expectedExternalPatientID = "EHR-999";
        string expectedFacilityName = "South Tampa Imaging";
        Height expectedHeight = new() { Unit = Unit.Cm, Value = 170 };
        string expectedMrn = "MRN-12345";
        string expectedPatientName = "John Doe";
        string expectedProcedure = "CT Chest with contrast";
        string expectedReferringPhysicianName = "Dr. Smith";
        ApiEnum<string, Severity> expectedSeverity = Severity.Normal;
        ApiEnum<string, Sex> expectedSex = Sex.Male;
        string expectedStudyDate = "2026-08-13";
        string expectedStudyDescription = "CT Chest with contrast";
        string expectedStudyTime = "09:30";
        Weight expectedWeight = new() { Unit = WeightUnit.Kg, Value = 68 };

        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedExpressCustomerID, deserialized.ExpressCustomerID);
        Assert.Equal(expectedExternalPatientID, deserialized.ExternalPatientID);
        Assert.Equal(expectedFacilityName, deserialized.FacilityName);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedMrn, deserialized.Mrn);
        Assert.Equal(expectedPatientName, deserialized.PatientName);
        Assert.Equal(expectedProcedure, deserialized.Procedure);
        Assert.Equal(expectedReferringPhysicianName, deserialized.ReferringPhysicianName);
        Assert.Equal(expectedSeverity, deserialized.Severity);
        Assert.Equal(expectedSex, deserialized.Sex);
        Assert.Equal(expectedStudyDate, deserialized.StudyDate);
        Assert.Equal(expectedStudyDescription, deserialized.StudyDescription);
        Assert.Equal(expectedStudyTime, deserialized.StudyTime);
        Assert.Equal(expectedWeight, deserialized.Weight);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            DateOfBirth = "1985-01-01",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "EHR-999",
            FacilityName = "South Tampa Imaging",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "MRN-12345",
            PatientName = "John Doe",
            Procedure = "CT Chest with contrast",
            ReferringPhysicianName = "Dr. Smith",
            Severity = Severity.Normal,
            Sex = Sex.Male,
            StudyDate = "2026-08-13",
            StudyDescription = "CT Chest with contrast",
            StudyTime = "09:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse { };

        Assert.Null(model.DateOfBirth);
        Assert.False(model.RawData.ContainsKey("dateOfBirth"));
        Assert.Null(model.ExpressCustomerID);
        Assert.False(model.RawData.ContainsKey("expressCustomerId"));
        Assert.Null(model.ExternalPatientID);
        Assert.False(model.RawData.ContainsKey("externalPatientId"));
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
        Assert.Null(model.Severity);
        Assert.False(model.RawData.ContainsKey("severity"));
        Assert.Null(model.Sex);
        Assert.False(model.RawData.ContainsKey("sex"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
        Assert.Null(model.StudyTime);
        Assert.False(model.RawData.ContainsKey("studyTime"));
        Assert.Null(model.Weight);
        Assert.False(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            // Null should be interpreted as omitted for these properties
            DateOfBirth = null,
            ExpressCustomerID = null,
            ExternalPatientID = null,
            FacilityName = null,
            Height = null,
            Mrn = null,
            PatientName = null,
            Procedure = null,
            ReferringPhysicianName = null,
            Severity = null,
            Sex = null,
            StudyDate = null,
            StudyDescription = null,
            StudyTime = null,
            Weight = null,
        };

        Assert.Null(model.DateOfBirth);
        Assert.False(model.RawData.ContainsKey("dateOfBirth"));
        Assert.Null(model.ExpressCustomerID);
        Assert.False(model.RawData.ContainsKey("expressCustomerId"));
        Assert.Null(model.ExternalPatientID);
        Assert.False(model.RawData.ContainsKey("externalPatientId"));
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
        Assert.Null(model.Severity);
        Assert.False(model.RawData.ContainsKey("severity"));
        Assert.Null(model.Sex);
        Assert.False(model.RawData.ContainsKey("sex"));
        Assert.Null(model.StudyDate);
        Assert.False(model.RawData.ContainsKey("studyDate"));
        Assert.Null(model.StudyDescription);
        Assert.False(model.RawData.ContainsKey("studyDescription"));
        Assert.Null(model.StudyTime);
        Assert.False(model.RawData.ContainsKey("studyTime"));
        Assert.Null(model.Weight);
        Assert.False(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            // Null should be interpreted as omitted for these properties
            DateOfBirth = null,
            ExpressCustomerID = null,
            ExternalPatientID = null,
            FacilityName = null,
            Height = null,
            Mrn = null,
            PatientName = null,
            Procedure = null,
            ReferringPhysicianName = null,
            Severity = null,
            Sex = null,
            StudyDate = null,
            StudyDescription = null,
            StudyTime = null,
            Weight = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PatientStudyEnrichmentRequestedResponse
        {
            DateOfBirth = "1985-01-01",
            ExpressCustomerID = "cus_1234567890abcdef1234567890abcdef",
            ExternalPatientID = "EHR-999",
            FacilityName = "South Tampa Imaging",
            Height = new() { Unit = Unit.Cm, Value = 170 },
            Mrn = "MRN-12345",
            PatientName = "John Doe",
            Procedure = "CT Chest with contrast",
            ReferringPhysicianName = "Dr. Smith",
            Severity = Severity.Normal,
            Sex = Sex.Male,
            StudyDate = "2026-08-13",
            StudyDescription = "CT Chest with contrast",
            StudyTime = "09:30",
            Weight = new() { Unit = WeightUnit.Kg, Value = 68 },
        };

        PatientStudyEnrichmentRequestedResponse copied = new(model);

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
