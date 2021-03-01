using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeToWin = 10.0f;
    private float timePased = 0f;
    private bool isWin = false;
    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private GameObject youWinText;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        youWinText = GameObject.Find("You Win");
        if (youWinText == null)
        {
            Debug.LogWarning("You Win text is missing");
        }
        youWinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timePased += Time.deltaTime;
        slider.value = timePased / timeToWin;
        if (timePased >= timeToWin && !isWin)
        {
            isWin = true;
            audioSource.Play();
            youWinText.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadLevel("03a Win");
    }
}
