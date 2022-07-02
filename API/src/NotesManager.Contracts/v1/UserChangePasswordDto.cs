namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные для смены пароля пользователя
/// </summary>
public class UserChangePasswordDto
{
    /// <summary>
    /// Текущий пароль пользователя в системе
    /// </summary>
    public string Password { get; init; } = null!;

    /// <summary>
    /// Новый пароль
    /// </summary>
    public string NewPassword { get; init; } = null!;
    
    /// <summary>
    /// Подтверждение нового пароля
    /// </summary>
    public string ConfirmNewPassword { get; init; } = null!;
}