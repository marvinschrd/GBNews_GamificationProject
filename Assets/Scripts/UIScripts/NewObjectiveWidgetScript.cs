using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectiveWidgetScript : MonoBehaviour
{
    private DataManager.ObjectiveData newObjectiveData = new DataManager.ObjectiveData();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTitleChanged(string title)
    {
        Debug.Log(title);
        newObjectiveData.Title = title;
    }

    public void OnDescriptionChanged(string description)
    {
        newObjectiveData.Description = description;
    }

    public void OnConfirmation()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        List<DataManager.ObjectiveData> currentObjectives = dataManager.GetAllObjectives();
        currentObjectives.Add(newObjectiveData);
        dataManager.SetParticipantObjectives(currentObjectives);
        dataManager.SaveParticipantData();
        GetComponentInParent<PanelBehaviorScript>().DisablePanel();
    }
}
