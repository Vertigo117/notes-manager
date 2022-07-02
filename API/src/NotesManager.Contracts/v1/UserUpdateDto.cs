namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные для обновления информации о пользователе
/// </summary>
public class UserUpdateDto
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; init; } = null!;
}