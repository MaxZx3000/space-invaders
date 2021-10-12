using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Spaceships
{
    protected int atk;
    protected int def;
    protected int movementSpeed;
    protected string characterName;
    protected Sprite sprite;
    protected GameObject gun;
    public GameObject Gun { set => gun = value; }
    private Timer timer = new Timer();
    public int ATK { get => atk; }
    public int DEF { get => def; }
    public int MovementSpeed { get => movementSpeed; }
    public string CharacterName { get => characterName; }
    public Sprite Sprite { get => sprite; }
    public void Attack(Transform transform, AudioSource audioSource)
    {
        if (Input.GetMouseButton(0) && timer.determineIfFinished())
        {
            audioSource.clip = Resources.Load("SoundEffects/LaserShoot") as AudioClip;
            audioSource.Play();
            GameObject gameObject = GameObject.Instantiate(gun, transform.position, Quaternion.identity) as GameObject;
            gameObject.GetComponent<Gun>().ATK = atk;
            timer.initializeCurrentTime(0.5f);
        }
    }
    public void MoveShip(Transform transform)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector3 newMousePos = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        // Debug.Log(transform.position + " " + newMousePos);
        float valueX = (newMousePos.x - (transform.position.x)) * movementSpeed * Time.deltaTime;
        float valueY = (newMousePos.y - (transform.position.y)) * movementSpeed * Time.deltaTime;
        float currentX = transform.position.x + valueX;
        float currentY = transform.position.y + valueY;
        if (Mathf.Abs(currentX) > 8.4f) currentX = Mathf.Sign(transform.position.x) * 8.3f;
        if (Mathf.Abs(currentY) > 4.5f) currentY = Mathf.Sign(transform.position.y) * 4.4f;
        transform.position = new Vector3(currentX, currentY);
    }
}
class SpaceshipOne: Spaceships
{
    public SpaceshipOne()
    {
        this.atk = 20;
        this.def = 80;
        this.movementSpeed = 4;
        this.characterName = "SF-20";
        this.sprite = Resources.Load<Sprite>("Images/Ship") as Sprite;
    }
}
class SpaceShipTwo: Spaceships
{
    public SpaceShipTwo()
    {
        this.atk = 15;
        this.def = 85;
        this.movementSpeed = 3;
        this.characterName = "DF-20";
        this.sprite = Resources.Load<Sprite>("Images/Ship2") as Sprite;
    }
}
class SpaceShipThree: Spaceships
{
    public SpaceShipThree()
    {
        this.atk = 20;
        this.def = 90;
        this.movementSpeed = 2;
        this.characterName = "XF-20";
        this.sprite = Resources.Load<Sprite>("Images/Ship3") as Sprite;
    }
}