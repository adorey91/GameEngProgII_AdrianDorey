using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Language
{
    public string lang;
    public string title;
    public string play;
    public string quit;
    public string options;
    public string credits;
}

public class LanguageData
{
    public Language[] languages;
}

public class Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    public enum Lanuages { en, fr};

    public string currentLanguage;
    private LanguageData languageData;

    public Text titleText;
    public Text playText;
    public Text quitText;
    public Text optionsText;
    public Text creditsText;

    private void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        SetLanguage(currentLanguage);
    }

    public void SetLanguage(string newLanguage)
    {
        foreach(Language lang in languageData.languages)
        {
            if(lang.lang.ToLower() == newLanguage.ToLower())
            {
                titleText.text = lang.title;
                playText.text = lang.play;
                quitText.text = lang.quit;
                optionsText.text = lang.options;
                creditsText.text = lang.credits;
                return;
            }
        }
    }
}
