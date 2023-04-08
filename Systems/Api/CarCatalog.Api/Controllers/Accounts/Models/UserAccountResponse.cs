namespace CarCatalog.API.Controllers.Models;

using AutoMapper;
using CarCatalog.Services.UserAccount;

public class UserAccountResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}

public class UserAccountResponseProfile : Profile
{
    public UserAccountResponseProfile()
    {
        CreateMap<UserAccountModel, UserAccountResponse>();
    }
}
