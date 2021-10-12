using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    [SerializeField] private Vector3 amountOfTranslate;
    private static GunCommand[] gunCommand;
    [SerializeField] private float maxHeight;
    [SerializeField] private Rigidbody2D rigidbody2D;
    private int atk;
    public int ATK { get => atk; set => atk = value; }
    abstract class GunCommand
    {
        public abstract void command(Gun gun);
    }
    class MoveForward: GunCommand
    {
        public override void command(Gun gun) { gun.rigidbody2D.velocity = gun.amountOfTranslate; }
    }
    class DestroyThis : GunCommand
    {
        public override void command(Gun gun)
        {
            if (Mathf.Abs(gun.transform.position.y) >= gun.maxHeight)
            {
                Destroy(gun.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gunCommand == null)
        {
            gunCommand = new GunCommand[2] { new MoveForward(), new DestroyThis()};
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GunCommand c in gunCommand)
        {
            c.command(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<DetectEnemyInfo>() != null)
        {
            GetComponent<DetectEnemyInfo>().ReduceHealth(collision, atk);
        }
        else if (GetComponent<ReducePlayerHealth>() != null)
        {
            GetComponent<ReducePlayerHealth>().ReduceHealth(collision);
        }
    }
}
