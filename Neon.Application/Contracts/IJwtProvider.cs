using Neon.Domain.Entities;

namespace Neon.Application.Contracts;

public interface IJwtProvider
{
	string GenerateToken(User user);
}
