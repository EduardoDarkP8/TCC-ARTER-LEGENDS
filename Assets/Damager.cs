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
    public Collider2D collider;
    public int AtaqueSpeedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            Inimigo = null;
            collider = null;
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
            if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false && collider.enabled == true)
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
                collider.enabled = false;
                StartCoroutine(CoolDown());

            }
            else if (collision.gameObject.GetComponent<Player>() == null && isPlayer == true)
            {
                collision.gameObject.GetComponent<Vivo>().Vida -= 1;
                if (collision.gameObject.GetComponent<Enimy>() != null) 
                {
                    collision.gameObject.GetComponent<Enimy>().KnockBackhit();
                }
                else if (collision.gameObject.GetComponent<Enimy>() == null) 
                {
                    return;
                }
   
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
    public IEnumerator CoolDown()
    {
            yield return new WaitForSeconds(Inimigo.ataqueSpeed * AtaqueSpeedMultiplier);
            collider.enabled = true;
    }
    void InimigoRecall() 
    {
        StartCoroutine(CoolDown());
    }
}
