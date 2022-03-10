using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float speed;
    int rotaAsteroide;
    int translacionAsteroide;
    float direccionX;
    float direccionY;
    UIManager UIManager;
    Player player;
    [SerializeField]
    GameObject danoPrefab;
    [SerializeField]
    AudioClip explosionClip;
    int danoAsteroid;
    SpriteRenderer sprite ;
    float alpha = 1;
    bool startAlpha;

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        danoAsteroid = 5;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        UIManager = GameObject.Find("UIManagerCanvas").GetComponent<UIManager>();
        speed = 1.5f;
        rotaAsteroide = Random.Range(-50,50);
        translacionAsteroide = Random.Range(-100, 100);
        direccionX = Random.Range(-1, 2);
        direccionY = Random.Range(Random.Range(-1,-0.5f),Random.Range(0.5f,1f));        
    }

    // Update is called once per frame
    void Update()
    {
        if (startAlpha)
        {
            alpha -= 0.7f * Time.deltaTime;
            sprite.color = new Color(1, 1, 1, Mathf.Lerp(0f, 1f, alpha));
        }
        
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Movimiento();
        }
        
        
        //transform.Translate(new Vector3.(direccionX,direccionY,0).,Space.World);
    }
    void Movimiento()
    {
        transform.Translate(new Vector3(direccionX,direccionY,0) * speed * Time.deltaTime);
        transform.GetChild(0).Rotate(Vector3.forward * translacionAsteroide * Time.deltaTime);


        if (transform.position.y > 7f)
        {
            transform.position = new Vector3(transform.position.x, -7f, 0);
        }

        if (transform.position.y < -7f)
        {
            //if (FindObjectOfType<Player>() != null)
            //{
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 7f, 0);
            //}
            //else
            //{
            //    Destroy(gameObject);
            //}
        }

        if (transform.position.x > 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }

        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            danoAsteroid--;
            Destroy(other.gameObject);
            
            if (danoAsteroid == 0)
            {
                StartCoroutine(DestruccionAsteroidRoutine());
                UIManager.ActualizarScore(50);
            }
            else 
            {
                StartCoroutine(AsteroiddanadoRoutine());
            }

        }
        if (other.gameObject.tag == "Player")
        {
            if (player.escudo == false)
            {
                ContactPoint2D puntoChoque = other.GetContact(0);
                GameObject clon = Instantiate(danoPrefab, puntoChoque.point, Quaternion.identity);
                clon.transform.parent = other.transform;
            }

            player.RestarVida();

            if (other.gameObject.GetComponent<Player>().vidas != 0)
            {
                StartCoroutine(DestruccionAsteroidRoutine());
            }
        }
        IEnumerator DestruccionAsteroidRoutine()
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            StopCoroutine(AsteroiddanadoRoutine());
            AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, 1f);
            startAlpha = true; ///////////////////////////////////////            
            yield return new WaitForSeconds(1.3f);
            ClearChildren();
            Destroy(this.gameObject);
                                          
        }
        IEnumerator AsteroiddanadoRoutine()
        {
            
            sprite.color = new Color(1, 0.5f, 0, 1);
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;

        }
        }
    public void ClearChildren()
    {
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];

        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        foreach (GameObject child in allChildren)
        {
            Destroy(child.gameObject);
        }
    }
}
