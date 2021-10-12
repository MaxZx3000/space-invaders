using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchLevel : MonoBehaviour
{
    [SerializeField]private GameObject ClearGameObject;
    private GameObject nextLevel;
    public GameObject NextLevel { set => nextLevel = value; }
    private Timer timeLasts;
    [SerializeField] private AudioSource audioWon;
    void Start()
    {
        timeLasts = new Timer();
        this.enabled = false;
    }
    public void SetWonWindow()
    {
        GameObject[] bulletGameObject = GameObject.FindGameObjectsWithTag("Gun");
        foreach(GameObject bullet in bulletGameObject)
        {
            Destroy(bullet);
        }
        audioWon.clip = Resources.Load("SoundEffects/win") as AudioClip;
        audioWon.Play();
        timeLasts.initializeCurrentTime(3);
        ClearGameObject.SetActive(true);
    }
    void Update()
    {
        
        if (timeLasts.determineIfFinished() == true)
        {
            GameObject gameObject = Instantiate<GameObject>(nextLevel);
            gameObject.transform.name = "Level";
            ClearGameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
