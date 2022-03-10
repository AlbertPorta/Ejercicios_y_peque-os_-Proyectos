using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBola : MonoBehaviour
{
    public MovimientoBola bola;
    public float TiempoBonus;
    public float BonusUltimo;
    private int score;
    
    private float speed = 5f;

   
    // Use this for initialization
    void Start()
    {
        BonusUltimo = Time.time;
        TiempoBonus = 5f;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    private void Update()
    {
        
        if (Time.time - BonusUltimo > TiempoBonus && gameObject.activeSelf== true)
        {
            gameObject.SetActive(false);
        }
    }
    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    void OnCollisionEnter2D(Collision2D othercollision2D)
    {
        // Hit the Racket?
        if (othercollision2D.gameObject.name == "Player")
        {
            // Calculate hit Factor
            float x = HitFactor(transform.position,
                              othercollision2D.transform.position,
                              othercollision2D.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (othercollision2D.gameObject.name == "brick")
        {
            score++; 
            bola.SumaScore(score);
            this.score = 0;
        }
        if (othercollision2D.gameObject.name == "brick2")
        {
            score++;
            bola.SumaScore(score);
            this.score = 0;
        }
        if (othercollision2D.gameObject.tag == "Pared")
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0.05f, 0f) * speed;
        }
        if (othercollision2D.gameObject.tag == "Techo")
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0f, 0.05f) * speed;
        }
        if (othercollision2D.gameObject.name == "bridge")
        {
            score += 10;
        }
        if (bola.gameObject.activeSelf==false)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D othercollision2D)
    {
        if (othercollision2D.gameObject.name == "Suelo")
        {
            gameObject.SetActive(false);
        }
    }
    
}
