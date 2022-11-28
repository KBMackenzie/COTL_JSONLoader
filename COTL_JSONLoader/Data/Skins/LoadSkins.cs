using COTL_API.CustomSkins;
using Newtonsoft.Json;

namespace COTL_JSONLoader.Data.Skins;

internal static class LoadSkins
{
    internal static void LoadPlayerSkins(string[] files)
    {
        foreach (string file in files)
        {
            try
            {
                PlayerSkinData? skin = JsonConvert.DeserializeObject<PlayerSkinData>(File.ReadAllText(file));

                if (skin != null)
                {
                    CustomSkinManager.AddPlayerSkin(skin.CreateSkin());
                    Plugin.Log($"Loaded player skin from file {Path.GetFileName(file)}!");
                }
            }
            catch (System.Exception)
            {
                Plugin.LogError($"Error loading player skin from file {Path.GetFileName(file)}!");
                throw; // TODO: Remove later;
                // continue;
            }
        }
    }

    internal static void LoadFollowerSkins(string[] files)
    {
        foreach (string file in files)
        {
            try
            {
                FollowerSkinData? skin = JsonConvert.DeserializeObject<FollowerSkinData>(File.ReadAllText(file));
                if (skin != null)
                {
                    CustomSkinManager.AddFollowerSkin(skin.CreateSkin());
                    Plugin.Log($"Loaded follower skin from file {Path.GetFileName(file)}!");
                }
            }
            catch (System.Exception)
            {
                Plugin.LogError($"Error loading follower skin from file {Path.GetFileName(file)}!");
                throw; // TODO: Remove later
                // continue;
            }
        }
    }
}
