using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
	public Rigidbody2D rgbd;
	public GameObject pivo;
	public GameObject Target;
	public float Velocity;
	public float ataqueSpeed;
	public bool AtaqueTime;
	public Animator anima;
	public int Life;
	public bool KnockBack;
	public Vivo vida;
	public Vector3 Direct;
	void Start() 
	{
		
	}
	public void Follow()
	{
		if (Target != null && AtaqueTime == false)
		{
			rgbd.MovePosition(Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Velocity));
		}
		else 
		{
			rgbd.MovePosition(Vector2.MoveTowards(transform.position, transform.position, Time.deltaTime * Velocity));
		}
	}	
	public void Find() 
	{
		Target = GameObject.Find("Body");	
	}
	public void Ataque() 
	{
		StartCoroutine(AtaqueTimer(ataqueSpeed));
	}
	public void PivoAngle() 
	{
		if (Target != null && AtaqueTime == false) 
		{
			Direct = Target.transform.position - transform.position;
			float angle = Mathf.Atan2(Direct.y, Direct.x) * Mathf.Rad2Deg;
			pivo.transform.eulerAngles = new Vector3(0, 0, angle);
			anima.SetFloat("Y",Direct.y);
			anima.SetFloat("X", Direct.x);
		}
	}
	public IEnumerator AtaqueTimer(float tempo)
	{
		AtaqueTime = true;
		anima.SetBool("Ataque",true);

		yield return new WaitForSeconds(tempo);
		AtaqueTime = false;
		anima.SetBool("Ataque", false);
    }
    public void Morrer()
    {
		if (vida.Vida <= 0)
        {
            Destroy(gameObject);

        }
    }
	public void GerarVida() 
	{
		vida.Vida = Life;
	}
}