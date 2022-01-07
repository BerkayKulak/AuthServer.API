using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Core.Dtos;
using SharedLibrary.Dtos;

namespace AuthServer.Core.Services
{
    // biz bunu AuthService.API projesinde controller içinde DI olarak geçeceğimiz için Responselar ile dönüyoruz.
    public interface IUserService
    {
        // veritabanında oluşan kullanıcıyı dönücem. ID dahil olmak üzere
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);

    }
}
