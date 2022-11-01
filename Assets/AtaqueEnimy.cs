using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnimy : MonoBehaviour
{
    public Enimy inimigo;
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
            Debug.Log("Ataque");
            inimigo.Ataque();
        }
	}
}
