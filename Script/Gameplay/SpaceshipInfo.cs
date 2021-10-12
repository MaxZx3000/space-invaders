using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpaceshipInfo : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text textNameShip;
    [SerializeField] private Text textATK;
    [SerializeField] private Text textDEF;
    [SerializeField] private Text textMovementSpeed;
    [SerializeField] private GameObject rightChooser;
    [SerializeField] private GameObject leftChooser;
    [SerializeField] private GameObject statsWindow;
    private Spaceships[] spaceships;
    private int spaceshipsCount;
    private int currentIndex = 0;
    private void ShowInformation(Spaceships spaceships)
    {
        this.image.sprite = spaceships.Sprite;
        this.textATK.text = spaceships.ATK + "";
        this.textDEF.text = spaceships.DEF + "";
        this.textNameShip.text = spaceships.CharacterName;
        this.textMovementSpeed.text = spaceships.MovementSpeed + "";
    }
    // Start is called before the first frame update
    void Start()
    {
        spaceships = new Spaceships[3]{ new SpaceshipOne(), new SpaceShipTwo(), new SpaceShipThree()};
        spaceshipsCount = spaceships.Length;
        ShowInformation(spaceships[currentIndex]);
    }
    public void InstantiatePlayer()
    {
        GameObject gameObject = Instantiate(Resources.Load<GameObject>("Prefabs/Ship"), null) as GameObject;
        gameObject.name = "Ship";
        gameObject.GetComponent<Player>().SpaceshipsPlayer = spaceships[currentIndex];
    }
    public void InstantiateFirstLevel()
    {
        GameObject gameObject = Instantiate(Resources.Load<GameObject>("LevelDesign/Level1"), null) as GameObject;
        gameObject.transform.name = "Level";
        statsWindow.SetActive(true);
    }
    public void NextShip()
    {
        Debug.Log(currentIndex);
        if (currentIndex < spaceshipsCount - 1)
        {
            currentIndex += 1;
        }
        else
        {
            currentIndex = 0;
        }
        ShowInformation(spaceships[currentIndex]);
    }
    public void PreviousShip()
    {
        if (currentIndex > 0)
        {
            currentIndex -= 1;
        }
        else
        {
            currentIndex = spaceshipsCount - 1;
        }
        ShowInformation(spaceships[currentIndex]);
    }
}
