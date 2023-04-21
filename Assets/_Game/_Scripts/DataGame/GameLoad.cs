using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameLoad : MonoBehaviour
{
    public GameSave gameSave;
    public string saveName = "saveGame";
    public string directoryName = "Saves";

    public void LoadGame()
    {
        if (!Directory.Exists(directoryName)) return;
        //Directory.Delete(directoryName);
        //Debug.Log("hihi");
        //Debug.Log(Directory.Exists(directoryName));
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream loadStream = File.Open(directoryName + "/" + saveName + ".bin", FileMode.Open);
        gameSave.dataGame = (DataGame)formatter.Deserialize(loadStream);
        loadStream.Close();
    }
}
