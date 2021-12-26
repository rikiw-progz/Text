using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharCheck : MonoBehaviour
{
    public GameObject lostImage;
    private GameObject ptsContainer;
    private GameObject textContainer;

    private int arrLength;

    private char[] arr;
    private int points;
    private int life;
    public Text pts;
    public Text lifeTxt;

    private Chars charContainer;

    private List<GameObject> charToGuess = new List<GameObject>();

    public void NewStart()
    {
        ptsContainer = GameObject.FindGameObjectWithTag("point");
        textContainer = GameObject.FindGameObjectWithTag("DisplayText");

        charContainer = textContainer.GetComponent<TextToDisplay>().charContainer;
        arr = textContainer.GetComponent<TextToDisplay>().arr;
        arrLength = arr.Length;

        charToGuess = textContainer.GetComponent<TextToDisplay>().charToGuess;

        points = ptsContainer.GetComponent<Points>().points;
        pts.text = points.ToString();

        lifeTxt.text = charContainer.life.ToString();
        life = charContainer.life;
    }

    public void ButtonTask(string charCompare)
    {
        int charCountCheck = points;

        for(int charIndex = 0; charIndex < arr.Length; charIndex++)
        {
            // if button pressed correct
            if (charCompare == arr[charIndex].ToString())
            {
                points++;
                pts.text = points.ToString();

                if (charCountCheck + 1 == points)
                    life++;
                
                CheckForChar(charIndex);

                arrLength--;
                // When all chars has been answered and word is fully guessed
                if (arrLength <= 0)
                    WordGuessed();
            }
        }
        life--;
        lifeTxt.text = life.ToString();
        // if lost
        if (life < 0)
            StartCoroutine(Lost());
    }

    // If button pressed correct
    // Searching for pressed char
    private void CheckForChar(int seachingChar)
    {
        for (int i = 0; i < charToGuess.Count; i++)
        {
            if (charToGuess[i].GetComponentInChildren<Text>().text == arr[seachingChar].ToString())
            {
                charToGuess[i].GetComponentInChildren<Text>().enabled = true;
            }
        }
    }

    private void WordGuessed()
    {
        ptsContainer.GetComponent<Points>().points = points + (life - 1);
        SceneManager.LoadScene("SampleScene");
    }

    // When lost text "You lost" shows up
    // After 2 second, points and used words will be reset
    // Then restart scene
    private IEnumerator Lost()
    {
        lostImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        ptsContainer.GetComponent<Points>().points = 0;
        ptsContainer.GetComponent<Points>().usedString.Clear();

        SceneManager.LoadScene("SampleScene");
    }
}