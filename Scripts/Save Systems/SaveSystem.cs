using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string story_data = "story_data";
    public static string bark_data = "bark_data";

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
        if (File.Exists(path)) File.Delete(path);
        else Debug.Log(file + " not found");
    }

    public static void DeathDeletion()
    {
        DeleteFile(bark_data);
    } 

    //Specific functions

    //Story Data
    public static void SaveStoryData(StoryController story_controller, bool dead)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_data, FileMode.Create);

        if(dead)
        {
            story_controller.storyIndex = -1;
        }

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

    //Barks

    public static void SaveBarks(Bark[] barks)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(bark_data, FileMode.Create);

        BarkData[] data = new BarkData[10];

        for (int i = 0; i < 10; i++)
        {
            if(barks[i] != null)
            {
                data[i] = new BarkData(barks[i]);
            }
        }

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static BarkData[] LoadBarks()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(bark_data, FileMode.Open);

        BarkData[] data = new BarkData[10];

        if (stream != null)
        {
            data = formatter.Deserialize(stream) as BarkData[];
            stream.Close();
            return data;
        }
        return null;
    }

}
