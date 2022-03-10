using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    UIManager UIManager;
    [SerializeField]
    SpawnManager SpawnManager;

    public bool gameOver = true;

    private void Start()
    {
        UIManager = GameObject.Find("UIManagerCanvas").GetComponent<UIManager>();
        SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    public void Update()
    {

        if (gameOver == true && GameObject.FindGameObjectWithTag("Malote") == null)
        {
            UIManager.ActivatePressSpace(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
                gameOver = false;
                SpawnManager.ResetLevel();
                SpawnManager.RestartCoroutines();
                UIManager.EscondePantallaTitulo();
            }
        }
    }
    public void GameOver()
    {
        gameOver = true;
        UIManager.ResetScore();
        UIManager.SacaPantallaTitulo();
    }
}
