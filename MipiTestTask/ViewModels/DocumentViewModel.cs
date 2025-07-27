namespace MipiTestTask.ViewModels;

/// <summary>
/// Вью-модель для вывода апи. В задании это указано, как дто
/// </summary>
public record DocumentViewModel(Guid Id, string Name, UserViewModel User, string Description, string Priority);