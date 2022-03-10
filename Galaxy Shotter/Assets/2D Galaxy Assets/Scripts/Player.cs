using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool hiperVelocidad;
    public bool disparoTriple;
    public bool escudo;

    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    UIManager UIManager ;
    [SerializeField]
    private Image vidasUI;
    [SerializeField]
    GameObject laserPrefab;
    [SerializeField]
    GameObject escudoGO;
    [SerializeField]
    GameObject pistolaPrincipal;
    [SerializeField]
    GameObject pistolaIzq;
    [SerializeField]
    GameObject pistolaDer;
    [SerializeField]
    public int vidas;
    [SerializeField]
    float speed;
    float tiempoDisparo;
    float disparoUltimo;
    void Start()
    {
        pistolaPrincipal = transform.GetChild(2).gameObject;
        pistolaIzq = transform.GetChild(3).gameObject;
        pistolaDer = transform.GetChild(4).gameObject;
        escudoGO = transform.GetChild(0).gameObject;
        vidas =3;
        transform.position = Vector3.zero;
        speed = 5.0f;
        tiempoDisparo = 0.25f;
        disparoUltimo = Time.time;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        UIManager = GameObject.Find("UIManagerCanvas").GetComponent<UIManager>();
        UIManager.ActualizarVidas(vidas);
        vidasUI = UIManager.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (vidas > 0)
        {
            Movimiento();
            Disparo();
        }               
    }
    void Disparo() 
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time - disparoUltimo > tiempoDisparo)
            {
                if (disparoTriple == true)
                {
                    Instantiate(laserPrefab, pistolaPrincipal.transform.position, transform.rotation);
                    Instantiate(laserPrefab, pistolaIzq.transform.position, transform.rotation);
                    Instantiate(laserPrefab, pistolaDer.transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(laserPrefab, pistolaPrincipal.transform.position, transform.rotation);
                }
                
                disparoUltimo = Time.time;

            }
            
        }
        
    }
    void Movimiento() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward * Input.GetAxisRaw("Mouse X") * 10* Time.deltaTime);
        if (hiperVelocidad)
        {
            transform.Translate(Vector3.right * speed * 2f * Time.deltaTime * horizontalInput);
            transform.Translate(Vector3.up * speed * 2f * Time.deltaTime * verticalInput);
            
        }
        else
        {        
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
            transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
        }

        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x,4.2f, 0);
        }

        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }

        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
    }
    public void DisparoTripleOn()
    {
        disparoTriple = true;
        StopCoroutine("DisparoTripleOffRutina");
        StartCoroutine("DisparoTripleOffRutina");
    }

    public IEnumerator DisparoTripleOffRutina() 
    {
        yield return new WaitForSeconds(5.0f);
        disparoTriple = false;
    }
    public void HyperVelocidadOn()
    {
        hiperVelocidad = true;
        StopCoroutine("HiperVelocidadOffRutina");
        StartCoroutine("HiperVelocidadOffRutina");
    }
    public IEnumerator HiperVelocidadOffRutina() 
    {
        yield return new WaitForSeconds(5.0f);
        hiperVelocidad = false;
    }
    public void RestarVida()
    {
        if (escudo == true)
        {
            
            StartCoroutine(TimeLifeRoutine());            
            escudoGO.SetActive(false);
            StopCoroutine("EscudoOffRutina");    
            return;
        }
        //////////////////////////compruevo que no pueda salir del array de sprites
        if (vidas < 0)
        {
            vidas = 0;
        }
        else
        {
            vidas --;
        }
        /////////////////////////

        UIManager.ActualizarVidas(vidas);

        if (vidas == 0)
        {
            StartCoroutine(DestruccionPlayerRoutine());
        }
        else
        {
            StartCoroutine(TimeLifeRoutine());
            
        }
    }
    public IEnumerator TimeLifeRoutine() 
    {
        escudo = true;
        for (int i = 0; i < 3; i++)
        {
            vidasUI.color = new Color(0, 1, 1, 1);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            vidasUI.color = Color.white;
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
        escudo = false;

    }
    IEnumerator DestruccionPlayerRoutine()
    {
        ClearChildren();
        GetComponent<PolygonCollider2D>().enabled = false;
        AudioSource.PlayClipAtPoint(audioClip,Camera.main.transform.position,0.5f);
        GetComponent<Animator>().SetTrigger("Explosion");
        Debug.Log("Adios player");
        yield return new WaitForSeconds(3f);
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

        public void AdiosPlayer()
    {
        
        GameManager.GameOver();
        Destroy(this.gameObject);
    }
    public void EscudoOn()
    {
        vidasUI.color= new Color(0,1,1,1);
        escudoGO.SetActive(true);
        escudoGO.GetComponent<SpriteRenderer>().enabled = true;
        escudo = true;
        StopCoroutine("EscudoOffRutina");
        StartCoroutine("EscudoOffRutina");


    }
    IEnumerator EscudoOffRutina()
    {
        yield return new WaitForSeconds(9f);
        for (int i = 0; i < 2; i++)
        {
            escudoGO.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            escudoGO.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 4; i++)
        {
            vidasUI.color =  new Color(0, 1, 1, 1);
            escudoGO.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.15f);
            vidasUI.color = Color.white;
            escudoGO.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.15f);
        }

        escudoGO.SetActive(false);
        escudo = false;
        
    }
}
