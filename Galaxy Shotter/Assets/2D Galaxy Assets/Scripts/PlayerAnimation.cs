using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("TurnLeft", true);
            GetComponent<Animator>().SetBool("TurnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("TurnLeft", false);
            GetComponent<Animator>().SetBool("TurnRight", false);
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("TurnRight", true);
            GetComponent<Animator>().SetBool("TurnLeft", false);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("TurnRight", false);
            GetComponent<Animator>().SetBool("TurnLeft", false);
        }
        

    }
}
