using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int valorMoneda;
    private bool gameIsPaused;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        speed = 250f;
        valorMoneda = 1;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPaused = gameManager.IsPaused();
        if (gameIsPaused == false)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        { 
            Player player = collision.gameObject.GetComponent<Player>();
            player.CogerMoneda(valorMoneda);
            Destroy(this.gameObject);
        }
       
        
    }
}
