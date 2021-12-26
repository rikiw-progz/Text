using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : Button
{
    // Just to pass char that has been pressed
    public override void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<CharCheck>().ButtonTask(GetComponentInChildren<Text>().text.ToString());

        this.gameObject.SetActive(false);
    }
}