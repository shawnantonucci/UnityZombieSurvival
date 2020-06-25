using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        
    }

    private void MoveToPos()
    {

    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandoDir() * Random.Range(10f, 70f);
    }


    private Vector3 GetRandoDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f,1f)).normalized;
    }
}
