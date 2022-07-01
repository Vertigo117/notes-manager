namespace NotesManager.Contracts.v1;

/// <summary>
/// Объект для передачи данных, необходимых для создания и обновления заметки
/// </summary>
public class NoteUpsertDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; } = null!;

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }
}