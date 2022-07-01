namespace NotesManager.Contracts.v1;

/// <summary>
/// Объект для постраничной передачи данных о заметках
/// </summary>
public class PagedNoteDataDto
{
    /// <summary>
    /// Общее количество заметок
    /// </summary>
    public int TotalCount { get; init; }

    /// <summary>
    /// Заметки на странице
    /// </summary>
    public List<NoteDto> Data { get; init; } = new();
}