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
