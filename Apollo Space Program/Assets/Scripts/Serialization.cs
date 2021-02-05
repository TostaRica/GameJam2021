using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Behaviour save and load serialization
public static class Serialization
{
    public static List<DataGame> savedGames = new List<DataGame>();

    public static void Save(DataGame dataGame)
    {
        savedGames.Add(dataGame); // Add current game to the list saved games
        BinaryFormatter bf = new BinaryFormatter(); // Serialization work
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.upc"); // Send the current game data and saved the file savegame.gd in unity's path by default -> you can put any extension
        bf.Serialize(file, Serialization.savedGames); // Saved the file in our list of saved games
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.upc")) // If exist any savedata
        {
            BinaryFormatter bf = new BinaryFormatter(); // Serialization work
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.upc", FileMode.Open); // Open the file savegame.gd in unity's path by default -> you can put any extension
            // 1. Search the file in the path
            // 2. Cast the binary file to our class
            // 3. Put it in our list
            Serialization.savedGames = (List<DataGame>)bf.Deserialize(file);
            file.Close();

            // Set the last saved datagame
            GameManager.SetDataGame(savedGames[savedGames.Count - 1]);
            Sc_Global.SetDataGame(savedGames[savedGames.Count - 1]);
        }
    }
    
    public static bool isFileExists()
    {
        return File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedata.upc");
    }
}
