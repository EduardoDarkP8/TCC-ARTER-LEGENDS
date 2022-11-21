using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vivo : MonoBehaviour
{
    public int Vida;
    public int Pv_C;
    public int PvMax;
    // Start is called before the first frame update
    void Start()
    {
        PvMax = Vida;
    }

    // Update is called once per frame
    void Update()
    {
        Morrer();
    }
    void Morrer() 
    {
        if (Vida <= 0) 
        {
            GameObject ob = GameObject.Find("Hud") as GameObject;
            ob.transform.Find("Menu").gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
