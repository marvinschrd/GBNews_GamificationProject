using System;
using System.Collections;
using System.Collections.Generic;
using UIScripts.UITESTS;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveMenuScript : MonoBehaviour
{
    [SerializeField] private ObjectiveContainerScript objectiveContainer_;

    [SerializeField] private ProgressBarScript objectiveProgressBar_;

    [SerializeField] private NewObjectiveWidgetScript newObjectiveWidgetScript_;

    public void UpdateUIContainers(DataManager.ObjectivesTypes selectedType)
    {
        objectiveContainer_.InitializeContainer(selectedType);
        newObjectiveWidgetScript_.SetDefaultType(selectedType);
        objectiveProgressBar_.SetProgressType(selectedType);
        objectiveProgressBar_.SelfInitialize();
    }

    private void OnEnable()
    {
        Debug.Log("enabled");
        GetComponent<Animator>().SetTrigger("Enabled");
    }

    private void OnDisable()
    {
        Debug.Log("disabled");
      //  GetComponent<Animator>().SetTrigger("Disabled");
    }
}
