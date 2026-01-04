using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comic.Api.Controllers;

[ApiController]
[Route("me")]
public class MeController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetMe()
    {
        // JWTが検証できていると、User に「ログインした人の情報（Claims）」が入る
        var subject = User.FindFirstValue("sub"); // ユーザーIDっぽいもの
        var email = User.FindFirstValue(ClaimTypes.Email) ?? User.FindFirstValue("email");

        return Ok(new
        {
            sub = subject,
            email,
            claims = User.Claims.Select(c => new { c.Type, c.Value })
        });
    }
}
