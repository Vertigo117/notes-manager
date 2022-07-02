namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные для аутентификации пользователя
/// </summary>
public class UserLoginDto
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; init; } = null!;
}