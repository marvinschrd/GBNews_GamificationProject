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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeObjective(DataManager.ObjectiveData objectiveData, GameObject relatedProgressBar)
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        _objectiveData = objectiveData;
        ProgressBarRelatedObject_ = relatedProgressBar;
        relatedProgressBar.GetComponent<ProgressBarScript>().UpdateMaxprogressValueFromValue(1);

        ObjectiverDescriptionComponent_.GetComponent<Text>().text = _objectiveData.Title;

        initialIsDoneState = _objectiveData.isDone;
        
        
        ObjectiveCheckBoxComponent_.GetComponent<Toggle>().isOn = initialIsDoneState;
        firstUpdateChecked = true;

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
           }
           
    }
    
}
