using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public  class DataLoader
{
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
    

    // public static List<string[]> loadCSVData(string path)
    // {
    //     
    // }

    public static DataManager.ParticipantData loadJsonData()
    {
        DataManager.ParticipantData data = new DataManager.ParticipantData();
        string folder = "Resources";
       // var jsonFile = Resources.Load<TextAsset>(folder + path);
       
        var jsonFilepath = Application.persistentDataPath + "/ParticipantData.json";
        if (File.Exists(jsonFilepath))
        {
            string fileCOntent = File.ReadAllText(jsonFilepath);
            var ParsedJson = JsonUtility.FromJson<DataManager.ParticipantData>(fileCOntent);
            data = ParsedJson;
        }
       
       return data;
    }

    // public static DataManager.ParticipantData LoadCSVData()
    // {
    //     
    // }
}
