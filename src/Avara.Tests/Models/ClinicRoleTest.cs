using System.Text.Json;
using Avara.Core;
using Avara.Exceptions;
using Avara.Models;

namespace Avara.Tests.Models;

public class ClinicRoleTest : TestBase
{
    [Theory]
    [InlineData(ClinicRole.Doctor)]
    [InlineData(ClinicRole.Physician)]
    [InlineData(ClinicRole.Surgeon)]
    [InlineData(ClinicRole.Radiologist)]
    [InlineData(ClinicRole.Cardiologist)]
    [InlineData(ClinicRole.Neurologist)]
    [InlineData(ClinicRole.Urologist)]
    [InlineData(ClinicRole.Gynecologist)]
    [InlineData(ClinicRole.Endocrinologist)]
    [InlineData(ClinicRole.Oncologist)]
    [InlineData(ClinicRole.RadiationOncologist)]
    [InlineData(ClinicRole.Hematologist)]
    [InlineData(ClinicRole.Gastroenterologist)]
    [InlineData(ClinicRole.Pulmonologist)]
    [InlineData(ClinicRole.Nephrologist)]
    [InlineData(ClinicRole.Rheumatologist)]
    [InlineData(ClinicRole.Dermatologist)]
    [InlineData(ClinicRole.Ophthalmologist)]
    [InlineData(ClinicRole.Otolaryngologist)]
    [InlineData(ClinicRole.Pediatrician)]
    [InlineData(ClinicRole.Obstetrician)]
    [InlineData(ClinicRole.Psychiatrist)]
    [InlineData(ClinicRole.Anesthesiologist)]
    [InlineData(ClinicRole.EmergencyMedicinePhysician)]
    [InlineData(ClinicRole.FamilyMedicinePhysician)]
    [InlineData(ClinicRole.InternalMedicinePhysician)]
    [InlineData(ClinicRole.Pathologist)]
    [InlineData(ClinicRole.NuclearMedicinePhysician)]
    [InlineData(ClinicRole.PainManagementSpecialist)]
    [InlineData(ClinicRole.InfectiousDiseaseSpecialist)]
    [InlineData(ClinicRole.Immunologist)]
    [InlineData(ClinicRole.PhysicianAssistant)]
    [InlineData(ClinicRole.NursePractitioner)]
    [InlineData(ClinicRole.CertifiedRegisteredNurseAnesthetist)]
    [InlineData(ClinicRole.Psychologist)]
    [InlineData(ClinicRole.MedicalAssistant)]
    [InlineData(ClinicRole.Scribe)]
    [InlineData(ClinicRole.RegisteredNurse)]
    [InlineData(ClinicRole.NurseManager)]
    [InlineData(ClinicRole.PatientCareCoordinator)]
    [InlineData(ClinicRole.ImagingTechnologist)]
    [InlineData(ClinicRole.LaboratoryTechnician)]
    [InlineData(ClinicRole.MedicalLaboratoryScientist)]
    [InlineData(ClinicRole.PathologistsAssistant)]
    [InlineData(ClinicRole.Phlebotomist)]
    [InlineData(ClinicRole.Pharmacist)]
    [InlineData(ClinicRole.PharmacyTechnician)]
    [InlineData(ClinicRole.PhysicalTherapist)]
    [InlineData(ClinicRole.OccupationalTherapist)]
    [InlineData(ClinicRole.SpeechLanguagePathologist)]
    [InlineData(ClinicRole.RespiratoryTherapist)]
    [InlineData(ClinicRole.Nutritionist)]
    [InlineData(ClinicRole.FrontDeskOperator)]
    [InlineData(ClinicRole.RevenueCycleManager)]
    [InlineData(ClinicRole.AdministrativeDirector)]
    [InlineData(ClinicRole.AdministrativeAssistant)]
    [InlineData(ClinicRole.LegalAdministrator)]
    [InlineData(ClinicRole.ItAdministrator)]
    [InlineData(ClinicRole.ItSupport)]
    [InlineData(ClinicRole.SoftwareEngineer)]
    [InlineData(ClinicRole.Other)]
    public void Validation_Works(ClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClinicRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AvaraInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClinicRole.Doctor)]
    [InlineData(ClinicRole.Physician)]
    [InlineData(ClinicRole.Surgeon)]
    [InlineData(ClinicRole.Radiologist)]
    [InlineData(ClinicRole.Cardiologist)]
    [InlineData(ClinicRole.Neurologist)]
    [InlineData(ClinicRole.Urologist)]
    [InlineData(ClinicRole.Gynecologist)]
    [InlineData(ClinicRole.Endocrinologist)]
    [InlineData(ClinicRole.Oncologist)]
    [InlineData(ClinicRole.RadiationOncologist)]
    [InlineData(ClinicRole.Hematologist)]
    [InlineData(ClinicRole.Gastroenterologist)]
    [InlineData(ClinicRole.Pulmonologist)]
    [InlineData(ClinicRole.Nephrologist)]
    [InlineData(ClinicRole.Rheumatologist)]
    [InlineData(ClinicRole.Dermatologist)]
    [InlineData(ClinicRole.Ophthalmologist)]
    [InlineData(ClinicRole.Otolaryngologist)]
    [InlineData(ClinicRole.Pediatrician)]
    [InlineData(ClinicRole.Obstetrician)]
    [InlineData(ClinicRole.Psychiatrist)]
    [InlineData(ClinicRole.Anesthesiologist)]
    [InlineData(ClinicRole.EmergencyMedicinePhysician)]
    [InlineData(ClinicRole.FamilyMedicinePhysician)]
    [InlineData(ClinicRole.InternalMedicinePhysician)]
    [InlineData(ClinicRole.Pathologist)]
    [InlineData(ClinicRole.NuclearMedicinePhysician)]
    [InlineData(ClinicRole.PainManagementSpecialist)]
    [InlineData(ClinicRole.InfectiousDiseaseSpecialist)]
    [InlineData(ClinicRole.Immunologist)]
    [InlineData(ClinicRole.PhysicianAssistant)]
    [InlineData(ClinicRole.NursePractitioner)]
    [InlineData(ClinicRole.CertifiedRegisteredNurseAnesthetist)]
    [InlineData(ClinicRole.Psychologist)]
    [InlineData(ClinicRole.MedicalAssistant)]
    [InlineData(ClinicRole.Scribe)]
    [InlineData(ClinicRole.RegisteredNurse)]
    [InlineData(ClinicRole.NurseManager)]
    [InlineData(ClinicRole.PatientCareCoordinator)]
    [InlineData(ClinicRole.ImagingTechnologist)]
    [InlineData(ClinicRole.LaboratoryTechnician)]
    [InlineData(ClinicRole.MedicalLaboratoryScientist)]
    [InlineData(ClinicRole.PathologistsAssistant)]
    [InlineData(ClinicRole.Phlebotomist)]
    [InlineData(ClinicRole.Pharmacist)]
    [InlineData(ClinicRole.PharmacyTechnician)]
    [InlineData(ClinicRole.PhysicalTherapist)]
    [InlineData(ClinicRole.OccupationalTherapist)]
    [InlineData(ClinicRole.SpeechLanguagePathologist)]
    [InlineData(ClinicRole.RespiratoryTherapist)]
    [InlineData(ClinicRole.Nutritionist)]
    [InlineData(ClinicRole.FrontDeskOperator)]
    [InlineData(ClinicRole.RevenueCycleManager)]
    [InlineData(ClinicRole.AdministrativeDirector)]
    [InlineData(ClinicRole.AdministrativeAssistant)]
    [InlineData(ClinicRole.LegalAdministrator)]
    [InlineData(ClinicRole.ItAdministrator)]
    [InlineData(ClinicRole.ItSupport)]
    [InlineData(ClinicRole.SoftwareEngineer)]
    [InlineData(ClinicRole.Other)]
    public void SerializationRoundtrip_Works(ClinicRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClinicRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClinicRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClinicRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClinicRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
