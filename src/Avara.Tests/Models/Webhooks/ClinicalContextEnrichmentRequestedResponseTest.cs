using System.Collections.Generic;
using System.Text.Json;
using Avara.Core;
using Avara.Models.Webhooks;

namespace Avara.Tests.Models.Webhooks;

public class ClinicalContextEnrichmentRequestedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            ClinicalIndication = "Chest pain, rule out PE",
            Documents =
            [
                new()
                {
                    Content = ["Patient presents with chest pain."],
                    FileName = "order-notes.txt",
                },
            ],
            DocumentUrls =
            [
                new()
                {
                    Url = "https://ehr.example.com/docs/note.pdf",
                    FileName = "clinical-note.pdf",
                },
            ],
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
            TechnologistNotes = ["Patient tolerated contrast well."],
            TechnologistTechnique = "Helical CT with IV contrast",
        };

        string expectedClinicalIndication = "Chest pain, rule out PE";
        List<ClinicalContextEnrichmentDocument> expectedDocuments =
        [
            new() { Content = ["Patient presents with chest pain."], FileName = "order-notes.txt" },
        ];
        List<ClinicalContextEnrichmentDocumentUrl> expectedDocumentUrls =
        [
            new() { Url = "https://ehr.example.com/docs/note.pdf", FileName = "clinical-note.pdf" },
        ];
        List<ClinicalContextEnrichmentPriorReport> expectedPriorReports =
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
        List<string> expectedTechnologistNotes = ["Patient tolerated contrast well."];
        string expectedTechnologistTechnique = "Helical CT with IV contrast";

        Assert.Equal(expectedClinicalIndication, model.ClinicalIndication);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.NotNull(model.DocumentUrls);
        Assert.Equal(expectedDocumentUrls.Count, model.DocumentUrls.Count);
        for (int i = 0; i < expectedDocumentUrls.Count; i++)
        {
            Assert.Equal(expectedDocumentUrls[i], model.DocumentUrls[i]);
        }
        Assert.NotNull(model.PriorReports);
        Assert.Equal(expectedPriorReports.Count, model.PriorReports.Count);
        for (int i = 0; i < expectedPriorReports.Count; i++)
        {
            Assert.Equal(expectedPriorReports[i], model.PriorReports[i]);
        }
        Assert.NotNull(model.TechnologistNotes);
        Assert.Equal(expectedTechnologistNotes.Count, model.TechnologistNotes.Count);
        for (int i = 0; i < expectedTechnologistNotes.Count; i++)
        {
            Assert.Equal(expectedTechnologistNotes[i], model.TechnologistNotes[i]);
        }
        Assert.Equal(expectedTechnologistTechnique, model.TechnologistTechnique);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            ClinicalIndication = "Chest pain, rule out PE",
            Documents =
            [
                new()
                {
                    Content = ["Patient presents with chest pain."],
                    FileName = "order-notes.txt",
                },
            ],
            DocumentUrls =
            [
                new()
                {
                    Url = "https://ehr.example.com/docs/note.pdf",
                    FileName = "clinical-note.pdf",
                },
            ],
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
            TechnologistNotes = ["Patient tolerated contrast well."],
            TechnologistTechnique = "Helical CT with IV contrast",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentRequestedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            ClinicalIndication = "Chest pain, rule out PE",
            Documents =
            [
                new()
                {
                    Content = ["Patient presents with chest pain."],
                    FileName = "order-notes.txt",
                },
            ],
            DocumentUrls =
            [
                new()
                {
                    Url = "https://ehr.example.com/docs/note.pdf",
                    FileName = "clinical-note.pdf",
                },
            ],
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
            TechnologistNotes = ["Patient tolerated contrast well."],
            TechnologistTechnique = "Helical CT with IV contrast",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClinicalContextEnrichmentRequestedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClinicalIndication = "Chest pain, rule out PE";
        List<ClinicalContextEnrichmentDocument> expectedDocuments =
        [
            new() { Content = ["Patient presents with chest pain."], FileName = "order-notes.txt" },
        ];
        List<ClinicalContextEnrichmentDocumentUrl> expectedDocumentUrls =
        [
            new() { Url = "https://ehr.example.com/docs/note.pdf", FileName = "clinical-note.pdf" },
        ];
        List<ClinicalContextEnrichmentPriorReport> expectedPriorReports =
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
        List<string> expectedTechnologistNotes = ["Patient tolerated contrast well."];
        string expectedTechnologistTechnique = "Helical CT with IV contrast";

        Assert.Equal(expectedClinicalIndication, deserialized.ClinicalIndication);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.NotNull(deserialized.DocumentUrls);
        Assert.Equal(expectedDocumentUrls.Count, deserialized.DocumentUrls.Count);
        for (int i = 0; i < expectedDocumentUrls.Count; i++)
        {
            Assert.Equal(expectedDocumentUrls[i], deserialized.DocumentUrls[i]);
        }
        Assert.NotNull(deserialized.PriorReports);
        Assert.Equal(expectedPriorReports.Count, deserialized.PriorReports.Count);
        for (int i = 0; i < expectedPriorReports.Count; i++)
        {
            Assert.Equal(expectedPriorReports[i], deserialized.PriorReports[i]);
        }
        Assert.NotNull(deserialized.TechnologistNotes);
        Assert.Equal(expectedTechnologistNotes.Count, deserialized.TechnologistNotes.Count);
        for (int i = 0; i < expectedTechnologistNotes.Count; i++)
        {
            Assert.Equal(expectedTechnologistNotes[i], deserialized.TechnologistNotes[i]);
        }
        Assert.Equal(expectedTechnologistTechnique, deserialized.TechnologistTechnique);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            ClinicalIndication = "Chest pain, rule out PE",
            Documents =
            [
                new()
                {
                    Content = ["Patient presents with chest pain."],
                    FileName = "order-notes.txt",
                },
            ],
            DocumentUrls =
            [
                new()
                {
                    Url = "https://ehr.example.com/docs/note.pdf",
                    FileName = "clinical-note.pdf",
                },
            ],
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
            TechnologistNotes = ["Patient tolerated contrast well."],
            TechnologistTechnique = "Helical CT with IV contrast",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse { };

        Assert.Null(model.ClinicalIndication);
        Assert.False(model.RawData.ContainsKey("clinicalIndication"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.DocumentUrls);
        Assert.False(model.RawData.ContainsKey("documentUrls"));
        Assert.Null(model.PriorReports);
        Assert.False(model.RawData.ContainsKey("priorReports"));
        Assert.Null(model.TechnologistNotes);
        Assert.False(model.RawData.ContainsKey("technologistNotes"));
        Assert.Null(model.TechnologistTechnique);
        Assert.False(model.RawData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            // Null should be interpreted as omitted for these properties
            ClinicalIndication = null,
            Documents = null,
            DocumentUrls = null,
            PriorReports = null,
            TechnologistNotes = null,
            TechnologistTechnique = null,
        };

        Assert.Null(model.ClinicalIndication);
        Assert.False(model.RawData.ContainsKey("clinicalIndication"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.DocumentUrls);
        Assert.False(model.RawData.ContainsKey("documentUrls"));
        Assert.Null(model.PriorReports);
        Assert.False(model.RawData.ContainsKey("priorReports"));
        Assert.Null(model.TechnologistNotes);
        Assert.False(model.RawData.ContainsKey("technologistNotes"));
        Assert.Null(model.TechnologistTechnique);
        Assert.False(model.RawData.ContainsKey("technologistTechnique"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            // Null should be interpreted as omitted for these properties
            ClinicalIndication = null,
            Documents = null,
            DocumentUrls = null,
            PriorReports = null,
            TechnologistNotes = null,
            TechnologistTechnique = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClinicalContextEnrichmentRequestedResponse
        {
            ClinicalIndication = "Chest pain, rule out PE",
            Documents =
            [
                new()
                {
                    Content = ["Patient presents with chest pain."],
                    FileName = "order-notes.txt",
                },
            ],
            DocumentUrls =
            [
                new()
                {
                    Url = "https://ehr.example.com/docs/note.pdf",
                    FileName = "clinical-note.pdf",
                },
            ],
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
            TechnologistNotes = ["Patient tolerated contrast well."],
            TechnologistTechnique = "Helical CT with IV contrast",
        };

        ClinicalContextEnrichmentRequestedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
