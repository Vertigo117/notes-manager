namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные для регистрации пользователя
/// </summary>
public class UserRegisterDto
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

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; init; } = null!;

    /// <summary>
    /// Подтверждение пароля
    /// </summary>
    public string ConfirmPassword { get; init; } = null!;
}