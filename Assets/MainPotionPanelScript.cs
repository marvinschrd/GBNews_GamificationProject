using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class MainPotionPanelScript : MonoBehaviour
{
  // [Serializable]
    // public enum OptionsMenu
    // {
    //     MAINMENU = 0,
    //     PITCH = 1,
    //     STARS = 2,
    //     LINKEDIN = 3
    // }

   
   // [SerializeField]
   // public OptionsMenu currentOption = OptionsMenu.MAINMENU;

    private UIManagerScript UIManager;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void MoveTo(int index)
    {
        // switch ((OptionsMenu)index)
        // {
        //     case  OptionsMenu.PITCH:
        //     {
        //         UIManager.SelectMenu(UIManagerScript.OptionsMenu.PITCH);
        //     }
        //         break;
        //     case OptionsMenu.STARS:
        //     {
        //         Debug.Log("PITCH SELECTED");
        //         UIManager.SelectMenu(UIManagerScript.OptionsMenu.STARS);
        //     }
        //         break;
        //     case OptionsMenu.LINKEDIN:
        //     {
        //         UIManager.SelectMenu(UIManagerScript.OptionsMenu.LINKEDIN);
        //     }
        //         break;
        //     case OptionsMenu.MAINMENU:
        //     {
        //         UIManager.SelectMenu(UIManagerScript.OptionsMenu.MAINMENU);
        //     }
        //         break;
        //     default:
        //     {
        //         
        //     }
        //         break;
        // }
    }
}
