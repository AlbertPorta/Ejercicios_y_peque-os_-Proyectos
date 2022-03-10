using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoBola : MonoBehaviour
{
    public float TiempoBonus;
    public float BonusUltimo;
    public int indexBonus;
    public int score;
    public int vidas;
    public int contadorLevel;
    public float speed = 10f;

    public static int scoreStatic;
    public static int vidasStatic;

    // Use this for initialization
    void Start()
    {
        vidas = 3;
        TiempoBonus = 5f ;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        indexBonus = 0;
        contadorLevel = 1;
    }
    private void Update()
    {
        scoreStatic = score;
        vidasStatic = vidas;
        
        if (gameObject.transform.localScale.x == 0.8f && indexBonus == 0)
        {
            BonusUltimo = Time.time;
            indexBonus++;
        }
        if (Time.time - BonusUltimo > TiempoBonus)
        {
            gameObject.transform.localScale = new Vector2(0.4f, 0.4f);
            indexBonus=0;
        }
        if (vidas <= 0)
        {
            Destroy(gameObject);
            Over.GameOver();

        }
        if (score >= 42&& contadorLevel==1)
        {
            StartCoroutine(LevelUp());
         
            
        }
        if (score>= 210)
        {
            Over.Win();
        }
    }
    float HitFactor(Vector2 ballPos, Vector2 racketPos,float racketWidth)
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
        }
        if (othercollision2D.gameObject.name == "brick2")
        {
            score++;
        }
        if (othercollision2D.gameObject.tag == "Pared")
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0.1f, -0.1f) * speed;
        }
        if (othercollision2D.gameObject.tag == "Techo")
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -0.1f) * speed;
        }
        if (othercollision2D.gameObject.name == "bridge")
        {
            score += 10;
        }
        
    }
    void OnTriggerEnter2D(Collider2D othercollision2D)
    {
        if (othercollision2D.gameObject.name == "Suelo")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            gameObject.transform.position = new Vector2(0,-4);
            vidas--;
                        
        }
    }
    public void RestarVidas() 
    {
        vidas--;    
    }

    public void SumaScore(int scoreASumar) 
    {
        score += scoreASumar;
    }
    public IEnumerator LevelUp()
    {   
        contadorLevel++;
        gameObject.transform.position= new Vector2 (0,-4f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Over.Win();
        Debug.Log("pasan 3 segundos");
        yield return new WaitForSeconds(3f);

        Debug.Log("Han pasado 3 segundos");
        Over.Levelup();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        
    }

}
