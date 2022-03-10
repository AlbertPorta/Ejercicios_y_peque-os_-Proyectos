using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Over : MonoBehaviour
{
    public static GameObject level1GOstatic; public static GameObject level2GOstatic;
    public  GameObject level1GO; public  GameObject level2GO;
    public GameObject winImage;
    public GameObject gameOverImage;
    public GameObject vidas;
    public GameObject score;
    public Text vidaText;
    public Text ScoreText;
    public Text ScoreTotalText;
    public GameObject ScoreTotal;

    public static GameObject gameOverStatic;
    public static GameObject vidasStatic;
    public static GameObject scoreStatic;
    public static GameObject winStatic;

    // Start is called before the first frame update
    void Start()
    {
        Over.level1GOstatic = level1GO;
        Over.level2GOstatic = level2GO;
        Over.gameOverStatic = gameOverImage;
        Over.gameOverStatic.gameObject.SetActive(false);

        Over.vidasStatic = vidas;
        Over.vidasStatic.gameObject.SetActive(true);

        Over.scoreStatic = score;
        Over.scoreStatic.gameObject.SetActive(true);

        Over.winStatic = winImage;
        Over.winStatic.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        vidaText = vidas.GetComponent<Text>();
        vidaText.text = "Vidas:" + MovimientoBola.vidasStatic;
        ScoreText = score.GetComponent<Text>();
        ScoreText.text = "Score:" + MovimientoBola.scoreStatic;
        ScoreTotalText = ScoreTotal.GetComponent<Text>();
        ScoreTotalText.text = MovimientoBola.scoreStatic.ToString();
    }

    public static void GameOver()
    {
        Over.gameOverStatic.gameObject.SetActive(true);
        Over.vidasStatic.gameObject.SetActive(false);
        Over.scoreStatic.gameObject.SetActive(false);


    }
    public static void Win()
    {
        Over.winStatic.gameObject.SetActive(true);
        Over.vidasStatic.gameObject.SetActive(false);
        Over.scoreStatic.gameObject.SetActive(false);
        Over.level1GOstatic.gameObject.SetActive(false);
        
    }
    public static void Levelup()
    {
        Over.winStatic.gameObject.SetActive(false);
        Over.vidasStatic.gameObject.SetActive(true);
        Over.scoreStatic.gameObject.SetActive(true);
        Over.level2GOstatic.gameObject.SetActive(true);
    }


}
