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
    [SerializeField] private Dropdown languageDropdown;
    public TextAsset jsonFile;

    public string currentLanguage = "en"; // Default language is english
    private LanguageData languageData;

    public Text titleText;
    public Text playText;
    public Text quitText;
    public Text optionsText;
    public Text creditsText;

    private void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        PopulateDropdown();
        SetLanguage(currentLanguage);
    }

    // Populate the dropdown with the names of the languages (e.g., "English", "French")
    private void PopulateDropdown()
    {
        List<string> languageNames = new List<string>();
        foreach (Language lang in languageData.languages)
        {
            languageNames.Add(GetLanguageName(lang.lang));  // Convert language code to human-readable name
        }

        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(languageNames);

        // Set the dropdown to the current language (default or previously selected)
        int selectedIndex = languageNames.IndexOf(GetLanguageName(currentLanguage));
        languageDropdown.value = selectedIndex;

        // Add listener to update language when selection changes
        languageDropdown.onValueChanged.AddListener(OnLanguageDropdownChanged);
    }

    // Convert language code to human-readable name (e.g., "en" -> "English")
    private string GetLanguageName(string langCode)
    {
        switch (langCode.ToLower())
        {
            case "en":
                return "English";
            case "fr":
                return "French";
            // Add more cases for additional languages
            default:
                return langCode;  // Fallback to the code if the name is unknown
        }
    }

    // Update the language when the user selects a new one from the dropdown
    private void OnLanguageDropdownChanged(int index)
    {
        string selectedLangCode = languageData.languages[index].lang;  // Get the language code for the selected option
        currentLanguage = selectedLangCode;
        SetLanguage(selectedLangCode);
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
