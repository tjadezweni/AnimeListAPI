using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Security;

public class JwtSettings
{
    public bool ValidateIssuerSigningKey { get; set; }

    public string IssuerSigningKey { get; set; } = null!;

    public bool ValidateIssuer { get; set; } = true;

    public string ValidIssuer { get; set; } = null!;

    public bool ValidateAudience { get; set; } = true;

    public string ValidAudience { get; set; } = null!;

    public bool RequiredExpirationTime { get; set; }

    public bool ValidateLifetime { get; set; } = true;
}
