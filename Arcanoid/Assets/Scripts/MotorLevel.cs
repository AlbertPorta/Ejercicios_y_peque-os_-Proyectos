using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorLevel : MonoBehaviour
{
    public GameObject level_2;
    public GameObject level_2_1;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_2.transform.position.x < -7.5f)
        {
            level_2.transform.position += new Vector3(15f,0f,0f);
        }
        if (level_2_1.transform.position.x < -7.5f)
        {
            level_2_1.transform.position += new Vector3(15f, 0f, 0f);
        }
        gameObject.transform.Translate(Vector3.left*velocidad*Time.deltaTime);
    }
}
