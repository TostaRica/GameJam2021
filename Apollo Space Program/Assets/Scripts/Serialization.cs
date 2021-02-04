using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Behaviour save and load serialization
public static class Serialization
{
    public static List<GameManager> savedGames = new List<GameManager>();

    public static void Save()
    {
        savedGames.Add(GameManager.currentGame); // Add current game to the list saved games
        BinaryFormatter bf = new BinaryFormatter(); // Serialization work
        FileStream file = File.Create(Application.persistentDataPath + "/savedata.upc"); // Send the current game data and saved the file savegame.gd in unity's path by default -> you can put any extension
        bf.Serialize(file, Serialization.savedGames); // Saved the file in our list of saved games
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame.upc")) // If exist any savedata
        {
            BinaryFormatter bf = new BinaryFormatter(); // Serialization work
            FileStream file = File.Open(Application.persistentDataPath + "/savedata.upc", FileMode.Open); // Open the file savegame.gd in unity's path by default -> you can put any extension
            // 1. Search the file in the path
            // 2. Cast the binary file to our class
            // 3. Put it in our list
            Serialization.savedGames = (List<GameManager>)bf.Deserialize(file);
            file.Close();
        }
    }
    
    public static bool isFileExists()
    {
        return File.Exists(Application.persistentDataPath + "/savegame.upc");
    }
}
