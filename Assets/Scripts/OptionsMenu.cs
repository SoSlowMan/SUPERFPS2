using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;

    public resItem[] resolutions;

    public langItem[] languages;

    private int selectedResolution;

    private string selectedLanguage;

    public Text resolutionLabel, languageLabel;

    public AudioMixer theMixer;

    public Slider masterSlider, musicSlider, sfxSlider;

    public Text masterLabel, musicLabel, sfxLabel;

    public AudioSource sfxLoop;

    //public GameObject localizator;

    public Text bestTime, bestScore;

    public string language;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;//чтобы при рестарте опции знали настройки которые сейчас стоят

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        //search for the resolution on list
        bool foundRes = false;
        for(int i = 0; i < resolutions.Length; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }
        if(!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }


        if (PlayerPrefs.HasKey("Language"))
        {
            languageLabel.text = (PlayerPrefs.GetString("Language"));
            selectedLanguage = languageLabel.text;
        }
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol",PlayerPrefs.GetFloat("MasterVol"));
            masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        }
        masterLabel.text = (masterSlider.value + 80f).ToString();
        musicLabel.text = (musicSlider.value + 80f).ToString();
        sfxLabel.text = (sfxSlider.value + 80f).ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void resRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void langChange()
    {
        if (selectedLanguage != "Русский")
        {
            selectedLanguage = "Русский";
        }
        else selectedLanguage = "English";

        UpdateLangLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void UpdateLangLabel()
    {
        languageLabel.text = selectedLanguage;
    }

    public void ApplyGraphics()
    {
        //apply fullscreen
        //Screen.fullScreen = fullScreenTog.isOn;
        //apply Vsync
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        //apply resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
        //apply language
        //SetLanguage();
    }

    [System.Serializable]//нужно для того чтобы значения из класса могли быть видны на экране редактора юнити
    public class resItem
    {
        public int horizontal, vertical;
    }

    [System.Serializable]//нужно для того чтобы значения из класса могли быть видны на экране редактора юнити
    public class langItem
    {
        public string name;
    }

    public void SetLanguage()
    {
        PlayerPrefs.SetString("Language", selectedLanguage);
        languageLabel.text = selectedLanguage;
        if (PlayerPrefs.GetString("Language") == "Русский")
        {
            LocalizationScript.instance.translateToRussian();
        }
        else
        {
            LocalizationScript.instance.translateToEnglish();
        }
    }

    public void SetMasterVol()
    {
        masterLabel.text = (masterSlider.value + 80f).ToString();
        theMixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol",masterSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80f).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
       sfxLabel.text = (sfxSlider.value + 80f).ToString();
       theMixer.SetFloat("SFXVol", sfxSlider.value);
       PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    public void PlaySFXLoop()
    {
        sfxLoop.Play();
    }
    public void StopSFXLoop()
    {
        sfxLoop.Stop();
    }


}
