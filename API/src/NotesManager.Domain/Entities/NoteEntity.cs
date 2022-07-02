namespace NotesManager.Domain.Entities;

/// <summary>
/// Заметка
/// </summary>
public class NoteEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="UserEntity"/>
    /// </summary>
    public UserEntity User { get; set; } = null!;
}