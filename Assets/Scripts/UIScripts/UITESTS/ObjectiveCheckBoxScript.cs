using System.Collections;
using System.Collections.Generic;
using TMPro;
using UIScripts.UITESTS;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCheckBoxScript : MonoBehaviour
{
    private DataManager.ObjectiveData _objectiveData;
    
    //widget components
    [SerializeField] private GameObject ObjectiverDescriptionComponent_;
    [SerializeField] private GameObject ObjectiveCheckBoxComponent_;

    [SerializeField] GameObject ProgressBarRelatedObject_;
    
    //Variable to prevent initial toggle when loading data
    private bool initialIsDoneState = false;
    private bool firstUpdateChecked = false;

    public void InitializeObjective(DataManager.ObjectiveData objectiveData, GameObject relatedProgressBar)
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        _objectiveData = objectiveData;
        ProgressBarRelatedObject_ = relatedProgressBar;
       // relatedProgressBar.GetComponent<ProgressBarScript>().UpdateMaxprogressValueFromValue(1);

        ObjectiverDescriptionComponent_.GetComponent<Text>().text = _objectiveData.Title;

        initialIsDoneState = _objectiveData.isDone;
        
        
        ObjectiveCheckBoxComponent_.GetComponent<Toggle>().isOn = initialIsDoneState;
        firstUpdateChecked = true;

    }

    public DataManager.ObjectiveData GetData()
    {
        return _objectiveData;
    }

    public void ToggleObjectiveDoneState()
    {
               Debug.Log("should update is done");
           if (!firstUpdateChecked)
           {
            ProgressBarRelatedObject_.GetComponent<ProgressBarScript>().UpdateProgressValue(true);
           }
           else
           {
             _objectiveData.isDone = !_objectiveData.isDone;
             ProgressBarRelatedObject_.GetComponent<ProgressBarScript>().UpdateProgressValue(_objectiveData.isDone);
             
             DataManager dataManager = FindObjectOfType<DataManager>();
             // Get the objectives list
             List<DataManager.ObjectiveData> tempList = dataManager.GetAllObjectives();
          
             // find the object to modify in the list
             for (int i = 0; i < tempList.Count; ++i)
             {
                 if (tempList[i].Title == _objectiveData.Title)
                 {
                     tempList.RemoveAt(i);
                     DataManager.ObjectiveData tempData = _objectiveData;
                     tempList.Insert(i, tempData);
                 }
             }
             dataManager.SetParticipantObjectives(tempList);
             dataManager.SaveParticipantData();
           }
    }

    public void OnInfoButtonPressed()
    {
        //Initialize the detail panel according to this objective data
        ObjectiveDetailPanelScript objectiveInfoWidget = FindObjectOfType<ObjectiveDetailPanelScript>(true);
        objectiveInfoWidget.InitializePanel(_objectiveData);
        
        // Tell the UI manager to toggle the detail panel
        UIManagerScript uiManager = FindObjectOfType<UIManagerScript>();
        uiManager.ToggleUIPanel((int)UIManagerScript.PanelsOptions.OBJECTIVE_DETAIL_PANEL);
        
        Debug.Log("info button pressed");
    }
    
}
