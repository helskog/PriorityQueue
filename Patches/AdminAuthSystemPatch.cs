using HarmonyLib;
using ProjectM;

namespace PriorityQueue.patches;

[HarmonyPatch(typeof(AdminAuthSystem), nameof(AdminAuthSystem.IsAdmin))]
public static class IsAdmin_Patch
{
    public static void Postfix(ulong platformId, ref bool __result)
    {
        // List of priority users from config
        var priorityUsers = Data.Instance.GetConfig().PriorityUsers;

        foreach (string user in priorityUsers)
        {
            if (platformId.ToString() == user)
            {
                __result = true;
            }
        }
    }
}