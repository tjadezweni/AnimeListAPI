using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Security;

public class UserTokens
{
    public string Token { get; set; } = null!;

    public string Username { get; set; } = null!;

    public TimeSpan Validity { get; set; }

    public string RefreshToken { get; set; } = null!;

    public int Id { get; set; }

    public Guid GuidId { get; set; }

    public DateTime ExpiredTime { get; set; }
}
