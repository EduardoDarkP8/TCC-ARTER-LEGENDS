using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{

    public bool Talker;
    public string[] texto = new string[1];
    public int tamanho;
    int i;
    public Player pl;
    public Shot st;
    public bool Complete;
    public TextListener txt;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(wait());
		try 
        {
            txt = GetComponent<TextListener>();
        }
		catch  
        {
            txt = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (txt != null && Input.GetButtonDown("Interact")) 
        {
            txt.Procurar();
            txt.Passar();

        }

    }
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Interact" && Input.GetButtonDown("Interact")) 
        {
          
            pl.enabled = false;
            st.enabled = false;

            if (Talker && txt != null)
			{
             
                txt.Criar();
                txt.Procurar();
                
            }

        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Interact" && Input.GetButtonDown("Interact"))
        {

            pl.enabled = false;
            st.enabled = false;

            if (Talker && txt != null)
            {

                txt.Criar();
                txt.Procurar();

            }

        }
    }
    public IEnumerator wait() 
    {
        yield return new WaitForSeconds(0.8f);
        pl = GameObject.Find("Body").GetComponent<Player>();
        st = GameObject.Find("ShotPivo").GetComponent<Shot>();

    }

}
