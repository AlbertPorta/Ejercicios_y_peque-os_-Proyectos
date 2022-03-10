using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    private Ray rayo;
    private RaycastHit hit;
    private Camera miCamara;
    private Vector2 centroCamara;
    public float distanciaDisparo;

    public GameObject[] decalsPrefabs; //Array de los prefabs
    public GameObject[] createdDecals; //Array para crear los Decals
    public int decalIndex;

    public float tiempodisparo;
    private float disparoUltimo;
    private Quaternion rotDecal;
    private Vector3 posDecal;
    public LayerMask decalLayerMask;
    

    // Start is called before the first frame update
    void Start()
    {
   
        this.miCamara = gameObject.transform.GetChild(0).GetComponent<Camera>();
        this.centroCamara.x= Screen.width/2;
        this.centroCamara.y= Screen.height/2;
        disparoUltimo = Time.time;

        for (int decalNum = 0; decalNum < this.createdDecals.Length; decalNum++)
        {
            this.createdDecals[decalNum] = GameObject.Instantiate(this.decalsPrefabs[decalIndex], Vector3.zero, Quaternion.identity) as GameObject;
            this.createdDecals[decalNum].GetComponent<Renderer>().enabled = false;
            decalIndex++;
            if (decalIndex > 2)
            {
                decalIndex = 0;
            }
        }
        this.decalIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - disparoUltimo > tiempodisparo)
            {
                this.rayo = this.miCamara.ScreenPointToRay(this.centroCamara);
                disparoUltimo = Time.time;
               
                if (Physics.Raycast(this.rayo, out this.hit, this.distanciaDisparo,decalLayerMask))
                {
                    rotDecal = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                    posDecal = hit.point + hit.normal * 0.01f;
                    this.createdDecals[this.decalIndex].transform.parent = null;
                    this.createdDecals[this.decalIndex].transform.position = this.posDecal;
                    this.createdDecals[this.decalIndex].transform.rotation = this.rotDecal;
                    this.createdDecals[this.decalIndex].GetComponent<Renderer>().enabled = true;
                    if (this.hit.collider.tag =="Puerta")
                    {
                        this.createdDecals[this.decalIndex].transform.parent = this.hit.collider.gameObject.transform;
                    }
                    this.decalIndex++;
                    if (this.decalIndex > 9)
                    {
                        this.decalIndex = 0;
                    }
                }
            }
        }
    }
}
