using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManagerScript : MonoBehaviour
{
    public enum OptionsMenu
    {
        MAINMENU,
        PITCH,
        STARS,
        LINKEDIN
    }
    private OptionsMenu initialMenu = OptionsMenu.MAINMENU;
    
    //CameraPositions
    [SerializeField] private Transform MainMenuPosition;

    [SerializeField] private Transform PitchMenuPosition;

    [SerializeField] private Transform StarsMenuPosition;
    
    
    //Menus reference to all the different canvas
    [SerializeField] private GameObject MainOptionsPanel;
   

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
}
