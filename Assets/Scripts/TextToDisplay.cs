using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToDisplay : MonoBehaviour
{
    public Text text;
    private GameObject gameManager;
    private GameObject ptsContainer;

    public GameObject charPrefab;
    public Transform charParent;

    private Dictionary<int, string> textsToUse = new Dictionary<int, string>();
    public readonly List<GameObject> charToGuess = new List<GameObject>();

    [HideInInspector]
    public char[] arr;

    public Chars charContainer;

    private void Start()
    {
        text = GetComponent<Text>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        ptsContainer = GameObject.FindGameObjectWithTag("point");

        textsToUse = gameManager.GetComponent<TextHandler>().textContainer;

        GetText(charContainer.minChar);

        gameManager.GetComponent<CharCheck>().NewStart();
    }

    private void GetText(int charCount)
    {
        // Temporary solution to avoid infinite loop with more char
        if(charCount > 13)
            charCount = 13;

        int randomTextIndex = Random.Range(0, textsToUse.Count);

        string wantedString = gameManager.GetComponent<RandomWord>().RandomString(textsToUse[randomTextIndex]);

        if (wantedString != null && wantedString != "")
        {
            textsToUse[randomTextIndex] = gameManager.GetComponent<ReplaceWord>().ReplaceString(textsToUse[randomTextIndex], wantedString, "______");
        }
        else
        {
            GetText(charCount);
            return;
        }

        wantedString = wantedString.ToUpper();

        // Checking if word is already used
        // If not adding to list
        foreach (string s in ptsContainer.GetComponent<Points>().usedString)
        {
            if (s == wantedString)
            {
                GetText(charCount);
                return;
            }
            else
            {
                ptsContainer.GetComponent<Points>().usedString.Add(wantedString);
            }
        }

        text.text = textsToUse[randomTextIndex];

        arr = wantedString.ToCharArray();

        if (arr.Length < charCount)
        {
            GetText(charCount);
            return;
        }

        // To know answer
        print(wantedString);

        for (int charNumber = 0; charNumber < wantedString.Length; charNumber++)
        {
            GameObject charObject = Instantiate(charPrefab, charParent) as GameObject;
            charObject.GetComponentInChildren<Text>().text = arr[charNumber].ToString();
            charObject.GetComponentInChildren<Text>().enabled = false;
            charToGuess.Add(charObject);
        }
    }
}