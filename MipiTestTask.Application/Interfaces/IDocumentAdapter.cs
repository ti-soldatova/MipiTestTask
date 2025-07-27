using MipiTestTask.Bll.Models;

namespace MipiTestTask.Application.Interfaces;

public interface IDocumentAdapter
{
    public IEnumerable<Document> GetDocumentsByUser(string userName);
    public Document GetDocumentById(Guid id);
}
