using BepInEx;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace COTL_JSONLoader.Helpers;

internal static class AssetHelpers
{
    private static string Find(string filename) => Directory.GetFiles(Paths.PluginPath, filename, SearchOption.AllDirectories).FirstOrDefault();

    public static Texture2D Load(string imagePath)
    {
        if (!Path.IsPathRooted(imagePath))
        {
            imagePath = Find(imagePath);
        }

        byte[] arr = File.ReadAllBytes(imagePath);
        Texture2D tex = new Texture2D(1, 1);
        tex.filterMode = FilterMode.Point;
        ImageConversion.LoadImage(tex, arr);
        return tex;
    }

    public static Color32 HexToColor(string hex)
    {
        Queue<char> chars = new Queue<char>(hex.Trim());
        if (chars.Count == 0) return default;
        if (chars.Peek() == '#') chars.Dequeue();

        if(chars.Count < 6)
        {
            Plugin.LogError($"Invalid hexcode: {hex}");
            return default;
        }

        // I could have used a List<byte>, but this is a tiny bit faster.
        // (And I know exactly how many items I'll need, anyway.)
        byte[] rgb = new byte[3];

        for(int i = 0; i < 3; i++)
        {
            StringBuilder sb = new();
            sb.Append(chars.Dequeue());
            sb.Append(chars.Dequeue());

            byte x = Convert.ToByte(sb.ToString(), 16);
            rgb[i] = x;
        }

        return new Color32(rgb[0], rgb[1], rgb[2], 255);
    }

    public static Rect ToRect(string rectString)
    {
        string[] nums = rectString.Split(',').Select(x => x.Trim()).ToArray();
        if (nums.Length < 4)
        {
            Plugin.LogError($"Invalid rect: {rectString}");
            return default;
        }
        int[] rect = nums.Select(x => Convert.ToInt32(x)).ToArray();
        return new Rect(rect[0], rect[1], rect[2], rect[3]);
    }
}
