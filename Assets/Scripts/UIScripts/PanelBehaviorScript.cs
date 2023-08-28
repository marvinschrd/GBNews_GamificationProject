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
        Debug.Log(gameObject.name + "enabled");
        // action when enabled
    }

    public void DisablePanel()
    {
        isEnabled_ = false;
        gameObject.SetActive(false);
        //actions when disabled
    }

    public UIManagerScript.UIPanelInfo GetPanelInfos()
    {
        return panelInfo_;
    }
}
