using MipiTestTask.Application.ViewModels;

namespace MipiTestTask.Application.Interfaces;

public interface IDocumentApplicationService
{
    public IEnumerable<DocumentViewModel> GetDocumentsByUser(string userName);
    public DocumentViewModel GetDocumentById(Guid id);
}
