using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject player;
    public string Local;
    public int Cena;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Local") == Local) 
        {
            GameObject gm = Instantiate(player) as GameObject;
            gm.transform.position = transform.position;
            gm.name = "Body";
            
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.GetComponent<Player>() != null) 
        {
            PlayerPrefs.SetString("Local", Local);
            PlayerPrefs.SetInt("Cena", Cena);
            collision.gameObject.GetComponent<Vivo>().Pv_C = collision.gameObject.GetComponent<Vivo>().PvMax;
        }
	}


}
