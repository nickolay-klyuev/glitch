using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;
    private Button[] buttonArray;
    private Text costText;

    // Start is called before the first frame update
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = gameObject.GetComponentInChildren<Text>();
        if (costText == null)
        {
            Debug.LogWarning(name + ": missing cost text element");
        }
        else
        {
            costText.text = defenderPrefab.GetComponent<Defender>().starsCost.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
