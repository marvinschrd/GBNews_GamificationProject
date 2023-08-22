using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument uiMainMenu;

    public VisualTreeAsset CategoryProgressTemplate;

    private void OnEnable()
    {
        uiMainMenu = GetComponent<UIDocument>();

        TemplateContainer categoryProgress = CategoryProgressTemplate.Instantiate();

        uiMainMenu.rootVisualElement.Q("ProgressScrollView").Add(categoryProgress);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
