namespace CarCatalog.Services.UserAccount;

using AutoMapper;
using CarCatalog.Context.Entities;

public class UserAccountModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}

public class UserAccountModelProfile : Profile
{
    public UserAccountModelProfile()
    {
        CreateMap<User, UserAccountModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
            ;
    }
}
