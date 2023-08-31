using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScroller : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] TextInfo;
    [SerializeField] private float TextScrollingSpeed_ = 0.01f;

    [SerializeField] private TextMeshProUGUI textComponent_;
    private int currentDisplayText = 0;

    private bool currentTextFinishedDisplay = false;

    [SerializeField] private UIManagerScript.OptionsMenu objectiveType_;

    [SerializeField] private TextMeshProUGUI pressSpaceMessageText_;

    public void ActivateText()
    {
        currentTextFinishedDisplay = false;
        StartCoroutine(AnimateText());
    }


    // Coroutine
    IEnumerator AnimateText()
    {
        pressSpaceMessageText_.enabled = false;
        currentTextFinishedDisplay = false;
        for (int i = 0; i < TextInfo[currentDisplayText].Length + 1; ++i)
        {
            textComponent_.text = TextInfo[currentDisplayText].Substring(0, i);

            yield return new WaitForSeconds(TextScrollingSpeed_);
        }

        currentTextFinishedDisplay = true;

        if (currentDisplayText + 1 < TextInfo.Length)
        {
            pressSpaceMessageText_.enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pressSpaceMessageText_.enabled = false;

        var gameDialogues = FindObjectOfType<DataManager>().GetParticipantData().GameDialogues;

        //Extract the correspondig dialogue text
        switch (objectiveType_)
        {
            case UIManagerScript.OptionsMenu.MAINMENU:
            {
                TextInfo = gameDialogues.MainMenuDialogue;
            }
                break;
            case UIManagerScript.OptionsMenu.STARS:
            {
                TextInfo = gameDialogues.StarsMenuDialogue;
            }
                break;
            case UIManagerScript.OptionsMenu.PITCH:
            {
                TextInfo = gameDialogues.PitchMenuDialogue;
            }
                break;
            case UIManagerScript.OptionsMenu.LINKEDIN :
            {
                TextInfo = gameDialogues.LinkedinMenuDialogue;
            }
                break;
            case UIManagerScript.OptionsMenu.CV:
            {
                TextInfo = gameDialogues.CVMenuDialogue;
            }
                break;
        }
        
        
        ActivateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentTextFinishedDisplay && currentDisplayText +1 < TextInfo.Length)
        {
            Debug.Log("pressed space");
            currentDisplayText++;
            StartCoroutine(AnimateText());
        }
    }
}
