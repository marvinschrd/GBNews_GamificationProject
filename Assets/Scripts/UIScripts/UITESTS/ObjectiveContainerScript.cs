using System.Collections;
using System.Collections.Generic;
using UIScripts.UITESTS;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ObjectiveContainerScript : MonoBehaviour
{
    private List<ObjectiveCheckBoxScript> objectivesWidgetScripts;

    [SerializeField] private GameObject objectiveWidgetPrefab_;
    private List<GameObject> ObjectivesWidgets = new List<GameObject>();

   [SerializeField] private DataManager.ObjectivesTypes type_ = DataManager.ObjectivesTypes.PITCH;

   private List<DataManager.ObjectiveData> objectivesDataList_;
    // Widget Components
    [FormerlySerializedAs("scrollViewComponent_")] [SerializeField] private GameObject scrollViewContentComponent_;

    [SerializeField] private GameObject ObjectiveProgressBar_;
    
    //
    private DataManager dataManagerRef_;
    
    // Start is called before the first frame update
    void Start()
    {
        dataManagerRef_ = FindObjectOfType<DataManager>();
        InitializeObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeContainer(DataManager.ObjectivesTypes type)
    {
        type_ = type;
    }

    // Populate and initialize the objective list from the selected and given objective datas (objective type)
    public void InitializeObjectives()
    {
        ObjectiveProgressBar_.GetComponent<ProgressBarScript>().InitializeProgressBar();
        // Get correct objectives from the loaded data
        switch (type_)
        {
            case DataManager.ObjectivesTypes.PITCH:
            {
                objectivesDataList_ = dataManagerRef_.GetPitchObjectives();
            }
                break;
            case DataManager.ObjectivesTypes.STARS:
            {
                objectivesDataList_ = dataManagerRef_.GetStarsObjectives();
            }
                break;
            case DataManager.ObjectivesTypes.LINKEDIN:
            {
                objectivesDataList_ = dataManagerRef_.GetLinkedinObjectives();
            }
                break;
            case DataManager.ObjectivesTypes.CV:
            {
                objectivesDataList_ = dataManagerRef_.GetCVObjectives();
            }
                break;
        }

        Debug.Log("instatiate widget");
        int nbOfWidget = objectivesDataList_.Count;
        
        //ObjectiveProgressBar_.GetComponent<ProgressBarScript>().UpdateMaxprogressValueFromValue(nbOfWidget);
        
        // Instantiate and initialize each objective widget with the data
        foreach (var objectiveData in objectivesDataList_)
        {
            GameObject objectiveWidget = Instantiate(objectiveWidgetPrefab_);
            ObjectivesWidgets.Add(objectiveWidget);
            objectiveWidget.transform.SetParent(scrollViewContentComponent_.transform, false);
            objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().InitializeObjective(objectiveData,ObjectiveProgressBar_);
        }
    }

    public void RegisterNewObjective(DataManager.ObjectiveData objective)
    {
        objectivesDataList_.Add(objective);
        
        //add into the scrollview
        GameObject objectiveWidget = Instantiate(objectiveWidgetPrefab_);
        ObjectivesWidgets.Add(objectiveWidget);
        objectiveWidget.transform.SetParent(scrollViewContentComponent_.transform, false);
        objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().InitializeObjective(objective,ObjectiveProgressBar_);
    }

    public void DeleteObjective(DataManager.ObjectiveData objectiveData)
    {
        GameObject objectiveToDelete = new GameObject();
        //Remove from scrollview
        foreach (GameObject objectiveWidget in ObjectivesWidgets)
        {
            if (objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().GetData().Title == objectiveData.Title)
            {
                //Destroy the gameobject
                objectiveToDelete = objectiveWidget;
                Destroy(objectiveWidget);
            }
        }

        if (objectiveToDelete != null)
        {
            ObjectivesWidgets.Remove(objectiveToDelete);
        }
        objectivesDataList_.Remove(objectiveData);
        
        //TODO do something to tell the progressbar to update its objective/maxobjective state

        ProgressBarScript progressBar = ObjectiveProgressBar_.GetComponent<ProgressBarScript>();
        progressBar.UpdateProgressValue(false);
        progressBar.UpdateMaxprogressValueFromValue(-1);

    }
}
