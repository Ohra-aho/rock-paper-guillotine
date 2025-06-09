using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string story_data = "story_data";

    //Utilities
    private static string MainPath(string file)
    {
        //return Application.persistentDataPath+file+".rpg";
        return "C:/Tiedostoja/KiviPaperiGiljotiini/save files/" + file + ".rpg"; //Debug
    }
    public static FileStream OpenFileStream(string file, FileMode mode)
    {
        string path = MainPath(file);
        if(File.Exists(path) || mode == FileMode.Create)
        {
            FileStream stream = new FileStream(path, mode);
            return stream;
        }
        return null;
    }
    public static void DeleteFile(string file)
    {
        string path = MainPath(file);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log(file + " not found");
        }
    }


    //Specific functions



    //Story Data
    public static void SaveStoryData(StoryController story_controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_data, FileMode.Create);

        StoryData data = new StoryData(story_controller);

        formatter.Serialize(stream, data);
        stream.Close();
    } 
    

    public static StoryData LoadStoryData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_data, FileMode.Open);

        if(stream != null)
        {
            StoryData data = formatter.Deserialize(stream) as StoryData;
            stream.Close();
            return data;
        }
        return null;
    }

    

    
}
