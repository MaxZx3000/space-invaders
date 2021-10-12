using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private short nextMovementDirection = 1;
    private float speedMoveHorizontal = 1.5f;
    private float speedFollowEnemyX = 2f;
    private float speedFollowEnemyY = -5f;
    private GameObject laser;
    public GameObject Laser { set => laser = value; }
    public void DestroyEnemy(GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
    }
    public void MoveEnemy(Transform transform, float maxWidth)
    {
        EnemyProperties enemyProp = transform.gameObject.GetComponent<EnemyProperties>();
        float increasedValue = speedMoveHorizontal * Time.deltaTime;
        float newPositionX = enemyProp.CurrentPosition.x + increasedValue;
        enemyProp.CurrentPosition = new Vector3(newPositionX, enemyProp.CurrentPosition.y);
        if (Mathf.Abs(newPositionX + speedMoveHorizontal * Time.deltaTime) >= maxWidth) nextMovementDirection = -1;
        if (enemyProp.CurrentState == 0)
        {
            transform.position = enemyProp.CurrentPosition;
        }
    }
    public void TurnDirection()
    {
        speedMoveHorizontal *= nextMovementDirection;
        nextMovementDirection = 1;
    }
    public void FollowEnemyToPlayer(Transform transform, Transform playerTransform, float maxHeight)
    {
        EnemyProperties enemyProp = transform.gameObject.GetComponent<EnemyProperties>();
        enemyProp.CurrentState = 1;
        if (Mathf.Abs(transform.position.y) < maxHeight)
        {
            float differenceX = (playerTransform.position.x - transform.position.x) * speedFollowEnemyX * Time.deltaTime;
            transform.position += new Vector3(differenceX, speedFollowEnemyY * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, maxHeight + 0.05f);
            enemyProp.CurrentState = 2;
        }
    }
    public void BackToOriginalPosition(Transform transform)
    {
        Vector3 lastPosition = transform.gameObject.GetComponent<EnemyProperties>().CurrentPosition;
        if (Mathf.Approximately(transform.position.y, lastPosition.y) == false)
        {
            transform.position += new Vector3((lastPosition.x - transform.position.x) * 15 * Time.deltaTime, (lastPosition.y - transform.position.y) * 5 * Time.deltaTime);
        }
        else
        {
            transform.gameObject.GetComponent<EnemyProperties>().CurrentState = 0;
        }
    }
    public void AttackLasers(Transform transform, AudioSource audioSource)
    {
        GameObject.Instantiate(laser, transform.position, Quaternion.identity);
    }
}

