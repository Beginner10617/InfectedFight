using UnityEngine;
using System.IO;
public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/savefile.json";

    public static void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static GameData LoadGame()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            //(path);
            return data;
        }
        else
        {
            //Warning("Save file not found in " + path);
            return null;
        }
    }
}
