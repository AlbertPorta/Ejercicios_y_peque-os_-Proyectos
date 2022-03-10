using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    private int bonusID;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2,4);
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 0.5f);
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (bonusID==0)
                {
                    player.DisparoTripleOn();
                }
                else if (bonusID == 1)
                {
                    player.HyperVelocidadOn();
                }
                else if (bonusID == 2)
                {
                    player.EscudoOn();
                }
            }
            Destroy(gameObject);
        }
    }
    private void Movimiento()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
