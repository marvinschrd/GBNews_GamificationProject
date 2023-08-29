using System;
using System.Collections;
using System.Collections.Generic;
using UIScripts.UITESTS;
using UnityEngine;

public class MainMenuUIScript : MonoBehaviour
{
    [SerializeField] private GameObject PitchProgressBar;
    [SerializeField] private GameObject StarsProgressBar;
    [SerializeField] private GameObject LinkedinProgressBar;
    [SerializeField] private GameObject CVProgressBar;

    [SerializeField] private List<GameObject> progressBars;

    private ProgressBarScript PitchProgressbar;
    private ProgressBarScript StarsProgressbar;
    private ProgressBarScript LinkedinProgressbar;
    private ProgressBarScript CvProgressbar;

    private DataManager dataManager;
    
    // Start is called before the first frame update
    void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
       Debug.Log("main menu enabled !!!!");
       UpdateProgressBars();
    }

    public void UpdateProgressBars()
    {
        foreach (var progressbar in progressBars)
        {
            ProgressBarScript progressBarScript = progressbar.GetComponent<ProgressBarScript>();
            progressBarScript.SelfInitialize();
        }
    }
}
