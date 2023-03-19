using housing_back_end.Dtos;
using housing_back_end.Errors;
using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

public class AccountController : BaseController
{
    private readonly IUnitOfWork _uow;
    private readonly IConfiguration _configuration;
    
    public AccountController(IUnitOfWork uow, IConfiguration configuration)
    {
        this._configuration = configuration;
        this._uow = uow;
    }

    // api/account/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginReqDto loginReq)
    {
        var user = await _uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);
        
        if (user == null)
        {
            return Unauthorized();
        }

        var loginRes = new LoginResDto();
        loginRes.UserName = user.Username;
        loginRes.Token = "Token to be generated";
        
        return Ok(loginRes);
    }
    
}