using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string story_data = "story_data";
    public static string bark_data = "bark_data";
    public static string player_weapon_data = "player_weapon_data";
    public static string player_data = "player_data";
    public static string achievement_data = "achievement_data";
    public static string story_checklist_data = "story_checklist_data";
    public static string sound_setting_data = "sound_settings_data";

    //Utilities
    private static string MainPath(string file)
    {
        return Application.persistentDataPath+file+".rpg";
        //return "C:/Tiedostoja/KiviPaperiGiljotiini/save files/" + file + ".rpg"; //Debug
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
    public static void SaveStoryData(StoryController story_controller, RLController rl_controller, bool dead)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_data, FileMode.Create);
        if(dead)
        {
            story_controller.storyIndex = -1;
        }

        StoryData data = new StoryData(story_controller, rl_controller);

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

    //Story checklist
    public static void SaveStoryChecklist(StoryCheckList.CheckList check_list)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_checklist_data, FileMode.Create);

        formatter.Serialize(stream, check_list);
        stream.Close();
    }

    public static StoryCheckList.CheckList LoadStoryChecklist()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(story_checklist_data, FileMode.Open);

        if (stream != null)
        {
            StoryCheckList.CheckList data = formatter.Deserialize(stream) as StoryCheckList.CheckList;
            stream.Close();
            return data;
        }
        return null;
    }


    //Player weapons
    /*public static void SavePlayerWeapons(WeaponData[] weapons, bool dead)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(player_weapon_data, FileMode.Create);

        formatter.Serialize(stream, weapons);
        stream.Close();
    }

    public static WeaponData[] LoadPlayerWeapons()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(player_weapon_data, FileMode.Open);

        if(stream != null)
        {
            WeaponData[] data = formatter.Deserialize(stream) as WeaponData[];
            stream.Close();
            return data;
        }
        return null;
    }*/

    //Player data
    /*public static void SavePlayerData(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(player_data, FileMode.Create);

        formatter.Serialize(stream, player);
        stream.Close();
    } 
    
    public static PlayerData LoadPlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(player_data, FileMode.Open);

        if(stream != null)
        {
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        return null;
    }*/

    //Sound settings
    public static void SaveSoundSettings(SoundData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(sound_setting_data, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SoundData LoadSoundSettings()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = OpenFileStream(sound_setting_data, FileMode.Open);

        if (stream != null)
        {
            SoundData data = formatter.Deserialize(stream) as SoundData;
            stream.Close();
            return data;
        }
        return null;
    }
}
