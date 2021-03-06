using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomWord
{
    // Get text and divide into words
    // Get random one
    // If word consist only from letters
    public static string RandomString(string text)
    {
        string[] randomStrings = text.Split(' ');

        int randomIndex = Random.Range(0, randomStrings.Length);

        string randomResult = randomStrings[randomIndex];

        if (!IsAllLetters(randomResult))
        {
            return null;
        }
        else
        {
            return randomResult;
        }
    }


    // Is it all Letters?
    public static bool IsAllLetters(string s)
    {
        foreach (char c in s)
        {
            if (!char.IsLetter(c) || char.IsSymbol(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c))
                return false;
        }
        return true;
    }
}