using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class CheckLanguage : MonoBehaviour
{
    public Button[] languageButtons;

    private void Start()
    {
        int index = 0;
        while (index < languageButtons.Length)
        {
            Debug.Log(index);
            AddListener(languageButtons[index], index);
            index++;
        }
    }

    void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        Debug.Log(LocalizationSettings.SelectedLocale);
        selectLanguage(index);
        
    }

    void AddListener(Button button, int parameter)
    {
        button.onClick.AddListener(delegate { LocaleSelected(parameter); });
    }

    void selectLanguage(int index)
    {
        for(int i = 0; i < languageButtons.Length; i++)
        {
            if(i == index)
            {
                languageButtons[i].GetComponent<Image>().color = Color.white;
            }else
            {
                languageButtons[i].GetComponent<Image>().color = Color.gray;
            }
        }
    }
}