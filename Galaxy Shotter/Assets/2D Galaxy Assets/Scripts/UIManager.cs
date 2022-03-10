using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image vidasUI;
    [SerializeField]
    private Text scoreUI;
    private int score;
    [SerializeField]
    private Sprite[] vidasSprite;
    [SerializeField]
    private Material[] estrellasMaterial;
    [SerializeField]
    private GameObject pantallaTitulo;
    private GameObject pressSpace;
    // Start is called before the first frame update
    void Start()
    {
        pressSpace = pantallaTitulo.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActualizarVidas(int cantidadVidas) 
    {
        vidasUI.sprite = vidasSprite[cantidadVidas];
    
    }
    public void ActualizarScore()
    {
        score += 10;
        scoreUI.text = "Score:" + score;
    }
    public void ActualizarScore(int PuntuacionASumar)
    {
        score += PuntuacionASumar;

        scoreUI.text = "Score:" + score;
    }
    public void SacaPantallaTitulo()
    {
        MeshRenderer galaxy = GameObject.Find("Galaxy").GetComponent<MeshRenderer>();
        galaxy.material= estrellasMaterial[0];
        pantallaTitulo.SetActive(true);
        ActivatePressSpace(false);
        scoreUI.enabled = false;
        vidasUI.enabled = false;
    }
    public void EscondePantallaTitulo()
    {
        MeshRenderer galaxy = GameObject.Find("Galaxy").GetComponent<MeshRenderer>();
        galaxy.material = estrellasMaterial[1];
        pantallaTitulo.SetActive(false);
        scoreUI.enabled = true;
        vidasUI.enabled = true; 
    }
    public void ResetScore()
    {
        score = 0;
        scoreUI.text = "Score:" + score;
    }
    public void ActivatePressSpace(bool set ) 
    {
        pressSpace.SetActive(set);
    }
}
