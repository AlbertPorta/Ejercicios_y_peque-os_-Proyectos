using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaGrande : MonoBehaviour
{
    public GameObject pala;
    // Start is called before the first frame update
   
    void OnTriggerEnter2D(Collider2D othercollision2D)
    {
        if (othercollision2D.gameObject.name == "Player")
        {                     
            StartCoroutine(Contando());
        }
    }
    IEnumerator Contando()
    {
        pala.transform.localScale += new Vector3(0.15f, 0,0);
        yield return new WaitForSeconds(5f);

        pala.transform.localScale -= new Vector3(0.15f, 0, 0);
        gameObject.SetActive(false);
    }
}