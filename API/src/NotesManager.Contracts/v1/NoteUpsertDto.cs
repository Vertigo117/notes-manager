namespace NotesManager.Contracts.v1;

/// <summary>
/// Данные для создания и обновления заметки
/// </summary>
public class NoteUpsertDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; init; } = null!;

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int UserId { get; init; }
}