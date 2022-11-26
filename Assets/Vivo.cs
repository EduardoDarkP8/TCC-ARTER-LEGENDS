using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vivo : MonoBehaviour
{
    public int Vida;
    public int Pv_C;
    public int PvMax;
    public bool isPlayer;
    public bool isTarget;
    // Start is called before the first frame update
    void Start()
    {
        PvMax = Vida;
    }

    // Update is called once per frame
    void Update()
    {
        Morrer();
        DestroyTarget();
    }
    void Morrer() 
    {
        if (Vida <= 0 && isPlayer) 
        {
            GameObject ob = GameObject.Find("Hud") as GameObject;
            ob.transform.Find("Menu").gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void DestroyTarget() 
    {
        if (Vida <= 0 && isTarget)
        {
            Destroy(gameObject);
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (isTarget && collision.gameObject.GetComponent<Shurikens>() != null) 
        {
            Vida -= 1;
        }
        if (isTarget && collision.gameObject.GetComponent<Flecha>() != null)
        {
            Vida -= 1;
        }
    }

}
