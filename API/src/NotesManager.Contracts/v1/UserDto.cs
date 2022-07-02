namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные пользователя
/// </summary>
public class UserDto
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; init; } = null!;
}