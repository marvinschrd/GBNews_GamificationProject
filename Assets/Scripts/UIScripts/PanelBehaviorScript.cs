using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehaviorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        panelInfo_.type = type_;
        panelInfo_.isEnabled = isEnabled_;
        gameObject.SetActive(isEnabled_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private UIManagerScript.PanelsOptions type_;
    [SerializeField] private bool isEnabled_ = false;
    private UIManagerScript.UIPanelInfo panelInfo_;

    public void EnablePanel()
    {
        isEnabled_ = true;
        gameObject.SetActive(true);
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
