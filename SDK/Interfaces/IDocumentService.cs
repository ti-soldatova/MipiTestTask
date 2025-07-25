using SDK.Models;

namespace SDK.Interfaces;

public interface IDocumentService
{
    public IEnumerable<Document> GetDocumentsByUser(string userName);
    public Document GetDocumentById(Guid id);
}
