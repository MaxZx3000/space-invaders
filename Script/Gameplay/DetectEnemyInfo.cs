using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectEnemyInfo : MonoBehaviour
{
    [SerializeField] private string textEnemyInfoString;
    private Text textEnemyInfo;
    private Player player;
    private void Start()
    {
        textEnemyInfo = GameObject.Find(textEnemyInfoString).GetComponent<Text>();
        player = GameObject.Find("Ship").GetComponent<Player>();
    }
    public void GetInfo(Collider2D collision, Text textEnemyHealth)
    {
        if (collision != null)
        {
            textEnemyHealth.text = collision.gameObject.GetComponent<EnemyProperties>().CurrentHealth + "";
        }
        else
        {
            textEnemyHealth.text = "0";
        }
    }
    
    public void ReduceHealth(Collider2D collision, int atk)
    {
        if (collision.tag == "Enemy")
        {
            AudioSource playerAudioSource = player.PlayerAudioSource;
            playerAudioSource.clip = Resources.Load("SoundEffects/EnemyHit") as AudioClip;
            playerAudioSource.Play();
            EnemyProperties enemyProperties = collision.GetComponent<EnemyProperties>();
            enemyProperties.CurrentHealth -= atk;
            if (enemyProperties.CurrentHealth < 1)
            {
                EnemyScene.Enemies.Remove(collision.gameObject);
                player.increaseScore(enemyProperties.PointEarned);
                Destroy(collision.gameObject);
                collision = null;
            }
            GetInfo(collision, textEnemyInfo);
            Destroy(gameObject);
        }
    }
}