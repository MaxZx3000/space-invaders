using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField]private int[] posX = { 0, -1280, -2560};
    private int currentPosition = 0;
    [SerializeField] private GameObject mover;
    [SerializeField] private int moveSpeed;
    private void SetPositionMover()
    {
         mover.transform.localPosition = Vector3.MoveTowards(mover.transform.localPosition, new Vector3(posX[currentPosition], 0), moveSpeed);
    }
    private void OnEnable()
    {
        currentPosition = 0;
        mover.transform.localPosition = new Vector3(posX[currentPosition], 0);
    }
    private void Update()
    {
        SetPositionMover();
    }
    public  void MoveNext()
    {
        if (currentPosition < 2) currentPosition += 1;
        else currentPosition = 0;
        
    }
    public void MovePrevious()
    {
        if (currentPosition > 0) currentPosition -= 1;
        else currentPosition = 2;
    }
}
