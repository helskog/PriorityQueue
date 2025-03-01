using System;

using VampireCommandFramework;

namespace PriorityQueue;

internal static class Commands
{
    [Command("priority add", adminOnly: true, description: "Allow user to connect when the server is full.")]
    public static void AddPriorityUser(ChatCommandContext ctx, ulong steam64)
    {
        if (steam64.ToString().Length != 17)
        {
            ctx.Reply("Invalid Steam64 ID.");
            return;
        }

        Data.Instance.AddUser(steam64.ToString());
        Data.Instance.ReloadConfig();
        ctx.Reply($"Added Steam64: {steam64} to priority list.");
    }

    [Command("priority remove", adminOnly: true, description: "Disallow user to connect when the server is full.")]
    public static void RemovePriorityUser(ChatCommandContext ctx, ulong steam64)
    {
        if (steam64.ToString().Length != 17)
        {
            ctx.Reply("Invalid Steam64 ID.");
            return;
        }

        Data.Instance.RemoveUser(steam64.ToString());
        Data.Instance.ReloadConfig();
        ctx.Reply($"Removed Steam64: {steam64} from priority list.");
    }

    [Command("priority list", adminOnly: true, description: "List all priority users.")]
    public static void ListPriorityUser(ChatCommandContext ctx)
    {
        String[] allUsers = Data.Instance.ListUsers();

        if (allUsers.Length == 0) {
            ctx.Reply("No users added to priority list.");
        }
        else
        {
            string usersList = string.Join(Environment.NewLine, allUsers);
            ctx.Reply($"Priority Users:\n{usersList}");
        }
    }
}
