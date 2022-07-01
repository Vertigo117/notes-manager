namespace NotesManager.Domain.Exceptions;

public class NoteNotFoundException : NotFoundException
{
    public NoteNotFoundException(int id) : base($"Note with the identifier {id} was not found")
    {
    }
}