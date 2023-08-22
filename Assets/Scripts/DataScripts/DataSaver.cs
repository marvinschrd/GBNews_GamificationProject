using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver
{
    
    public static void SaveDataToJson(DataManager.ParticipantData participantData)
    {
        var jsonFile = JsonUtility.ToJson(participantData, true);
        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/ParticipantData.json", jsonFile );
    }
}
