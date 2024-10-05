using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private MovementBehaviour move;

    void Start()
    {
        move = FindObjectOfType<MovementBehaviour>();
    }

    void Update()
    {
        move.Move(transform, move.moveSpeed, 10f);  
    }
}
