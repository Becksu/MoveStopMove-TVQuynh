using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameSave : MonoBehaviour
{
    public string saveName = "saveGame";
    public string directoryName = "Saves";
    public DataGame dataGame;

    public void SaveGame()
    {
        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveStream = File.Create(directoryName + "/" + saveName + ".bin");
        formatter.Serialize(saveStream, dataGame);
        saveStream.Close();

    }
}
