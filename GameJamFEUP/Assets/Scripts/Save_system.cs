using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save_system : MonoBehaviour
{
    public static string filename = "/save.stc";
    public static void SavePlayer(List<float> score)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + filename;

        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static ScoreData LoadPlayer(List<float> score)
    {
        string path = Application.persistentDataPath + filename;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            if (data == null)
            {
                Debug.LogError("Nothing saved");
                return null;
            }
            return data;
        }
        else
        {
            Debug.LogError("NO SAVE FOUND" + path);
            SavePlayer(score);
            LoadPlayer(score);
            return null;
        }
    }
    
    public static void Destroy_saves()
    {
        File.Delete(Application.persistentDataPath + filename);
    }
}
