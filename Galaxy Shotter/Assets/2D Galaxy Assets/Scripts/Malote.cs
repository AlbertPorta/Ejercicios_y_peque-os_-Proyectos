using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malote : MonoBehaviour
{   

    public float speed;
    [SerializeField]
    Player player;
    [SerializeField]
    private UIManager UIManager;
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    GameObject danoPrefab;

    float direccionXMalote;
    float direccionYMalote;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        UIManager = GameObject.Find("UIManagerCanvas").GetComponent<UIManager>();
        speed = 5f;
        direccionXMalote = Random.Range(-1f, 1f);
        direccionYMalote = Random.Range(-1f, -0.5f);
        angle = Random.Range(-85, 86);
        transform.Rotate(angle*Vector3.forward);
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

    }
    void Movimiento()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        

        if (transform.position.y > 7f)
        {
            transform.position = new Vector3(transform.position.x, -7f, 0);
        }

        if (transform.position.y < -7f)
        {
            if (FindObjectOfType<Player>()!= null)
            {
                transform.position = new Vector3(Random.Range(-10f, 10f), 7f, 0);
            }
            else
            {
                Destroy(gameObject);
            }
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
            Destroy(other.gameObject);
            UIManager.ActualizarScore();
            StartCoroutine(DestruccionMaloteRoutine());

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
                StartCoroutine(DestruccionMaloteRoutine());
            }
        }
        IEnumerator DestruccionMaloteRoutine() 
        {
            ClearChildren();
            GetComponent<PolygonCollider2D>().enabled = false;
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 0.5f);
            GetComponent<Animator>().SetBool("Explosion", true);
            yield return new WaitForSeconds(1.5f);

            Destroy(this.gameObject);

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
   
