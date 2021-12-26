using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    public TextAsset txt;

    public Dictionary<int, string> textContainer = new Dictionary<int, string>();

    private List<string> tempString = new List<string>();
    private int tempIndex;

    // Dividing text into line of strings
    // Collecting them piece by piece to make text
    // Adding to dictionary
    void Awake()
    {
        string[] s = txt.text.Split('\n');

        for (int i = 0; i < s.Length; i++)
        {
            if (!EmptyOrNull(s[i]) && i > 0)
            {
                if (EmptyOrNull(s[i - 1]) && !EmptyOrNull(s[i + 1]))
                {
                    tempString.Add(s[i]);
                }
                else if (!EmptyOrNull(s[i - 1]) && !EmptyOrNull(s[i + 1]))
                {
                    tempString.Add(s[i]);
                }
                else if (!EmptyOrNull(s[i - 1]) && EmptyOrNull(s[i + 1]))
                {
                    tempString.Add(s[i]);

                    var stringToText = string.Join(" ", tempString);

                    textContainer.Add(tempIndex, stringToText);
                    tempIndex++;
                    tempString.Clear();
                }
                else
                {
                    // Words which are not text skipped here
                }
            }
        }
    }

    // Checking if the line of string has strings or chars
    private bool EmptyOrNull(string lineOfText)
    {
        if (lineOfText == null || lineOfText == "")
            return true;
        else
            return false;
    }
}