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
    public Player pl;
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
            if(isShot)
			{
                pl = GameObject.Find("Body").GetComponent<Player>();
                damage = pl.sDamage[pl.selected];
                
			}
            else if (isShot == false)
            {
                damage = pl.aDamage[pl.selected];
            }
        }
        if(isPlayer == false)
		{
            pl = null;
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
                
                collision.gameObject.GetComponent<Player>().KnockBackhit(Inimigo.gameObject.GetComponent<Transform>().position);

                
                if (player.Vida != 0)
                {
                    player.Pv_C = player.Pv_C - damage;

                }
                if (isShot)
                {
                    damage = 0;
                    Destroy(gameObject);
                }
                Cooldown = true;
                collider.enabled = false;
                StartCoroutine(CoolDown());

            }
            else if (collision.gameObject.GetComponent<Player>() == null && isPlayer == true)
            {
                StartCoroutine(DamagerReduz(collision));
                if (collision.gameObject.GetComponent<Enimy>() != null) 
                {
                    collision.gameObject.GetComponent<Enimy>().KnockBackhit(pl.gameObject.GetComponent<Transform>().position); 
                    Debug.Log("AAAA");
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
    public IEnumerator DamagerReduz(Collider2D gm) 
    {
        gm.gameObject.GetComponent<Vivo>().Vida -= damage;
        damage = 0;
        yield return new WaitForSeconds(0.2f);

        if (isShot) { damage = pl.sDamage[pl.selected]; }
        if (isShot == false) { damage = pl.aDamage[pl.selected]; }

    }
}
