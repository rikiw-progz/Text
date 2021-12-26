using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;

    public List<string> usedString = new List<string>();

    // To avoid multiple objects of same type
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("point");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}