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
    public bool isHere;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            Inimigo = null;
            if(isShot)
			{
                pl = GameObject.Find("Body").GetComponent<Player>();
                damage = pl.sDamage[PlayerPrefs.GetInt("selected")];

                
			}
            else if (isShot == false)
            {
                damage = pl.aDamage[PlayerPrefs.GetInt("selected")];
            }
        }

		
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == false && player == null)
        {
            pl = null;
            player = GameObject.Find("Body").GetComponent<Vivo>();
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Vivo>() != null)
        {
            if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false && collider.enabled == true)
            {
                isHere = true;
                collision.gameObject.GetComponent<Player>().KnockBackhit(transform);

                
                if (player.Vida != 0)
                {
                    StartCoroutine(DamagerConfirm(Inimigo.ataqueSpeed));

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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false && collider.enabled == true)
        {

            isHere = false;
        
        }
		else 
        {
            return;
        }
    }
	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.GetComponent<Player>() != null && isPlayer == false && collider.enabled == true)
        {

            isHere = true;

        }
        else
        {
            return;
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
 
        if (isShot == false) { yield return new WaitForSeconds(pl.aSpeed[PlayerPrefs.GetInt("selected")] ); }
        if (gm.gameObject.GetComponent<Enimy>() != null)
        {
            gm.gameObject.GetComponent<Enimy>().KnockBackhit(transform);

        }
        else if (gm.gameObject.GetComponent<Enimy>() == null)
        {
            yield return null;
        }
        gm.gameObject.GetComponent<Vivo>().Vida -= damage;
        damage = 0;
        yield return new WaitForSeconds(0.2f);

        if (isShot) { damage = pl.sDamage[PlayerPrefs.GetInt("selected")]; }
        if (isShot == false) { damage = pl.aDamage[PlayerPrefs.GetInt("selected")]; }

    }
    public IEnumerator DamagerConfirm(float time) 
    {
        yield return new WaitForSeconds(time);
        if (isHere) 
        {
            player.Pv_C = player.Pv_C - damage;
        }
    }
}
