﻿using System.Text;
using UnityEngine;
using BepInEx;

namespace COTL_JSONLoader.Helpers;

internal static class AssetHelpers
{
    private static string Find(string filename) => Directory.GetFiles(Paths.PluginPath, filename, SearchOption.AllDirectories).FirstOrDefault();

    internal static Texture2D Load(string imagePath)
    {
        if (!Path.IsPathRooted(imagePath))
            imagePath = Find(imagePath);

        byte[] arr = File.ReadAllBytes(imagePath);
        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGBA32, false, false);
        tex.LoadImage(arr);
        tex.filterMode = FilterMode.Point;
        return tex;
    }

    internal static Color32 HexToColor(string hex)
    {
        Queue<char> chars = new Queue<char>(hex.Trim());
        if (chars.Count == 0) return default;
        if (chars.Peek() == '#') chars.Dequeue();

        if (chars.Count < 6)
        {
            Plugin.LogError($"Invalid hexcode: {hex}");
            return default;
        }

        // I could have used a List<byte>, but this is a tiny bit faster.
        // (And I know exactly how many items I'll need, anyway.)
        byte[] rgb = new byte[3];

        for (int i = 0; i < 3; i++)
        {
            StringBuilder sb = new();
            sb.Append(chars.Dequeue());
            sb.Append(chars.Dequeue());

            byte x = Convert.ToByte(sb.ToString(), 16);
            rgb[i] = x;
        }

        return new(rgb[0], rgb[1], rgb[2], 255);
    }

    internal static Rect ToRect(string rectString)
    {
        string[] nums = rectString.Split(',').Select(x => x.Trim()).ToArray();

        if (nums.Length < 4)
        {
            Plugin.LogError($"Invalid rect: {rectString}");
            return default;
        }

        int[] rect = nums.Select(x => Convert.ToInt32(x)).ToArray();
        return new(rect[0], rect[1], rect[2], rect[3]);
    }

    public static Vector2 ToVector2(string vectorString)
    {
        string[] nums = vectorString.Split(',').Select(x => x.Trim()).ToArray();

        if (nums.Length < 2)
        {
            Plugin.LogError($"Invalid vector: {vectorString}");
            return default;
        }

        float[] vector = nums.Select(Convert.ToSingle).ToArray();
        return new(vector[0], vector[1]);
    }
}
