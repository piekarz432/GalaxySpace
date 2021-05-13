using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{

    public bool isEnglish;

    public bool isPolish;

    public LocalizedString myString;

    void foo()
    {
    }

    string localizedText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isEnglish = false;
    }

    public void checkEnglish()
    {
        isEnglish = true;
        isPolish = false;
        checkLanguage();
    }

    public void checkPolish()
    {
        isPolish = true;
        isEnglish = false;
        checkLanguage();
    }

    public void checkLanguage()
    {
        if(isEnglish)
        {
            Debug.Log(LocalizationSettings.AvailableLocales.Locales);
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
    }

}
