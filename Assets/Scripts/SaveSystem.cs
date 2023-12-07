using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(List<Category> categories)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/character.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(categories);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.LogError("Saved Game!");

    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/character.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            Debug.LogError("Loaded Game!");
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
