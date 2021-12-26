using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : Button
{
    private GameObject check;
    private Text textInChild;

    protected override void Start()
    {
        base.Start();

        check = GameObject.FindGameObjectWithTag("GameManager");
        textInChild = GetComponentInChildren<Text>();
    }

    // Just to pass char that has been pressed
    public override void OnPointerClick(PointerEventData eventData)
    {
        check.GetComponent<CharCheck>().ButtonTask(textInChild.text.ToString());

        this.gameObject.SetActive(false);
    }
}