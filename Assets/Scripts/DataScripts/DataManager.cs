using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UIScripts.UITESTS;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
       ReloadData();
       //LoadFirstData();
    }

    private ParticipantData _participantData = new ParticipantData();
    private List<ObjectiveData> AllObjectives_ = new List<ObjectiveData>();
    List<ObjectiveData> PitchObjectives = new List<ObjectiveData>();
    List<ObjectiveData> StarsObjectives= new List<ObjectiveData>();
    List<ObjectiveData> CVObjectives= new List<ObjectiveData>();
    List<ObjectiveData> LinkedinObjectives= new List<ObjectiveData>();
    
    public enum ObjectivesTypes
    {
        PITCH,
        STARS,
        CV,
        LINKEDIN,
        GLOBAL,
        PERSONNAL
    }

    private bool DataLoaded = false;

    public bool GetDataLoaded()
    {
        return DataLoaded;
        
    }

    [System.Serializable] 
    public struct ObjectiveData
    {
        public ObjectivesTypes type;
        public string Title;
        public bool isDone;
        public string Description;
        public int Weight;

    }

    public struct ParticipantData
    {
        public string Name;
        public List<ObjectiveData> ObjectivesData; // all the combined objectives
        // public List<ObjectiveData> PitchObjectives;
        // public List<ObjectiveData> StarsObjectives;
        // public List<ObjectiveData> CvObjectives;
        // public List<ObjectiveData> LinkedinObjectives;
        public TextInfos GameDialogues;
    }
    
    [System.Serializable]
    public struct TextInfos
    {
        public string[] MainMenuDialogue;
        public string[] StarsMenuDialogue;
        public string[] PitchMenuDialogue;
        public string[] LinkedinMenuDialogue;
        public string[] CVMenuDialogue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstData()
    {
        string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        DesktopPath += "//";
        
        var jsonFilepath = DesktopPath + "/ParticipantData.json";
       
        if (File.Exists(jsonFilepath))
        {
             _participantData = DataLoader.loadJsonData();
        }
        else // create file
        {
            Debug.Log("file does not exist yet");
            File.Create(jsonFilepath);
            //DataManager.ParticipantData newParticipantData = new DataManager.ParticipantData();
            DataSaver.SaveDataToJson(_participantData);
            _participantData = DataLoader.loadJsonData();
        }

        DataLoaded = true;
    }

    public void ReloadData()
    {
        // var jsonFilepath = Application.persistentDataPath + "/ParticipantData.json";
        // var jsonFilePath2 = Application.dataPath + "/ParticipantData.json";
       // Debug.Log(jsonFilepath);

        _participantData = DataLoader.loadJsonData();
        AllObjectives_ = _participantData.ObjectivesData;
        ParseObjectivesData();
        // if (File.Exists(jsonFilepath))
        // {
        //     _participantData = DataLoader.loadJsonData();
        //     AllObjectives_ = _participantData.ObjectivesData;
        //     ParseObjectivesData();
        // }
        // else
        // {
        //     Debug.Log("create file");
        //     File.Create(jsonFilepath);
        //     _participantData = new ParticipantData();
        //     DataSaver.SaveDataToJson(_participantData);
        //     
        //     ReloadData();
        // }
    }

    void ParseObjectivesData()
    {
        //Clear before parsing to prevent duplicates when reloading data
        PitchObjectives.Clear();
        StarsObjectives.Clear();
        LinkedinObjectives.Clear();
        CVObjectives.Clear();
        
        
        foreach (var objectiveData in _participantData.ObjectivesData)
        {
            switch (objectiveData.type)
            {
                case ObjectivesTypes.PITCH:
                {
                    PitchObjectives.Add(objectiveData);
                    //Debug.Log("Pitch objectives nb = " + PitchObjectives.Count);
                }
                    break;
                case ObjectivesTypes.STARS:
                {
                    StarsObjectives.Add(objectiveData);
                   // Debug.Log("stars objectives nb = " + PitchObjectives.Count);
                }
                    break;
                case ObjectivesTypes.CV:
                {
                    CVObjectives.Add(objectiveData);
                    //Debug.Log("cv objectives nb = " + PitchObjectives.Count);
                }
                    break;
                case ObjectivesTypes.LINKEDIN:
                {
                    LinkedinObjectives.Add(objectiveData);
                   // Debug.Log("Linkedin objectives nb = " + PitchObjectives.Count);
                }
                    break;
            }
        }
    }

    public  List<ObjectiveData> GetPitchObjectives()
    {
        ReloadData();
        return PitchObjectives;
    }
    public  List<ObjectiveData> GetStarsObjectives()
    {
        ReloadData();
        return StarsObjectives;
    }
    public  List<ObjectiveData> GetLinkedinObjectives()
    {
        ReloadData();
        return LinkedinObjectives;
    }
    public  List<ObjectiveData> GetCVObjectives()
    {
        ReloadData();
        return CVObjectives;
    }

    public List<ObjectiveData> GetAllObjectives()
    {
        ReloadData();
        return AllObjectives_;
    }

    public void SetParticipantObjectives(List<ObjectiveData> objectives)
    {
        AllObjectives_ = objectives;
    }

    public ParticipantData GetParticipantData()
    {
        return _participantData;
    }

    public void SaveParticipantData()
    {
        _participantData.ObjectivesData = AllObjectives_;
        DataSaver.SaveDataToJson(_participantData);
    }


    // update and save a change on a specific objective
    public void UpdateObjectiveState(ObjectiveData newData)
    {
        // Find the objective to update by title
        var objectiveToUpdate =_participantData.ObjectivesData.Find((objectiveData) => objectiveData.Title == newData.Title);
        objectiveToUpdate = newData;
        DataSaver.SaveDataToJson(_participantData); // only update and save the objectives stored inside the "objectivesData" list and not the separate  ones
    }

    // Initialize the main menu progressbars
    // public void InitializeProgressBars()
    // {
    //     ProgressBarScript [] progressBarScripts = FindObjectsOfType<ProgressBarScript>();
    //
    //     foreach (var progressBar in progressBarScripts)
    //     {
    //         progressBar.InitializeProgressBar();
    //     }
    // }
}
