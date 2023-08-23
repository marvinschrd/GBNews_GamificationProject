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
    private List<GameObject> ObjectivesWidgets;

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

    // Populate and initialize the objective list from the selected and given objective datas (objective type)
    public void InitializeObjectives()
    {
        // foreach (var objectiveData in objectiveDatas)
        // {
        //     GameObject objectiveWidget = Instantiate(objectiveWidgetPrefab_);
        //     objectiveWidget.transform.SetParent(scrollViewComponent_.transform);
        //     
        //     //Initialize objective Data
        //     objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().InitializeObjective(objectiveData);
        //     
        // }
        
        
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
        
        ObjectiveProgressBar_.GetComponent<ProgressBarScript>().UpdateMaxprogressValueFromValue(nbOfWidget);

        // for (int i = 0; i <= nbOfWidget; ++i)
        // {
        //     // mockup objective data
        //     DataManager.ObjectiveData mockupData = new DataManager.ObjectiveData();
        //     mockupData.isDone = false;
        //     mockupData.Description = "write your star in english hajshdkjahdkjahdkjahskdjh";
        //     
        //     GameObject objectiveWidget = Instantiate(objectiveWidgetPrefab_);
        //     objectiveWidget.transform.SetParent(scrollViewContentComponent_.transform, false);
        //     objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().InitializeObjective(mockupData,ObjectiveProgressBar_);
        // }

        // Instantiate and initialize each objective widget with the data
        foreach (var objectiveData in objectivesDataList_)
        {
            GameObject objectiveWidget = Instantiate(objectiveWidgetPrefab_);
            objectiveWidget.transform.SetParent(scrollViewContentComponent_.transform, false);
            objectiveWidget.GetComponent<ObjectiveCheckBoxScript>().InitializeObjective(objectiveData,ObjectiveProgressBar_);
        }
    }
}
