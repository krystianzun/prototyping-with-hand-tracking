using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyMovement : MonoBehaviour
{

    public Transform target;
    public float speed = 1;
    public Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed * Time.deltaTime);
    }
}
