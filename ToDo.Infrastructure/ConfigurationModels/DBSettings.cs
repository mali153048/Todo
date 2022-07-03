
namespace ToDo.Infrastructure.ConfigurationModels
{
    public class DBSettings
    {
        public int DapperTimeout { get; set; }
        public string ConnectionString { get; set; } = string.Empty;

    }
}
