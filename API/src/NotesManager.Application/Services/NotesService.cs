using AutoMapper;
using NotesManager.Application.Abstractions.Services.Interfaces;
using NotesManager.Contracts.v1;
using NotesManager.Domain.Abstractions.Repositories.Interfaces;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Exceptions;

namespace NotesManager.Application.Services;

/// <inheritdoc/>
internal class NotesService : INotesService
{
    private readonly IEntityRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public NotesService(IEntityRepositoryWrapper repository, IMapper mapper)
    {
        _repositoryWrapper = repository;
        _mapper = mapper;
    }

    public NoteDto CreateNote(NoteUpsertDto note)
    {
        var noteEntity = _mapper.Map<NoteEntity>(note);
        _repositoryWrapper.NoteRepository.Create(noteEntity);

        return _mapper.Map<NoteDto>(noteEntity);
    }

    public async Task<NoteDto> GetNoteByIdAsync(int id)
    {
        var noteEntity = await _repositoryWrapper.NoteRepository.GetByIdOrDefaultAsync(id);

        ThrowExceptionIfNoteIsNull(id, noteEntity);

        return _mapper.Map<NoteDto>(noteEntity);
    }

    public async Task<PagedNoteDataDto> GetPagedNotesByUserIdAsync(int userId, int skip, int take)
    {
        var page = await _repositoryWrapper.NoteRepository.GetPagedEntitiesByExpressionAsync(
            entity => entity.UserId == userId, skip, take);

        return _mapper.Map<PagedNoteDataDto>(page);
    }

    public async Task UpdateNoteAsync(int id, NoteUpsertDto note)
    {
        var noteEntity = await _repositoryWrapper.NoteRepository.GetByIdOrDefaultAsync(id);

        ThrowExceptionIfNoteIsNull(id, noteEntity);

        _mapper.Map(note, noteEntity);

        _repositoryWrapper.NoteRepository.Update(noteEntity!);
        await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(int id)
    {
        var noteEntity = await _repositoryWrapper.NoteRepository.GetByIdOrDefaultAsync(id);

        ThrowExceptionIfNoteIsNull(id, noteEntity);

        _repositoryWrapper.NoteRepository.Delete(noteEntity!);
        await _repositoryWrapper.SaveChangesAsync();
    }

    private static void ThrowExceptionIfNoteIsNull(int id, NoteEntity? noteEntity)
    {
        if (noteEntity is null)
        {
            throw new NoteNotFoundException(id);
        }
    }
}