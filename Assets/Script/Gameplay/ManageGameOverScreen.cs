using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageGameOverScreen : MonoBehaviour
{
    private GameObject levelGameObject;
    private GameObject playerGameObject;
    [SerializeField] private GameObject gameOverGameObject;
    [SerializeField] private Text textScoreGameObject;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private GameObject statsPanel;
    private int currentScore = 0;
    public int CurrentScore { set => currentScore = value; }
    public void displayGameOver()
    {
        levelGameObject = GameObject.Find("Level");
        playerGameObject = GameObject.Find("Ship");
        textScoreGameObject.text = "Your score is: " + currentScore;
        Destroy(levelGameObject);
        Destroy(playerGameObject);
        statsPanel.SetActive(false);
        musicAudioSource.clip = null;
        gameOverGameObject.SetActive(true);
    }
}
