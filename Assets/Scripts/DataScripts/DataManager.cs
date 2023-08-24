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
        var jsonFilepath = Application.persistentDataPath + "/ParticipantData.json";
        if (File.Exists(jsonFilepath))
        {
            _participantData = DataLoader.loadJsonData();
            AllObjectives_ = _participantData.ObjectivesData;
            ParseObjectivesData();
          // Debug.Log(_participantData.ObjectivesData[0].ToString());
          
          InitializeProgressBars();
        }
    }

    private ParticipantData _participantData;
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
        GLOBAL
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
        public List<ObjectiveData> PitchObjectives;
        public List<ObjectiveData> StarsObjectives;
        public List<ObjectiveData> CvObjectives;
        public List<ObjectiveData> LinkedinObjectives;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     // fake data
        //     ObjectiveData data = new ObjectiveData();
        //     data.type = ObjectivesTypes.PITCH;
        //     data.Description = "empty description";
        //     data.isDone = true;
        //     data.Title = "Elevator pitch élaboré";
        //     
        //     ObjectiveData data2 = new ObjectiveData();
        //     data.type = ObjectivesTypes.STARS;
        //     data.Description = "empty description";
        //     data.isDone = false;
        //     data.Title = "1ère star en anglais écrite";
        //
        //     List<ObjectiveData> objectives = new List<ObjectiveData>();
        //     objectives.Add(data);
        //     objectives.Add(data2);
        //
        //     ParticipantData participantData = new ParticipantData();
        //     participantData.ObjectivesData = objectives;
        //     
        //     
        //     DataSaver.SaveDataToJson(participantData);
        //     Debug.Log("Saved data !!");
        //     Debug.Log(Application.persistentDataPath.ToString());
        // }
        //
        //
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     // call to load data from json
        //
        //     ParticipantData participantData;
        //
        //     participantData = DataLoader.loadJsonData();
        //
        //     Debug.Log(participantData.Name);
        //
        //     _participantData = participantData;
        // }
    }

    void ParseObjectivesData()
    {

        foreach (var objectiveData in _participantData.ObjectivesData)
        {
            switch (objectiveData.type)
            {
                case ObjectivesTypes.PITCH:
                {
                    PitchObjectives.Add(objectiveData);
                }
                    break;
                case ObjectivesTypes.STARS:
                {
                    StarsObjectives.Add(objectiveData);
                }
                    break;
                case ObjectivesTypes.CV:
                {
                    CVObjectives.Add(objectiveData);
                }
                    break;
                case ObjectivesTypes.LINKEDIN:
                {
                    LinkedinObjectives.Add(objectiveData);
                }
                    break;
            }
        }
    }

    public  List<ObjectiveData> GetPitchObjectives()
    {
        return PitchObjectives;
    }
    public  List<ObjectiveData> GetStarsObjectives()
    {
        return StarsObjectives;
    }
    public  List<ObjectiveData> GetLinkedinObjectives()
    {
        return LinkedinObjectives;
    }
    public  List<ObjectiveData> GetCVObjectives()
    {
        return CVObjectives;
    }

    public List<ObjectiveData> GetAllObjectives()
    {
        return AllObjectives_;
    }

    public void SetParticipantObjectives(List<ObjectiveData> objectives)
    {
        AllObjectives_ = objectives;
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
    public void InitializeProgressBars()
    {
        ProgressBarScript [] progressBarScripts = FindObjectsOfType<ProgressBarScript>();

        foreach (var progressBar in progressBarScripts)
        {
            progressBar.InitializeProgressBar();
        }
    }
}
