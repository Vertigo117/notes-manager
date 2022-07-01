using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesManager.Application.Abstractions.Services.Interfaces;
using NotesManager.Contracts.v1;

namespace NotesManager.Controllers.Api.v1;

/// <summary>
/// Контроллер заметок
/// </summary>
[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesService _notesService;

    /// <summary>
    /// Создаёт экзмепляр класса <see cref="NotesController"/> с сервисом заметок
    /// </summary>
    /// <param name="notesService">Сервис заметок</param>
    public NotesController(INotesService notesService)
    {
        _notesService = notesService;
    }

    /// <summary>
    /// Получить постраничный список заметок
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="skip">Сколько пропустить</param>
    /// <param name="take">Сколько вывести</param>
    /// <returns>Постраничный список заметок</returns>
    [HttpGet]
    [ProducesResponseType((typeof(IEnumerable<NoteDto>)), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromQuery] int userId, [FromQuery] int skip, [FromQuery] int take)
    {
        var response = await _notesService.GetPagedNotesByUserIdAsync(userId, skip, take);
        return Ok(response);
    }
}