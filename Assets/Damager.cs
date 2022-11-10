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
    public bool Cooldown;
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
                Cooldown = true;
            }
            else if (collision.gameObject.GetComponent<Player>() == null && isPlayer == true)
            {
                collision.gameObject.GetComponent<Vivo>().Vida -= 1;
     
   
                if (isShot)
                {
                    Destroy(gameObject);
                }
            }
            else if(collision.gameObject.GetComponent<Player>() == null && isPlayer == false)
            {
                return;
            }
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Body" && isPlayer == false) 
        {
            StartCoroutine(CoolDown(other, Inimigo.ataqueSpeed * 10, damage));
        }
        else
        {
            return;
        }
    }
    public IEnumerator CoolDown(Collider2D collision, float Time, int dano)
    {

        if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false && Cooldown == false)
        {
            if (player.Vida != 0)
            {
                if (Cooldown == false)
                {
                    player.Pv_C = player.Pv_C - dano;
                    Cooldown = true;
                    yield return new WaitForSeconds(Time);
                    Cooldown = false;
                }
            }
            if (isShot)
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<Player>() == null && isPlayer == false)
            {
                yield return null;
            }

        }
    } 



}
