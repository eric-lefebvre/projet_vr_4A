using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMoveTrigger : MonoBehaviour
{
    bool moved = false;
    Vector3 lastPosition;
    [SerializeField] private GameEvent playerMoved;

    private void Awake()
    {
        lastPosition = transform.position;
    }
    void Update()
    {
        if (!moved)
        {
            Debug.Log(lastPosition);
            Debug.Log(transform.position);
            if (transform.position != lastPosition)
            {
                moved = true;
                playerMoved.TriggerEvent();
            }
            lastPosition = transform.position;
        }
    }
}
