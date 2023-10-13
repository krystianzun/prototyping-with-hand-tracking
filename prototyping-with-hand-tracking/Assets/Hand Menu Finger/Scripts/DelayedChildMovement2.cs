using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedChildMovement2 : MonoBehaviour
{
    public Transform target;
    public float followDelay = 0.5f;

    private Vector3 initialOffset;
    private Queue<Vector3> positionQueue;

    private void Start()
    {
        initialOffset = transform.position - target.position;
        positionQueue = new Queue<Vector3>();

        int queueSize = Mathf.RoundToInt(followDelay / Time.fixedDeltaTime);
        for (int i = 0; i < queueSize; i++)
        {
            positionQueue.Enqueue(target.position);
        }
    }

    private void FixedUpdate()
    {
        if (positionQueue.Count > 0)
        {
            positionQueue.Enqueue(target.position);
            transform.position = positionQueue.Dequeue() + initialOffset;
        }
    }
}
