using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbrick : MonoBehaviour
{
    public GameObject laserGO;
    public GameObject pala;
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
            StartCoroutine(LaserSpawner());
        }
    }
    public IEnumerator LaserSpawner() 
    {
        Instantiate(laserGO, pala.transform.position + Vector3.up / 2, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(laserGO, pala.transform.position + Vector3.up / 2, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(laserGO, pala.transform.position + Vector3.up / 2, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(laserGO, pala.transform.position + Vector3.up / 2, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(laserGO, pala.transform.position + Vector3.up / 2, Quaternion.identity);
        gameObject.SetActive(false);

    }
}
