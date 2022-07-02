namespace NotesManager.Contracts.v1;

/// <summary>
/// Объект для передачи данных заметки
/// </summary>
public class NoteDto
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; init; }
}