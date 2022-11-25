using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{

    public GameObject[] Alvos = new GameObject[0];
    public int vida;
    int i;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        vida = Alvos.Length;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        FindObjects();
    }
    void FindObjects() 
    {
        
        while (i < Alvos.Length) 
        {

            if (Alvos[i] == null)
            {
                vida--;
                Debug.Log(vida.ToString());
            }
            i++;
            if (vida <= 0 && start)
            {
                Destroy(gameObject);
            }
        }
        i = 0;
        vida = Alvos.Length;
    }


        
    
}
