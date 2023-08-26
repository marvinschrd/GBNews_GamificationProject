using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectiveDetailPanelScript : MonoBehaviour
{
    private TextMeshProUGUI ObjectiveTitle_;
    private TextMeshProUGUI ObjectiveDescription_;

    [SerializeField] private ObjectiveContainerScript objectiveContainer_;
    
    private DataManager dataManager_;

    private DataManager.ObjectiveData relatedObjective_;
    
    //For debug
    [SerializeField] private TextMeshProUGUI Title_;
    [SerializeField] private TextMeshProUGUI Description_;

    private void Awake()
    {
        ObjectiveTitle_ = GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(textUI => textUI.name == "ObjectiveTitle");
        ObjectiveDescription_ = GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(textUI => textUI.name == "ObjectiveDescription");

        ObjectiveTitle_ = Title_;
        ObjectiveDescription_ = Description_;
        
        if (ObjectiveTitle_ != null)
        {
            Debug.Log("Found title");
        }

        if (ObjectiveDescription_ != null)
        {
            Debug.Log("Found description");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dataManager_ = FindObjectOfType<DataManager>();
        
        // ObjectiveTitle_ = GetComponentsInChildren<TextMeshProUGUI>().ToList()
        //     .Find(textUI => textUI.name == "ObjectiveTitle");
        // ObjectiveDescription_ = GetComponentsInChildren<TextMeshProUGUI>().ToList()
        //     .Find(textUI => textUI.name == "ObjectiveDescription");
        //
        // ObjectiveTitle_ = Title_;
        // ObjectiveDescription_ = Description_;
        //
        // if (ObjectiveTitle_ != null)
        // {
        //     Debug.Log("Found title");
        // }
        //
        // if (ObjectiveDescription_ != null)
        // {
        //     Debug.Log("Found description");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePanel(DataManager.ObjectiveData objectiveData)
    {
        ObjectiveTitle_.text = objectiveData.Title;
        ObjectiveDescription_.text = objectiveData.Description;

        relatedObjective_ = objectiveData;
    }

    public void OnDeleteButtonPressed()
    {
        // Get objectives
        List<DataManager.ObjectiveData> objectiveList = dataManager_.GetAllObjectives();
        int objectiveToRemoveIndex = 0;
        // Find the objective to delete
        for (int i = 0; i < objectiveList.Count; ++i)
        {
            if (objectiveList[i].Title == relatedObjective_.Title)
            {
                objectiveToRemoveIndex = i;
            }
        }
        // Delete the objective from the participant data and save the new data
        objectiveList.RemoveAt(objectiveToRemoveIndex);
        dataManager_.SetParticipantObjectives(objectiveList);
        dataManager_.SaveParticipantData();
        
        //Tell the objective container to delete the objective gameobject
        objectiveContainer_.DeleteObjective(relatedObjective_);
    }
}
