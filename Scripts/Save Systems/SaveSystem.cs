using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStoryData(StoryController story_controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath/story_data.rpg;

        string path = "C:/Tiedostoja/KiviPaperiGiljotiini/save files/story_data.rpg"; //Debug
        FileStream stream = new FileStream(path, FileMode.Create);

        StoryData data = new StoryData(story_controller);

        formatter.Serialize(stream, data);
        stream.Close();
    } 
    
    public static StoryData LoadStoryData()
    {
        //string path = Application.persistentDataPath/story_data.rpg;

        string path = "C:/Tiedostoja/KiviPaperiGiljotiini/save files/story_data.rpg"; //Debug

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            StoryData data = formatter.Deserialize(stream) as StoryData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("File story_data.rpg not found");
            return null;
        }
    }
}
