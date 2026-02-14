namespace SSM.Host.Common
{
    public static class EnvironmentExtensions
    {
        public static void SetIfNotExists(this WebApplicationBuilder builder, string key, string value)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key)))
            {
                Environment.SetEnvironmentVariable(key, value, EnvironmentVariableTarget.Process);
            }
        }
    }
}
