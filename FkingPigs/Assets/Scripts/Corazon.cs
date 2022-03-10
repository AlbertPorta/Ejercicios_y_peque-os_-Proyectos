using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int valorCorazon;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        valorCorazon = 1;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 9 * speed * Time.deltaTime);
        //transform.position = new Vector2(transform.position.x,transform.position.y+ Mathf.PingPong(Time.time, -0.5f+0.5f));
        var dif = startPos.y -0.5f - startPos.y;
        var s = Mathf.Sign(dif);
        transform.position = new Vector2(transform.position.x, startPos.y + Mathf.PingPong(Time.time , dif * s) * s);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.CogerVida();
            Destroy(this.gameObject);
        }


    }
}
