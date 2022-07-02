using NotesManager.Contracts.v1;

namespace NotesManager.Application.Abstractions.Services.Interfaces;

/// <summary>
/// Сервис управления заметками
/// </summary>
public interface INotesService
{
    /// <summary>
    /// Создаёт заметку
    /// </summary>
    /// <param name="note">Данные для создания заметки</param>
    /// <returns>Данные созданной заметки</returns>
    NoteDto CreateNote(NoteUpsertDto note);

    /// <summary>
    /// Асинхронно получает заметку с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Задача, которая содержит заметку</returns>
    Task<NoteDto> GetNoteByIdAsync(int id);

    /// <summary>
    /// Асинхронно осуществляет постраничный вывод заметок с указанным уникальным идентификатором пользователя
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="skip">Количество заметок, которые необходимо пропустить</param>
    /// <param name="take">Количество заметок, которые необходимо отобразить на странице</param>
    /// <returns></returns>
    Task<DataPageDto<NoteDto>> GetPagedNotesByUserIdAsync(int userId, int skip, int take);

    /// <summary>
    /// Асинхронно обновляет заметку с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор заметки</param>
    /// <param name="note">Данные для обновления заметки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task UpdateNoteAsync(int id, NoteUpsertDto note);

    /// <summary>
    /// Асинхронно удаляет заметку с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор заметки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task DeleteNoteAsync(int id);
}