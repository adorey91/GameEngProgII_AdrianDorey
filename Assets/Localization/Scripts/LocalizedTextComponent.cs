using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizedTextComponent : MonoBehaviour
{
    [SerializeField] private string tableReference; // name of the table [ui here in example]
    [SerializeField] private string localizationKey; // key

    public LocalizedString localizedString; // this holds the key and reference -- actual translation happens here
    public Text textComponent; // text component we're localizing

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        localizedString = new LocalizedString { TableReference = tableReference, TableEntryReference = localizationKey };

        //var frenchLocale = LocalizationSettings.AvailableLocales.GetLocale("fr");
        //LocalizationSettings.SelectedLocale = frenchLocale;


        //UpdateText(frenchLocale);
    }

    private void OnEnable()
    {
        
        LocalizationSettings.SelectedLocaleChanged += UpdateText;
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= UpdateText;
        
    }

    void UpdateText(Locale locale)
    {
        textComponent.text = localizedString.GetLocalizedString(); // actual translation happens here
    }
}
