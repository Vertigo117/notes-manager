namespace NotesManager.Contracts.v1;

/// <summary>
/// Страница данных
/// </summary>
public class DataPageDto<TDto> where TDto : class
{
    /// <summary>
    /// Общее количество заметок
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Заметки на странице
    /// </summary>
    public List<TDto> Data { get; set; } = new();
}