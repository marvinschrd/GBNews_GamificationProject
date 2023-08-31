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
        LINKEDIN,
        CV
    }

    [Serializable]
    public enum PanelsOptions
    {
        MAIN_MENU,
        STARS_UI,
        PITCH_UI,
        LINKEDIN_UI,
        CV_UI,
        OBJECTIVES_MENU,
        NEW_OBJECTIVE_PANEL,
        OBJECTIVE_DETAIL_PANEL,
        
    }
    [SerializeField] OptionsMenu initialMenu = OptionsMenu.MAINMENU;
    private PanelsOptions InitialPanel = PanelsOptions.MAIN_MENU;
    
    //CameraPositions
    [SerializeField] private Transform MainMenuPosition;

    [SerializeField] private Transform PitchMenuPosition;

    [SerializeField] private Transform StarsMenuPosition;
    
    [SerializeField] private Transform LinkedinMenuPosition;

    [Header("Cursor")] [SerializeField] private Texture2D CursorImage_;
    
    
    //Menus reference to all the different canvas
    [SerializeField] private ObjectiveMenuScript ObjectiveMenu;
    
    
    //List of panels by panelsBehaviorScript
    [SerializeField] private List<PanelBehaviorScript> panelsList_;
    private List<PanelBehaviorScript> EnabledPanels_ = new List<PanelBehaviorScript>();

    private CameraMovement cameramovementScript;

    // cached string
   // private static readonly int IsEnabled = Animator.StringToHash("isEnabled");

    // Start is called before the first frame update
    void Start()
    {
        cameramovementScript = FindObjectOfType<CameraMovement>();
        
        Cursor.SetCursor(CursorImage_,Vector2.zero, CursorMode.Auto);
      //  SelectMenu((int)initialMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerMainOptionPanel(bool enable)
    {
        // if (enable)
        // {
        //     MainOptionsPanel.GetComponent<Animator>().SetBool("IsEnabled", true);
        // }
        // else
        // {
        //     MainOptionsPanel.GetComponent<Animator>().SetBool("IsEnabled", false);
        // }
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
                    ObjectiveMenu.UpdateUIContainers(DataManager.ObjectivesTypes.PITCH);
                    cameramovementScript.moveTo(PitchMenuPosition.position);
                    ToggleUIPanel((int)PanelsOptions.STARS_UI);
                    
                    ToggleUIPanel(0);
                    
                }
            }
                break;
            case OptionsMenu.STARS:
            {
                Debug.Log("Stars target");
                ObjectiveMenu.UpdateUIContainers(DataManager.ObjectivesTypes.STARS);
                cameramovementScript.moveTo(StarsMenuPosition.position);
                ToggleUIPanel((int)PanelsOptions.STARS_UI);
                
                ToggleUIPanel(0);
            }
                break;
            case OptionsMenu.LINKEDIN:
            {
                Debug.Log("Linkedin target");
                ObjectiveMenu.UpdateUIContainers(DataManager.ObjectivesTypes.LINKEDIN);
                cameramovementScript.moveTo(LinkedinMenuPosition.position);
                ToggleUIPanel((int)PanelsOptions.STARS_UI);
                ToggleUIPanel(0);
            }
                break;
            case OptionsMenu.MAINMENU:
            {
                cameramovementScript.moveTo(MainMenuPosition.position);
                DisablePanels();
                ToggleUIPanel(0);
            }
                break;
            default:
            {
                // nothing
            }
                break;
        }
    }

    void DisablePanels()
    {
        foreach (var panel in EnabledPanels_)
        {
            panel.DisablePanel();
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

                   if (EnabledPanels_.Contains(panel))
                   {
                       EnabledPanels_.Remove(panel);
                   }
                   panel.DisablePanel();
               }
               else
               {
                   EnabledPanels_.Add(panel);
                   panel.EnablePanel();
               }
           }
        }
    }
}
