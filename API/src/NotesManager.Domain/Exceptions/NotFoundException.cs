namespace NotesManager.Domain.Exceptions;

/// <summary>
/// Представляет ошибку, которая возникает в случае, если сущность не удалось найти
/// </summary>
public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}