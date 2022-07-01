namespace NotesManager.Contracts.v1;

/// <summary>
/// Объект для передачи данных заметки
/// </summary>
public class NoteDto
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; set; }

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
}