using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public  class DataLoader
{
    public static DataManager.ParticipantData loadJsonData()
    {
        DataManager.ParticipantData data = new DataManager.ParticipantData();
      //  string folder = "Resources";
       // var jsonFile = Resources.Load<TextAsset>(folder + path);

       string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
       DesktopPath += "//";
       
        // var jsonFilepath = Application.persistentDataPath + "/ParticipantData.json";
        var jsonFilepath = DesktopPath + "/ParticipantData.json";
       // var jsonFilePath2 = Application.dataPath + "/ParticipantData.json";
        if (File.Exists(jsonFilepath))
        {
            Debug.Log("File exist");
            string fileCOntent = File.ReadAllText(jsonFilepath);
            var ParsedJson = JsonUtility.FromJson<DataManager.ParticipantData>(fileCOntent);
            data = ParsedJson;
        }
        else // create file
        {
            Debug.Log("file does not exist yet");
            File.Create(jsonFilepath);
            //DataManager.ParticipantData newParticipantData = new DataManager.ParticipantData();
            DataSaver.SaveDataToJson(data);
        }
       
       return data;
    }
}
