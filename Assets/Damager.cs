using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public bool isPlayer;
    public int damage;
    public bool isShot;
    public float Knockack;
    public Vivo player;
    public Enimy Inimigo;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            Inimigo = null;
        }
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
                if (player.Vida != 0)
                {
                    player.Pv_C = player.Pv_C - damage;
                }
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
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Vivo>() != null)
        {
            if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false)
            {
                StartCoroutine(CoolDown(Inimigo.ataqueSpeed));
            }

        }
    }
    public IEnumerator CoolDown(float tempo)
    {
        
            if (player.Vida != 0)
            {
                player.Pv_C = player.Pv_C - damage;
            }
            if (isShot)
            {
                Destroy(gameObject);
            }
        
        yield return new WaitForSeconds(tempo);
        
    }
}
