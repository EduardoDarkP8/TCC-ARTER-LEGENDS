using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnimy : MonoBehaviour
{
    public Enimy inimigo;
    public bool Cooldown;
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
		if (collision.name == "Body") 
        {
            inimigo.Ataque();
            Cooldown = true;
        }
	}
    void OnTriggerStay2D(Collider2D other)
    {
        StartCoroutine(CoolDown(other, inimigo.ataqueSpeed * 20));
    }
    public IEnumerator CoolDown(Collider2D collision, float Time)
    {
        if (Cooldown == false)
        {
            if (collision.gameObject.GetComponent<Player>() != null && Cooldown == false)
            {
                inimigo.Ataque();
                Cooldown = true;
            }
            yield return new WaitForSeconds(Time);
            Cooldown = false;
        }
        else
        {
            yield return new WaitForSeconds(0);
        }

    }
}
