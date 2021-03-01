using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject deffenderParent;
    private StarsDisplay starsDisplay;

    void Start()
    {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();

        deffenderParent = GameObject.Find("Defenders");
        if (deffenderParent == null)
        {
            deffenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        StarsDisplay.Status useStarsResult = starsDisplay.UseStars(Button.selectedDefender.GetComponent<Defender>().starsCost);

        if (useStarsResult == StarsDisplay.Status.SUCCESS)
        {
            Vector2 rawPosition = CalculateWorldPointOfMouseClick();
            Vector2 position = SnapToGrid(rawPosition);
            GameObject newDefender = Instantiate(Button.selectedDefender, position, Quaternion.identity) as GameObject;
            newDefender.transform.parent = deffenderParent.transform;
        }
        else
        {
            Debug.Log("To buy it you need more stars");
        }
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;
    }
}
