using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PriorityQueue;

public class Config
{
    [JsonPropertyName("priorityUsers")]
    public string[] PriorityUsers { get; set; }
}

public class Data
{
    private static readonly string CONFIG_PATH = Path.Combine(BepInEx.Paths.ConfigPath, MyPluginInfo.PLUGIN_NAME);
    private static readonly string USERS_PATH = Path.Combine(CONFIG_PATH, "priorityusers.json");

    private static Data _instance;
    private Config config;

    public static Data Instance => _instance ??= new Data();

    private Data()
    {
        LoadConfig();
    }

    public void ReloadConfig()
    {
        _instance = null;
        LoadConfig();
    }

    public void LoadConfig()
    {
        Directory.CreateDirectory(CONFIG_PATH);

        if (!File.Exists(USERS_PATH))
        {
            config = new Config
            {
                PriorityUsers = new string[] { "123456789", "987654321" }
            };

            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(USERS_PATH, json);
        }
        else
        {
            string json = File.ReadAllText(USERS_PATH);
            config = JsonSerializer.Deserialize<Config>(json) ?? new Config { PriorityUsers = new string[0] };
        }
    }

    public void AddUser(string userId)
    {
        if (!config.PriorityUsers.Contains(userId))
        {
            var updatedList = config.PriorityUsers.Concat(new string[] { userId }).ToArray();
            config.PriorityUsers = updatedList;
            SaveConfig();
        }
    }
    public void RemoveUser(string userId)
    {
        if (config.PriorityUsers.Contains(userId))
        {
            var updatedList = config.PriorityUsers.Where(user => user != userId).ToArray();
            config.PriorityUsers = updatedList;
            SaveConfig();
        }
    }

    public string[] ListUsers()
    {
        return config.PriorityUsers.Where(user => !string.IsNullOrEmpty(user)).ToArray();
    }

    private void SaveConfig()
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(USERS_PATH, json);
    }

    public Config GetConfig()
    {
        return config;
    }
}
