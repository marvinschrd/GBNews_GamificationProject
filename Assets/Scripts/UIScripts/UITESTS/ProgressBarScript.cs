using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UITESTS
{
    public class ProgressBarScript : MonoBehaviour
    {
        private Slider progressBarSlider;

        [SerializeField] private float maxProgressValue_;

        private float currentProgressValue_;

        private bool progressFull = false;

        [SerializeField] private DataManager.ObjectivesTypes type_;
        private DataManager dataManager;
    
        //Texts
        private string category;
        
        
        // widget components
        [SerializeField] private GameObject CategoryTitleComponent;
        [SerializeField] private GameObject CurrentProgressTextComponent;
        [SerializeField] private GameObject MaxProgressTextComponent;
    
    
        // Start is called before the first frame update

        private void OnEnable()
        {
            progressBarSlider = GetComponentInChildren<Slider>();
            //progressBarSlider.highValue = maxProgressValue_;
        }

        void Start()
        {
            dataManager = FindObjectOfType<DataManager>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

       public void InitializeProgressBar()
        {
            // init references
            dataManager = FindObjectOfType<DataManager>();
            progressBarSlider = GetComponentInChildren<Slider>();
            
            
            float maxProgress = 0;
            float currentProgress = 0;
        
            switch (type_)
            {
                case DataManager.ObjectivesTypes.PITCH:
                {
                    maxProgress = dataManager.GetPitchObjectives().Count;
                    
                    foreach (var objective in dataManager.GetPitchObjectives())
                    {
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.STARS:
                {
                    maxProgress = dataManager.GetPitchObjectives().Count;
                    foreach (var objective in dataManager.GetStarsObjectives())
                    {
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.LINKEDIN:
                {
                    maxProgress = dataManager.GetPitchObjectives().Count;
                    foreach (var objective in dataManager.GetLinkedinObjectives())
                    {
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.CV:
                {
                    maxProgress = dataManager.GetPitchObjectives().Count;
                    foreach (var objective in dataManager.GetCVObjectives())
                    {
                        if (objective.isDone)
                        {
                            currentProgress++;
                        }
                    }
                }
                    break;
            }
            
            // update the slider values
            maxProgressValue_ = maxProgress;
            currentProgressValue_ = currentProgress;
            progressBarSlider.maxValue = maxProgressValue_;
            progressBarSlider.value = currentProgressValue_;

            CurrentProgressTextComponent.GetComponent<TextMeshProUGUI>().text = currentProgressValue_.ToString();
            MaxProgressTextComponent.GetComponent<TextMeshProUGUI>().text = maxProgressValue_.ToString();
            CategoryTitleComponent.GetComponent<TextMeshProUGUI>().text = type_.ToString();
        }

        public void UpdateProgressValue()
        {
            // switch (type_)
            // {
            //     case DataManager.ObjectivesTypes.PITCH:
            //     {
            //         foreach (var objective in dataManager.GetPitchObjectives())
            //         {
            //             if (objective.isDone)
            //             {
            //                 currentProgress++;
            //             }
            //         }
            //     }
            //         break;
            //     case DataManager.ObjectivesTypes.STARS:
            //     {
            //         foreach (var objective in dataManager.GetStarsObjectives())
            //         {
            //             if (objective.isDone)
            //             {
            //                 currentProgress++;
            //             }
            //         }
            //     }
            //         break;
            //     case DataManager.ObjectivesTypes.LINKEDIN:
            //     {
            //         foreach (var objective in dataManager.GetLinkedinObjectives())
            //         {
            //             if (objective.isDone)
            //             {
            //                 currentProgress++;
            //             }
            //         }
            //     }
            //         break;
            //     case DataManager.ObjectivesTypes.CV:
            //     {
            //         foreach (var objective in dataManager.GetCVObjectives())
            //         {
            //             if (objective.isDone)
            //             {
            //                 currentProgress++;
            //             }
            //         }
            //     }
            //         break;
            // }
            //
            //
            // currentProgressValue_ += progressValue;
            // currentProgressValue_ = currentProgressValue_ >= maxProgressValue_ ? maxProgressValue_ : currentProgressValue_;
            // progressBarSlider.value = currentProgressValue_;
        
            // register the value change in data
            //DataSaver.SaveDataToJson();
        }

        public void UpdateMaxProgressValue()
        {
            maxProgressValue_ = 0;
            switch (type_)
            {
                case DataManager.ObjectivesTypes.PITCH:
                {
                    foreach (var objective in dataManager.GetPitchObjectives())
                    {
                        maxProgressValue_++;
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.STARS:
                {
                    foreach (var objective in dataManager.GetStarsObjectives())
                    {
                        maxProgressValue_++;
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.LINKEDIN:
                {
                    foreach (var objective in dataManager.GetLinkedinObjectives())
                    {
                        maxProgressValue_++;
                    }
                }
                    break;
                case DataManager.ObjectivesTypes.CV:
                {
                    foreach (var objective in dataManager.GetCVObjectives())
                    {
                        maxProgressValue_++;
                    }
                }
                    break;
            }
        }
    }
}
