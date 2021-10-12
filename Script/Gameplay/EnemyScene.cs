using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScene : MonoBehaviour
{
    [SerializeField] private GameObject sourceEnemies;
    [SerializeField] private int numberOfEnemyLasers;
    private static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> Enemies { get => enemies; }
    private Timer timerMoveDown = new Timer();
    private Timer timerShootLasers = new Timer();
    private GameObject playerGameObject;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private float maxWidth;
    [SerializeField] private float maxHeight;
    private GameObject UIClear;
    private AudioSource audioSourceEnemy;
    public AudioSource AudioSourceEnemy { get => audioSourceEnemy; }
    public float MaxWidth { get => maxWidth; }
    public float MaxHeight { get => maxHeight; }
    public GameObject PlayerGameObject { get => playerGameObject; }
    private void GetAllChildren()
    {
        for (int i = 0; i < sourceEnemies.transform.childCount; i++)
        {
            enemies.Add(sourceEnemies.transform.GetChild(i).gameObject);
        }
    }
    private void OnDestroy()
    {
        enemies.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Ship");
        audioSourceEnemy = GameObject.Find("EnemyAudioSource").GetComponent<AudioSource>();
        UIClear = GameObject.Find("Canvas");
        UIClear.GetComponent<SwitchLevel>().enabled = false;
        GetAllChildren();
        timerMoveDown.initializeCurrentTime(7);
        timerShootLasers.initializeCurrentTime(2);
    }
    private void shuffleEnemiesShootLaser()
    {
        for (int i = 0; i < numberOfEnemyLasers && i < sourceEnemies.transform.childCount; i++)
        {
            int indexSwitch = Random.Range(i, sourceEnemies.transform.childCount - 1);
            GameObject temp = enemies[i];
            enemies[i] = enemies[indexSwitch];
            enemies[indexSwitch] = temp;
        }
    }
    void oneEnemyShootLaser()
    {
        if (timerShootLasers.determineIfFinished())
        {
            audioSourceEnemy.clip = Resources.Load("SoundEffects/LaserEnemyShoot") as AudioClip;
            audioSourceEnemy.Play();
            int numberEnemiesShootLaser = 0;
            shuffleEnemiesShootLaser();
            for (int i = 0; numberEnemiesShootLaser < numberOfEnemyLasers && i < sourceEnemies.transform.childCount; i++)
            {
                if (enemies[i] != null) enemies[i].GetComponent<EnemyProperties>().ShootLaser(); numberEnemiesShootLaser++;
            }
            timerShootLasers.initializeCurrentTime(2);
        }
    }
    void moveToNextLevel()
    {
        if (sourceEnemies.transform.childCount < 1)
        {
            GameObject gameUIController = GameObject.Find("Canvas");
            SwitchLevel switchLevel = gameUIController.GetComponent<SwitchLevel>();
            switchLevel.enabled = true;
            switchLevel.NextLevel = nextLevel;
            switchLevel.SetWonWindow();
            Destroy(gameObject);
        }
    }
    void oneEnemyFollowPlayer()
    {
        if (timerMoveDown.determineIfFinished())
        {
            audioSourceEnemy.clip = Resources.Load("SoundEffects/EnemyFollow") as AudioClip;
            audioSourceEnemy.Play();
            int randomEnemy = Random.Range(0, sourceEnemies.transform.childCount - 1);
            if (enemies[randomEnemy] != null) enemies[randomEnemy].GetComponent<EnemyProperties>().CurrentState = 1;
            timerMoveDown.initializeCurrentTime(7);
        }  
    }
    void MoveAllEnemy()
    {
        foreach(GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                EnemyProperties.EnemyActions.MoveEnemy(enemy.transform, MaxWidth);
            }
        }
        EnemyProperties.EnemyActions.TurnDirection();
    }
    void LateUpdate()
    {
        MoveAllEnemy();
        oneEnemyShootLaser();
        oneEnemyFollowPlayer();
        moveToNextLevel();
    }
}
