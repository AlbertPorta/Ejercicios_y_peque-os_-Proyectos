using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject malotePrefab;
    [SerializeField]
    private GameObject[] bonusPrefab;
    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    private GameObject asteroidPrefab;

    private float tiempoIncrementoMalotes;
    private float tiempoStart;
    private float Level;

    void Start()
    {
        tiempoIncrementoMalotes = 10f;
        tiempoStart = Time.time;
        Level = 1f;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnMalote());
        StartCoroutine(SpawnBonus());
        StartCoroutine(SpawnAsteroid());
    }

    void Update()
    {
        if (Time.time - tiempoStart > tiempoIncrementoMalotes)
        {
            Level++;
            tiempoStart = Time.time;
        }
    }
    IEnumerator SpawnMalote()
    {
        while (GameManager.gameOver == false)
        {
            Instantiate(malotePrefab, new Vector3(Random.Range(-8f, 9f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10/Level);
        }

    }
    IEnumerator SpawnAsteroid()
    {
        while (GameManager.gameOver == false)
        {
            Instantiate(asteroidPrefab, new Vector3(Random.Range(-8f, 9f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10 / Level);
        }
    }
    IEnumerator SpawnBonus()
    {
        while (GameManager.gameOver == false)
        {
            int randomBonus = Random.Range(0, 3);
            
            Instantiate(bonusPrefab[randomBonus], new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }
    public void RestartCoroutines()
    {
        StartCoroutine(SpawnMalote());
        StartCoroutine(SpawnBonus());
        StartCoroutine(SpawnAsteroid());
    }
    public void ResetLevel()
    {
        tiempoStart = Time.time;
        Level = 1f;
    }
}
