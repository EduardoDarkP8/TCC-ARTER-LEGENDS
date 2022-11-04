using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raizes : Enimy
{
    public float Velo;
    public float ataSpd;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        Velocity = Velo;
        Target = null;
        GerarVida();
        Morrer();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        PivoAngle();
        rgbd.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Body") 
        {
            Find();
        }
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.name == "Body" && Vector2.Distance(Target.transform.position,transform.position) > 10f)
        {
            Target = null;
        }
		else 
        {
            return;
        }
    }
    
}
