using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    private Vector3 currentPosition;
    private EnemyScene enemyScene;
    public EnemyScene EnemyScene { get => enemyScene; }
    private static Enemy enemyActions;
    public static Enemy EnemyActions { get => enemyActions; }
    public Vector3 CurrentPosition { get => currentPosition; set => currentPosition = value; }
    private short currentState = 0;
    public short CurrentState { get => currentState; set => currentState = value; }
    [SerializeField] private int currentHealth;
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    [SerializeField] private int pointEarned;
    public int PointEarned { get => pointEarned; }
    void Start()
    {
        if (enemyActions == null) {
            enemyActions = new Enemy();
            enemyActions.Laser = Resources.Load("Prefabs/EnemyBullet") as GameObject;
        }
        currentPosition = transform.position;
        enemyScene = transform.parent.GetComponent<EnemyScene>();
    }
    public void ShootLaser()
    {
        enemyActions.AttackLasers(transform, enemyScene.AudioSourceEnemy);
    }
    private void Update()
    {
        if (currentState == 1)
        {
            enemyActions.FollowEnemyToPlayer(transform, enemyScene.PlayerGameObject.transform, enemyScene.MaxHeight);
        }
        else if (currentState == 2)
        {
            enemyActions.BackToOriginalPosition(transform);
        }   
    }
}
