using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextListener : MonoBehaviour
{


    private string textoatual;
    public Text text;
    public int i = 0;
    public GameObject ob;
    public GameObject prephab;
    public Transform Local;
    public GameObject canva;
    GameObject caixa;
    public string id;
    public bool Existe;
    public Player pl;
    public Shot st;
    public string[] texto = new string[0];
	// Start is called before the first frame update

	private void Start()
	{
        pl = GameObject.Find("Body").GetComponent<Player>();
        st = GameObject.Find("ShotPivo").GetComponent<Shot>();  

	}

	public void Criar()
    {

        if (GameObject.Find("Text Box") == null && Existe == false)
        {

            GameObject caixa = Instantiate(prephab, Local.position, Quaternion.identity) as GameObject;
            caixa.name = "Text Box";
            caixa.transform.parent = canva.transform;
            textoatual = texto[i];

            Debug.Log(textoatual.ToString());
            ob = GameObject.Find("Text");
            i = 0;
            if (ob == null)
            {
                return;
            }
            else
            {
                text = ob.GetComponent<Text>();
                text.text = textoatual;
                Procurar();
                Debug.Log(texto.Length.ToString());
              
            }
            Existe = true;
        }
    }
    public void Passar()
    {
        if (GameObject.Find("Text Box") != null && Existe == true)
        {

            if (i < texto.Length -1)
            {
                i++;
                textoatual = texto[i];
            }
            else
            {
                Destroy(GameObject.Find("Text Box"));
                i = 0;
                Existe = false;
                pl.enabled = true;
                st.enabled = true;
            }

        }

    }
    public void Procurar()
    {

        ob = GameObject.Find("Text");
        if (ob == null)
        {
            return;
            Debug.Log("Achou não pai");
        }
        else
        {

            Debug.Log("Achou pai");
            text = ob.GetComponent<Text>();
            text.text = textoatual;
        }

    }

}



