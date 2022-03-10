using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{       
    float horizontalInput;
    float verticalInput;
    SpriteRenderer spriteRenderer;
    private bool gameIsPaused;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {                       
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPaused = gameManager.IsPaused();
        if (gameIsPaused == false)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        
    }
}
