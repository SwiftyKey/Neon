using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Neon.Server;

public class AuthOptions
{
	public const string Issuer = "NeonServer";
	public const string Audience = "NeonClient";
	const string Key = "AxG+X#SsD5&aY)Y";
	public const int Lifetime = 1;
	public static SymmetricSecurityKey GetSymmetricSecurityKey()
	{
		return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
	}
}
