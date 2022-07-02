using AutoMapper;
using NotesManager.Contracts.v1;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Models;

namespace NotesManager.Application.Mapping;

public class DataPageMappingProfile : Profile
{
    public DataPageMappingProfile()
    {
        CreateMap<DataPage<NoteEntity>, DataPageDto<NoteEntity>>();
    }
}