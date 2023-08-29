using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehaviorScript : MonoBehaviour
{
    public void Awake()
    {
        panelInfo_.type = type_;
        panelInfo_.isEnabled = isEnabled_;
        gameObject.SetActive(isEnabled_);
    }
    
    [SerializeField] private UIManagerScript.PanelsOptions type_;
    [SerializeField] private bool isEnabled_ = false;
    private UIManagerScript.UIPanelInfo panelInfo_;

    public void EnablePanel()
    {
        isEnabled_ = true;
        gameObject.SetActive(true);
        Debug.Log(gameObject.name + " enabled");
        // action when enabled
    }

    public void DisablePanel()
    {
        isEnabled_ = false;
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().SetTrigger("Disabled");
        }
        else
        {
            gameObject.SetActive(false);
        }
        //actions when disabled
    }

    public UIManagerScript.UIPanelInfo GetPanelInfos()
    {
        panelInfo_.isEnabled = isEnabled_;
        
        return panelInfo_;
    }

    public void RemovePanel()
    {
       Debug.Log("Remove panel");
      // FindObjectOfType<UIManagerScript>().SelectMenu((int)UIManagerScript.PanelsOptions.MAIN_MENU);
       gameObject.SetActive(false);
    }
}
