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
    public TriggerMobs trigger;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            Inimigo = null;
            trigger = null;
            collider = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == false)
        {
            InimigoRecall();
        }
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
                collider.enabled = false;
                
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
    public IEnumerator CoolDown()
    {

        if (trigger.IsHere && collider.enabled == false)
        {
            yield return new WaitForSeconds(Inimigo.ataqueSpeed * 10);
            collider.enabled = true;
        }

    }
    void InimigoRecall() 
    {
        while (isPlayer == false && trigger.IsHere == true && trigger != null)
        {
            StartCoroutine(CoolDown());
        }
    }
}
