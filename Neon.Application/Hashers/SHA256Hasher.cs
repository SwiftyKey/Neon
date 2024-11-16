using Neon.Application.Base;
using System.Security.Cryptography;
using System.Text;

namespace Neon.Application.Hashers;

public class SHA256Hasher : IHasher
{
	public string Hash(string input)
	{
		return Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(input)));
	}
}
