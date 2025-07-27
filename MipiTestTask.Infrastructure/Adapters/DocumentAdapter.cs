using Microsoft.Extensions.Logging;
using MipiTestTask.Application.Interfaces;
using MipiTestTask.Bll.Models;
using MipiTestTask.Infrastructure.Exceptions;
using SDK.Interfaces;
using SdkDocument = SDK.Models.Document;

namespace MipiTestTask.Infrastructure.Adapters;

public class DocumentAdapter : IDocumentAdapter
{
    private readonly IDocumentService _documentService;
    private readonly ILogger<DocumentAdapter> _logger;

    public DocumentAdapter(IDocumentService documentService, ILogger<DocumentAdapter> logger)
    {
        _documentService = documentService;
        _logger = logger;
    }

    public Document GetDocumentById(Guid id)
    {
        SdkDocument sdkDocument;

        try
        {
            sdkDocument = _documentService.GetDocumentById(id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при выполнении метода Sdk: {ex.Message}");
            throw new SdkException(ex);
        }

        if (sdkDocument is null)
        {
            _logger.LogError($"Документ с идентификатором {id} не был найден в Sdk");
            throw new NotFoundException();
        }

        Document document = FromSdkDocument(sdkDocument);

        return document;
    }

    public IEnumerable<Document> GetDocumentsByUser(string userName)
    {
        IEnumerable<SdkDocument> sdkDocuments;

        try
        {
            sdkDocuments = _documentService.GetDocumentsByUser(userName);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при выполнении метода Sdk: {ex.Message}");
            throw new SdkException(ex);
        }

        return sdkDocuments is null ? [] : sdkDocuments.Select(FromSdkDocument).ToList();
    }

    /// <summary>
    /// Перевод из модели Sdk в нашу бизнесовую
    /// </summary>
    /// <param name="document">Sdk документ</param>
    /// <returns></returns>
    private Document FromSdkDocument(SdkDocument document)
    {
        User user = new(document.User.Id, document.User.Name, document.User.Login);
        Priority priority = document.IsHighPriority ? Priority.High : Priority.Normal;

        return new(document.Id, document.Title, user, document.Description, priority);
    }
}
