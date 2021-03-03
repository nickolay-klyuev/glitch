using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour
{
    public enum Status {SUCCESS, FAILURE}
    private int starsCount = 12;
    private Text starsText;

    // Start is called before the first frame update
    void Start()
    {
        starsText = gameObject.GetComponent<Text>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStars(int stars)
    {
        starsCount += stars;
        UpdateDisplay();
    }

    public Status UseStars(int stars)
    {
        if (stars <= starsCount)
        {
            starsCount -= stars;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        else
        {
            return Status.FAILURE;
        }
    }

    private void UpdateDisplay()
    {
        starsText.text = starsCount.ToString();
    }
}
