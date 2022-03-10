using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaGrande : MonoBehaviour
{
    public GameObject bola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D othercollision2D)
    {
        if (othercollision2D.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            bola.transform.localScale = new Vector2(0.8f,0.8f);

        }
    }
}
