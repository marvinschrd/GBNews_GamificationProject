using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver
{
    
    public static void SaveDataToJson(DataManager.ParticipantData participantData)
    {
        var jsonFile = JsonUtility.ToJson(participantData, true);
        string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        DesktopPath += "//";
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/ParticipantData.json", jsonFile );
        System.IO.File.WriteAllText(DesktopPath + "/ParticipantData.json", jsonFile);
        Debug.Log("wrtote and saved file");
    }
}
