using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMultibola : MonoBehaviour
{
    public GameObject Bola;
    public GameObject BolaExtra;
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
            GameObject clon =Instantiate(BolaExtra, Bola.transform.position, Quaternion.identity)   ;
            
            clon.SetActive(true);
            gameObject.SetActive(false);
            

        }
    }
}
