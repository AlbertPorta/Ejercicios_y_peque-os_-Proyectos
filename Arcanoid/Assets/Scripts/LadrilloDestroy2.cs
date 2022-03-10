using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadrilloDestroy2 : MonoBehaviour
{
    public List<GameObject> Bonus;
    public List<Rigidbody2D> BonusRb;
    int golpe;
    public Sprite amarillo;
    SpriteRenderer Ladrillo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        golpe++;
        if (MovimientoBola.scoreStatic % 5 == 0 && Bonus != null)
        {
            int i = Random.Range(0, 6);
            Bonus[i].gameObject.SetActive(true);
            Bonus[i].transform.position = this.transform.position;
            BonusRb[i].velocity = Vector2.zero;           
        }
        if (golpe==2)
        {
            Destroy(gameObject);
        }
        else
        {
            Ladrillo = gameObject.GetComponent<SpriteRenderer>();
            Ladrillo.sprite = amarillo;
        }
        
    }
}
