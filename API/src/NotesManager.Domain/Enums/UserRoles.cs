using System.ComponentModel;

namespace NotesManager.Domain.Enums;

/// <summary>
/// Роли пользователя в системе
/// </summary>
public enum UserRoles
{
    /// <summary>
    /// Администратор
    /// </summary>
    [Description("Имеет расширенные права в рамках системы")]
    Admin = 1,
    
    /// <summary>
    /// Обычный пользователь
    /// </summary>
    [Description("Имеет ограниченный набор прав в рамках системы")]
    User = 2
}