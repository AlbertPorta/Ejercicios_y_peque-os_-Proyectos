using UnityEngine;
using System.Collections;

public class CuentaAtras : MonoBehaviour {

	public GameObject motorCarreteraGO;
	public MotorCarreteras motorCarreteraScript;
	public Sprite[] numeros;

	public GameObject contadorNumerosGO;
	public SpriteRenderer contadorNumerosComp;

	public GameObject controladorCocheGO;
	public GameObject cocheGO;


	// Use this for initialization
	void Start () 
	{
		InicioComponentes();
	}

	void InicioComponentes()
	{
		motorCarreteraGO = GameObject.Find("MotorCarreteras");
		motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras>();

		contadorNumerosGO = GameObject.Find("ContadorNumeros");
		contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

		cocheGO = GameObject.Find("Coche");
		controladorCocheGO = GameObject.Find("ControladorCoche");

		InicioCuentaAtras();

	}
	
	void InicioCuentaAtras()
	{
		StartCoroutine(Contando());
	}

	IEnumerator Contando()
	{
		controladorCocheGO.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds (2);

		contadorNumerosComp.sprite = numeros[1];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[2];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[3];
		motorCarreteraScript.inicioJuego = true;
		contadorNumerosGO.GetComponent<AudioSource>().Play();
		cocheGO.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2);

		contadorNumerosGO.SetActive(false);
	}
}
