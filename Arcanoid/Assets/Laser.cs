using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public MovimientoBola bola;
    int score;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D othercollision2D)
    {
        if (othercollision2D.gameObject.name == "brick"||othercollision2D.gameObject.name == "brick2")                
        {
            this.score++;
            bola.SumaScore(this.score);
            this.score = 0;
            Destroy(gameObject);
        }
        if (othercollision2D.gameObject.name == "bridge")
        {
            this.score+=10;
            bola.SumaScore(this.score);
            this.score = 0;
            Destroy(gameObject);
        }
        if (othercollision2D.gameObject.tag == "bola" || othercollision2D.gameObject.name == "Techo")
        {
            Destroy(gameObject);
        }


    }
    
}
