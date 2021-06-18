using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // Attach this script to a GameObject and retrieve text with: TitleCanvasGameObject.GetComponent<Text>().text = Language.Instance.dictionary["mainmenu_title"];
    // Remember to re-get all strings after changing language

    public static Language Instance { get; private set; }

    private const char Separator = '=';
    [SerializeField] public readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();

    private string currentLanguage = "English";

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ReadProperties();
    }

    public void SwitchLanguage (string lang)
	{
        currentLanguage = lang;

        ReadProperties();
    }

    private void ReadProperties()
    {
        var file = Resources.Load<TextAsset>("Languages/" + currentLanguage);

        foreach (var line in file.text.Split('\n'))
        {
            var prop = line.Split(Separator);
            dictionary[prop[0]] = prop[1].Replace("\\n", "\n");
        }
    }

    public void ResolveTexts()
    {
        var allTexts = Resources.FindObjectsOfTypeAll<LangText>();
        foreach (var langText in allTexts)
        {
            var text = langText.GetComponent<Text>();
            text.text = Regex.Unescape(dictionary[langText.Identifier]);
        }
    }
}

public class LangText : MonoBehaviour
{
    public string Identifier;
}