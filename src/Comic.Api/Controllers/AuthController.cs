using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Comic.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    // Program.cs と同じキー。将来は設定ファイル/環境変数に逃がす
    private const string DevSigningKey =
        "DEV_ONLY__change_me_to_long_random_string_please_1234567890";

    // 開発専用：トークン発行
    // 本番では削除 or 無効化する想定
    [HttpPost("dev-token")]
    public IActionResult IssueDevToken([FromQuery] string email = "dev@example.com")
    {
        // JWTの中に入れる「属性（claims）」を作る
        var claims = new List<Claim>
        {
            // sub はユーザーID扱い（Cognitoでもsubが基本）
            new(JwtRegisteredClaimNames.Sub, "dev-user-1"),
            // email はログインユーザーの識別用
            new(JwtRegisteredClaimNames.Email, email),
            // 例：権限（将来 admin などにもできる）
            new("role", "user"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DevSigningKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 期限は短めにしておく（開発用なので）
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(
            new
            {
                accessToken = jwt,
                tokenType = "Bearer",
                expiresIn = 8 * 60 * 60,
            }
        );
    }
}
