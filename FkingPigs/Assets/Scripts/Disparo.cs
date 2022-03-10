using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private bool gameIsPaused;
    GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        rotationSpeed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.Rotate(Vector3.left, 10* rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    
}
