using NotesManager.Contracts.v1;

namespace NotesManager.Application.Abstractions.Services.Interfaces;

/// <summary>
/// Сервис для авторизации и регистрации пользователей
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Асинхронно выполняет аутентификацию пользователя в системе
    /// </summary>
    /// <param name="credentials">Данные пользователя</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task LoginAsync(UserLoginDto credentials);

    /// <summary>
    /// Асинхронно регистрирует пользователя в системе
    /// </summary>
    /// <param name="userInfo">Данные пользователя для регистрации</param>
    /// <returns></returns>
    Task<UserDto> RegisterAsync(UserRegisterDto userInfo);

    /// <summary>
    /// Асинхронно обновляет данные пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task UpdateUserAsync(int id, UserRegisterDto userInfo);

    
    Task DeleteUserAsync(int id);
}