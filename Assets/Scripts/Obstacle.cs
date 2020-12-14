using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction = Vector3.left;
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
