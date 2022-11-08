using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public bool isPlayer;
    public double damage;
    public bool isShot;
    public double Knockack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.GetComponent<Vivo>() != null)
        {
            if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false) 
            {
                collision.gameObject.GetComponent<Vivo>().Vida -= damage;
				if (isShot)
                {
                    Destroy(gameObject);
                }
            }
            else if (collision.gameObject.GetComponent<Player>() == null && isPlayer == true)
            {
                collision.gameObject.GetComponent<Vivo>().Vida -= 1;
                if (isShot)
                {
                    Destroy(gameObject);
                }
            }
			
        }
	}
}
