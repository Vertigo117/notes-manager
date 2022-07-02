using NotesManager.Domain.Enums;

namespace NotesManager.Domain.Entities;

/// <summary>
/// Роль пользователя в системе
/// </summary>
public class RoleEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public UserRoles Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="UserEntity"/>
    /// </summary>
    public List<UserEntity> Users { get; set; } = new();
}