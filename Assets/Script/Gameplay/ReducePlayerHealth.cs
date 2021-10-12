using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReducePlayerHealth : MonoBehaviour
{
    [SerializeField] private string textPlayerHealthString;
    private Text textPlayerHealth;
    private void Start()
    {
        textPlayerHealth = GameObject.Find(textPlayerHealthString).GetComponent<Text>();
    }
    public void ReduceHealth(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource audioSourcePlayer = collision.gameObject.GetComponent<Player>().PlayerAudioSource;
            audioSourcePlayer.clip = Resources.Load("SoundEffects/PlayerHit") as AudioClip;
            audioSourcePlayer.Play();
            collision.GetComponent<Player>().Health -= (100 - collision.GetComponent<Player>().SpaceshipsPlayer.DEF);
            textPlayerHealth.text = "Lives: " + collision.GetComponent<Player>().Health;
            Destroy(gameObject);
        }
    }
}
