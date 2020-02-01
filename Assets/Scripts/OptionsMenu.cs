using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ПОФИКСИТЬ UI ЧТОБЫ ПРИ СМЕНЕ РАЗРЕШЕНИЯ НА ВСЯКОЕ ЕБАНОЕ КНОПКИ ВСЕ ЕЩЕ РАБОТАЛИ
public class OptionsMenu : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;

    public resItem[] resolutions;

    private int selectedResolution;

    public Text resolutionLabel;
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

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
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
    }

    [System.Serializable]//нужно для того чтобы значения из класса могли быть видны на экране редактора юнити
    public class resItem
    {
        public int horizontal, vertical;
    }
}
