using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadrilloDestroy : MonoBehaviour
{
    public List<GameObject> Bonus;
    public List<Rigidbody2D> BonusRb;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (MovimientoBola.scoreStatic % 5==0 && Bonus!= null )
        {
            int i = Random.Range(0, 6);
            Bonus[i].gameObject.SetActive(true);
            Bonus[i].transform.position = this.transform.position;
            BonusRb[i].velocity = Vector2.zero;
        }
        Destroy(gameObject);
    }
}
