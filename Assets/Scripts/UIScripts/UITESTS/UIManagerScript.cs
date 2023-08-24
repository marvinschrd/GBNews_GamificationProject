using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManagerScript : MonoBehaviour
{
    [System.Serializable]
   public struct UIPanelInfo
    {
        public PanelsOptions type;
        public bool isEnabled;
    }
    
    public enum OptionsMenu
    {
        MAINMENU,
        PITCH,
        STARS,
        LINKEDIN
    }

    [Serializable]
    public enum PanelsOptions
    {
        MAIN_MENU,
        PITCH_UI,
        STARS_UI,
        LINKEDIN_UI,
        CV_UI,
        NEW_OBJECTIVE_PANEL,
    }
    private OptionsMenu initialMenu = OptionsMenu.MAINMENU;
    private PanelsOptions InitialPanel = PanelsOptions.MAIN_MENU;
    
    //CameraPositions
    [SerializeField] private Transform MainMenuPosition;

    [SerializeField] private Transform PitchMenuPosition;

    [SerializeField] private Transform StarsMenuPosition;
    
    
    //Menus reference to all the different canvas
    [SerializeField] private GameObject MainOptionsPanel;
    [SerializeField] private GameObject NewObjectiveEditPanel_;
    
    
    //List of panels by panelsBehaviorScript
    [SerializeField] private List<PanelBehaviorScript> panelsList_;

    private CameraMovement cameramovementScript;

    // cached string
   // private static readonly int IsEnabled = Animator.StringToHash("isEnabled");

    // Start is called before the first frame update
    void Start()
    {
        cameramovementScript = FindObjectOfType<CameraMovement>();
        SelectMenu((int)initialMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerMainOptionPanel(bool enable)
    {
        if (enable)
        {
            MainOptionsPanel.GetComponent<Animator>().SetBool("IsEnabled", true);
        }
        else
        {
            MainOptionsPanel.GetComponent<Animator>().SetBool("IsEnabled", false);
        }
    }
    
    public void SelectMenu(int menuIndex)
    {
        switch ((OptionsMenu)menuIndex)
        {
            case OptionsMenu.PITCH:
            {
                if (PitchMenuPosition != null)
                {
                    Debug.Log("Pitch target");
                    cameramovementScript.moveTo(PitchMenuPosition.position);
                    TriggerMainOptionPanel(false);
                    
                }
            }
                break;
            case OptionsMenu.STARS:
            {
                cameramovementScript.moveTo(StarsMenuPosition.position);
                TriggerMainOptionPanel(false);
            }
                break;
            case OptionsMenu.LINKEDIN:
            {
                //cameramovementScript.moveTo(li.position);
                TriggerMainOptionPanel(false);
            }
                break;
            case OptionsMenu.MAINMENU:
            {
                cameramovementScript.moveTo(MainMenuPosition.position);
                TriggerMainOptionPanel(true);
            }
                break;
            default:
            {
                // nothing
            }
                break;
        }
    }

    public void ToggleUIPanel(int panelTypeIndex)
    {
        foreach (var panel in panelsList_)
        {
           var panelInfo = panel.GetPanelInfos();

           if ((PanelsOptions)panelTypeIndex == panelInfo.type)
           {
               if (panelInfo.isEnabled)
               {
                   panel.DisablePanel();
               }
               else
               {
                   panel.EnablePanel();
               }
           }
        }
    }
}
