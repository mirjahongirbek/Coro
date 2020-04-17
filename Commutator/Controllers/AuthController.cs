using System;
using System.Threading.Tasks;
using AuthModel.Interfaces;
using AuthModel.ModelView;
using AuthService.Controller;
using CoreResults;
using Entity.Users;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AuthController : AuthController<User, UserRole, string>
    {
        ITelegramUserService _tuser;
        public AuthController(IAuthRepository<User, UserRole, string> auth,
            ITelegramUserService tuser
            ) : base(auth)
        {
            _tuser = tuser;
        }

        public override async Task<NetResult<RegisterResult>> Register([FromBody] RegisterUser model)
        {
            var result=await base.Register(model);
            _tuser.AddNewUser(result.Result.Id, result.Result.UserName);
            return result;
        }

        protected override void SendSms(string userName, string otp)
        {
            throw new NotImplementedException();
        }

        protected override void SenNotify(User phoneNumber, string otpCode)
        {
            Console.WriteLine(otpCode);
        }
    }

}
