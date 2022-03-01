
using System.Text.Json.Serialization;

public class AppIdentitySettings
{
    public User User { get; set; }
    public PasswordSettings Password { get; set; }
    public LockoutSettings Lockout { get; set; }
}

public class User
{
    public bool RequireUniqueEmail { get; set; }
}
public class PasswordSettings
{
    public int RequiredLength { get; set; }
    public bool RequireLowercase { get; set; }
    public bool RequireUppercase { get; set; }
    public bool RequireDigit { get; set; }
    public bool RequireNonAlphanumeric { get; set; }
}

public class LockoutSettings
{
    public bool AllowedForNewUsers { get; set; }
    public int DefaultLockoutTimeSpanInMins { get; set; }
    public int MaxFailedAccessAttempts { get; set; }
}

public class AppDBSettings
{
    public string Database { get; set; }
    public string Database_Inventories { get; set; }
    public string Database_Customers { get; set; }
    public string Database_HumanResources { get; set; }
    public string Database_Orders { get; set; }
    public string Database_Reports { get; set; }
    public string Database_Staffs { get; set; }
    public string Database_Systems { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class AppDomainSettings
{
    public string domain_images { get; set; }
    public string path_frontend_template { get; set; }
    public string path_settings { get; set; }
    public string domain { get; set; }
    public string document { get; set; }
}

public class AppsAuthenticate
{
    public string Secret { get; set; }
}

public class TokenManagement
{
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("issuer")]
    public string Issuer { get; set; }

    [JsonPropertyName("audience")]
    public string Audience { get; set; }

    [JsonPropertyName("accessExpiration")]
    public int AccessExpiration { get; set; }

    [JsonPropertyName("refreshExpiration")]
    public int RefreshExpiration { get; set; }
}