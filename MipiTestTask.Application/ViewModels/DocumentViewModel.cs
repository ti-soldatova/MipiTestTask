namespace MipiTestTask.Application.ViewModels;

public record DocumentViewModel(Guid Id, string Name, UserViewModel User, string Description, string Priority);