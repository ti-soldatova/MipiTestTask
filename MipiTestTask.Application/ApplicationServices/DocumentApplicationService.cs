using MipiTestTask.Application.Interfaces;
using MipiTestTask.Application.ViewModels;
using MipiTestTask.Bll.Models;

namespace MipiTestTask.Application.ApplicationServices;

// В целом, в этом сервисе, для данного тестового задания, нет необходимости. Я его создала, потому что это хорошая практика у меня на работе - инкапсулировать бизнес-логику в отдельный сервис. 
// Это удобно, доступно для расширения и не переполняет контроллер.
// В данном случае, здесь всего лишь пробрасывается логика дальше, но решила сделать так, чтобы при необходимости можно было расширить здесь бизнес-функционал, для этого так же нужно будет пробросить сюда логгирование.
public class DocumentApplicationService : IDocumentApplicationService
{
    private readonly IDocumentAdapter _documentAdapter;

    public DocumentApplicationService(IDocumentAdapter documentAdapter)
    {
        _documentAdapter = documentAdapter;
    }

    public DocumentViewModel GetDocumentById(Guid id)
    {
        var document = _documentAdapter.GetDocumentById(id);

        return ToViewModel(document);
    }

    public IEnumerable<DocumentViewModel> GetDocumentsByUser(string userName)
    {
        var documents = _documentAdapter.GetDocumentsByUser(userName);

        return documents.Select(ToViewModel).ToList();
    }

    /// <summary>
    /// Перевод из бизнес-модели во вью-модель
    /// </summary>
    /// <param name="document">Бизнес-модель документа</param>
    /// <returns>Вью-модель документа</returns>
    private DocumentViewModel ToViewModel(Document document)
    {
        UserViewModel userVM = new(document.User.Id, document.User.Name, document.User.Login);

        return new DocumentViewModel(document.Id, document.Name, userVM, document.Description, document.Priority.ToString());
    }
}
