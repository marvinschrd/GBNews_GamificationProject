using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UITESTS
{
    public class ProgressBarScript : MonoBehaviour
    {
        [SerializeField]private Slider progressBarSlider;

        [SerializeField] private float maxProgressValue_;

        private float currentProgressValue_;
        private float lastProgressValue_ = 0.0f;

        //private bool progressFull = false;

        [SerializeField] private DataManager.ObjectivesTypes type_;
        private DataManager dataManager;
    
        //Texts
        private string category;

        [SerializeField] private bool InitializeSelf = false;
        
        
        // widget components
        [SerializeField] private GameObject CategoryTitleComponent;
        [SerializeField] private GameObject CurrentProgressTextComponent;
        [SerializeField] private GameObject MaxProgressTextComponent;


        private float TargetProgress = 0.0f;
        [SerializeField] private float fillSpeed_ = 0.5f;
        
        // Start is called before the first frame update

        private void OnEnable()
        {
        }

        private void Awake()
        {
            //progressBarSlider = GetComponentInChildren<Slider>();
        }

        void Start()
        {
            dataManager = FindObjectOfType<DataManager>();
            if (InitializeSelf)
            {
                SelfInitialize();
            }
        }

        private void Update()
        {
                progressBarSlider.value = Mathf.Lerp(progressBarSlider.value, TargetProgress, Time.deltaTime * fillSpeed_);
            // if (progressBarSlider.value < TargetProgress)
            // {
            //    // progressBarSlider.value += fillSpeed_ * Time.deltaTime;
            // }
            // else if (progressBarSlider.value > TargetProgress)
            // {
            //     progressBarSlider.value -= fillSpeed_ * Time.deltaTime;
            // }
        }

        public void SetProgressType (DataManager.ObjectivesTypes type)
        {
            type_ = type;
        }
        public DataManager.ObjectivesTypes GetProgressType()
        {
            return type_;
        }

        public void SelfInitialize()
        {
            dataManager = FindObjectOfType<DataManager>();
            progressBarSlider = GetComponentInChildren<Slider>();
            
            float currentProgress = 0;
            float maxProgress = 0;
            switch (type_)
            {
                case DataManager.ObjectivesTypes.PITCH:
                {
                    foreach (var objective in dataManager.GetPitchObjectives())
                    {
                        maxProgress++;
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.STARS:
                {
                    foreach (var objective in dataManager.GetStarsObjectives())
                    {
                        maxProgress++;
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.LINKEDIN:
                {
                    foreach (var objective in dataManager.GetLinkedinObjectives())
                    {
                        maxProgress++;
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.CV:
                {
                    foreach (var objective in dataManager.GetCVObjectives())
                    {
                        maxProgress++;
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.GLOBAL:
                {
                    foreach (var objective in dataManager.GetAllObjectives())
                    {
                        maxProgress++;
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
            }

            
            currentProgressValue_ = currentProgress;
            maxProgressValue_ = maxProgress;
            TargetProgress = currentProgressValue_;
            
            progressBarSlider.maxValue = maxProgressValue_;
            progressBarSlider.value = currentProgressValue_;

            CurrentProgressTextComponent.GetComponent<TextMeshProUGUI>().text = currentProgressValue_.ToString();
            MaxProgressTextComponent.GetComponent<TextMeshProUGUI>().text = maxProgressValue_.ToString();
            CategoryTitleComponent.GetComponent<TextMeshProUGUI>().text = type_.ToString();

            lastProgressValue_ = currentProgressValue_;
        }

       public void InitializeProgressBar()
        {
            // init references
            dataManager = FindObjectOfType<DataManager>();
            progressBarSlider = GetComponentInChildren<Slider>();
            
            
            //float maxProgress = 0;
            float currentProgress = 0;
            
            currentProgressValue_ = currentProgress;
            progressBarSlider.maxValue = maxProgressValue_;
            progressBarSlider.value = currentProgressValue_;

            CurrentProgressTextComponent.GetComponent<TextMeshProUGUI>().text = currentProgressValue_.ToString();
            MaxProgressTextComponent.GetComponent<TextMeshProUGUI>().text = maxProgressValue_.ToString();
            CategoryTitleComponent.GetComponent<TextMeshProUGUI>().text = type_.ToString();
        }

        public void UpdateProgressValue(bool addProgress)
        {
            // currentProgressValue_ += addProgress ? 1 : -1;

            if (addProgress)
            {
                IncrementProgress(1);
            }
            else
            {
                IncrementProgress(-1);
            }
           
            
            CurrentProgressTextComponent.GetComponent<TextMeshProUGUI>().text = currentProgressValue_.ToString();
            //progressBarSlider.value = currentProgressValue_;
        }

        public void UpdateMaxProgressValueFromData()
        {
        }

       public void UpdateMaxprogressValueFromValue(float value)
        {
            maxProgressValue_ += value;
            MaxProgressTextComponent.GetComponent<TextMeshProUGUI>().text = maxProgressValue_.ToString();
            progressBarSlider.maxValue = maxProgressValue_;
        }
        public void IncrementProgress(float newProgress)
        {
            // TargetProgress = currentProgressValue_ + addedProgress;
            // Debug.Log("target progress = " + TargetProgress);
            // lastProgressValue_ = TargetProgress;
            Debug.Log(newProgress);
            TargetProgress = currentProgressValue_ + newProgress;
            currentProgressValue_ = TargetProgress;

        }
    }
    
}
