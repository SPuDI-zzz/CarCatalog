namespace CarCatalog.Services.UserAccount;

public interface IUserAccountService
{
    /// <summary>
    /// Create user account
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<UserAccountModel> Create (RegisterUserAccountModel model);



    // TODO : Также здесь можно разместить методы для изменения данных учетной записи,
    // восстановления и смены пароля, подтверждения электронной почты, установки телефона
    // и его подтверждения и т.д.
}
