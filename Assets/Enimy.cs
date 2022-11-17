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
	public bool Stuned;
	public bool Stunel;
	public float Weight;
	float angle;
	void Start() 
	{
		
	}
	void Update() 
	{
		if(Stunel == false)
        {

			Stuned = false;

        }
	}
	public void Follow()
	{
		if (Target != null && AtaqueTime == false && Stuned == false)
		{
			rgbd.MovePosition(Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Velocity));
		}
		else if(Stuned == false)
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
			Direct = Direct.normalized;
			angle = Mathf.Atan2(Direct.y, Direct.x) * Mathf.Rad2Deg;
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
	public void KnockBackhit(Transform reference) 
	{

		Stuned = true;
		Vector3 Local = (transform.position + reference.forward);
		rgbd.MovePosition(Vector2.MoveTowards(transform.position, Local, Time.deltaTime * Weight));
		StartCoroutine(Returnar());
	}
	private IEnumerator Returnar() 
	{
		yield return new WaitForSeconds(0.5f);
		Stuned = false;

	}

}