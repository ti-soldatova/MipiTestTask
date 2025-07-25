using SDK.Interfaces;
using SDK.Models;
using System.Text.Json;

namespace SDK;

public class DocumentService : IDocumentService
{
    private const string FileName = "Documents.json";

    public IEnumerable<Document> GetDocumentsByUser(string userName)
    {
        if (userName == "Ошибка")
            throw new ApplicationException("Sdk выбросил рандомную ошибку. Сделано для проверки!");

        var allDocuments = ReadJson();
        return allDocuments.Where(d => d.User.Name == userName).ToList();
    }

    public Document GetDocumentById(Guid id)
    {
        var allDocuments = ReadJson();
        return allDocuments.Find(d => d.Id == id);
    }

    private List<Document> ReadJson()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

        using FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
        
        List<Document> result = JsonSerializer.Deserialize<List<Document>>(fs);

        return result;
    }
}
