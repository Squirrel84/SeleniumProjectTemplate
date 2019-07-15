using Microsoft.Extensions.Configuration;
using System;

namespace SeleniumProjectTemplate.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static TimeSpan GetImplicitWait(this IConfiguration configuration)
        {
            return TimeSpan.FromSeconds(int.Parse(configuration["implicitWait"]));
        }

        public static int GetNoTimesAttemptToSignIn(this IConfiguration configuration)
        {
            return int.Parse(configuration["attemptSigninCount"]);
        }

        public static string GetUsername(this IConfiguration configuration)
        {
            return configuration["ad_username"];
        }

        public static string GetPassword(this IConfiguration configuration)
        {
            return configuration["ad_password"];
        }
    }
}
