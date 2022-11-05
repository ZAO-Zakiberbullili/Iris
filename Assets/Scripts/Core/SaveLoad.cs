using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad 
{
    public static List<Game> saves = new List<Game>();

    public static void Save() 
    {
        saves.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saves.gd");
        bf.Serialize(file, SaveLoad.saves);
        file.Close();
    }

    public static void Load() 
    {
        if(File.Exists(Application.persistentDataPath + "/saves.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/saves.gd", FileMode.Open);
			SaveLoad.saves = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
    }   
}
