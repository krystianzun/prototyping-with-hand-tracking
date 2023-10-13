using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedChildMovementWorking : MonoBehaviour
{
    public Transform target;
    public float followDelay = 0.5f;
    public float smoothSpeed = 0.125f;

    private Vector3 initialLocalPosition;
    private Vector3[] positions;
    private int positionIndex;
    private int maxPositions;

    private void Start()
    {
        initialLocalPosition = transform.localPosition;
        maxPositions = Mathf.CeilToInt(followDelay / Time.fixedDeltaTime);
        positions = new Vector3[maxPositions];
        for (int i = 0; i < maxPositions; i++)
        {
            positions[i] = target.TransformPoint(initialLocalPosition);
        }
        positionIndex = 0;
    }

    private void FixedUpdate()
    {
        positions[positionIndex] = target.TransformPoint(initialLocalPosition);
        positionIndex = (positionIndex + 1) % maxPositions;
        Vector3 targetPosition = positions[positionIndex];
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}