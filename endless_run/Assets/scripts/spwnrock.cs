using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnrock : MonoBehaviour
{
 
    public float speed;
    private void Start()
    {
        Destroy(gameObject, 3);

    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
