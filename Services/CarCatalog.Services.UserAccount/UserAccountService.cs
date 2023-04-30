namespace CarCatalog.Services.UserAccount;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context.Entities;
using CarCatalog.Services.Actions;
using CarCatalog.Services.EmailSender;
using Microsoft.AspNetCore.Identity;

public class UserAccountService : IUserAccountService
{
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    // TODO : add action to send message on email
    private readonly IAction action;
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;

    public UserAccountService(
        IMapper mapper,
        UserManager<User> userManager,
        IAction action,
        IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator
        )
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.action = action;
        this.registerUserAccountModelValidator = registerUserAccountModelValidator;
    }

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        registerUserAccountModelValidator.Check(model);

        // Find user by email
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new ProcessException($"User account with email {model.Email} already exist.");

        // Create user account
        user = new User()
        {
            UserName = model.UserName,
            Birthday = DateTime.UtcNow,
            Email = model.Email,
            EmailConfirmed = true, // TODO : Сделать подтверждение почты по ссылке в письме
            PhoneNumber = null,
            PhoneNumberConfirmed = false
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");

        await action.SendEmail(new EmailModel
        {
            Email = model.Email,
            Subject = "CarCatalog notification",
            Message = "You are registered"
        });

        return mapper.Map<UserAccountModel>(user);
    }
}
