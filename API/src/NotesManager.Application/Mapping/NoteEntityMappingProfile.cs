using AutoMapper;
using NotesManager.Contracts.v1;
using NotesManager.Domain.Entities;

namespace NotesManager.Application.Mapping;

public class NoteEntityMappingProfile : Profile
{
    public NoteEntityMappingProfile()
    {
        CreateMap<NoteEntity, NoteDto>().ReverseMap();
        CreateMap<NoteUpsertDto, NoteEntity>();
    }
}