using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReplaceWord
{
    // Find first string "find" from multiple strings in "source"
    // Replace string "find" with "replace"
    public static string ReplaceString(string source, string find, string replace)
    {
        int place = source.IndexOf(find);
        string result = source.Remove(place, find.Length).Insert(place, replace);
        return result;
    }
}