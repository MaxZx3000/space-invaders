using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Spaceships spaceshipsPlayer;
    private Timer timeInvicible;
    [SerializeField] private string textPlayerHealthString;
    [SerializeField] private string textPlayerScoreString;
    private Text textHealth;
    private Text textCurrentScore;
    private AudioSource playerAudioSource;
    public AudioSource PlayerAudioSource { get => playerAudioSource; }
    public Text TextCurrentScore { get => textCurrentScore; }
    private int currentScore;
    public int CurrentScore { get => currentScore; set => currentScore = value; }
    public Spaceships SpaceshipsPlayer { get => spaceshipsPlayer; set => spaceshipsPlayer = value; }
    private int health = 100;
    public int Health { get => health; set => health = value; }
    private GameObject manageObjectsGameObject;
    // Start is called before the first frame update
    void Start()
    {
        manageObjectsGameObject = GameObject.Find("Canvas");
        playerAudioSource = GameObject.Find("PlayerAudioSource").GetComponent<AudioSource>();
        textHealth = GameObject.Find(textPlayerHealthString).GetComponent<Text>();
        textCurrentScore = GameObject.Find(textPlayerScoreString).GetComponent<Text>();
        timeInvicible = new Timer();
        timeInvicible.initializeCurrentTime(0);
        spaceshipsPlayer.Gun = Resources.Load("Prefabs/Bullet") as GameObject;
        GetComponent<SpriteRenderer>().sprite = spaceshipsPlayer.Sprite;
    }
    // Update is called once per frame
    void Update()
    {
        spaceshipsPlayer.MoveShip(transform);
        spaceshipsPlayer.Attack(transform, playerAudioSource);
        if (health < 1)
        {
            manageObjectsGameObject.GetComponent<ManageGameOverScreen>().CurrentScore = currentScore;
            manageObjectsGameObject.GetComponent<ManageGameOverScreen>().displayGameOver();
        }
    }
    public void increaseScore(int value){
        currentScore += value;
        textCurrentScore.text = currentScore + "";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && timeInvicible.determineIfFinished())
        {
            playerAudioSource.clip = Resources.Load("SoundEffects/PlayerHit") as AudioClip;
            playerAudioSource.Play();
            health -= (100 - spaceshipsPlayer.DEF);
            textHealth.text = "Lives: " + health;
            timeInvicible.initializeCurrentTime(0.8f);
        }
    }
}
