using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = 10f;
        
    }

    void Update()
    {
        MueveLaser();
        DestruyeLaser();
    }
    void MueveLaser()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void DestruyeLaser()
    {
        if (transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
    }

}
