using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    public GameObject VidaP;
    public Transform Bar;
    public Vivo vida;
    public Vector3 distancia;
    public Vector3 local;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        Criar(vida.Vida);
    }

    // Update is called once per frame
    void Update()
    {
        PlusLife();
    }
    public void PlusLife()
    {
        if (vida.Pv_C < 0)
        {
            vida.Pv_C++;
            i--;
            vida.Vida--;
            Destroy(GameObject.Find("Vida " + i.ToString()));

            local = local - new Vector3(32, 0, 0);
            if (i == 0) 
            {
                Destroy(GameObject.Find("Vida " + i.ToString()));
                vida.Vida = 0;
                vida.Pv_C = 0;
            }
        }
        if (vida.Pv_C > 0)
        {
            if (i >= vida.PvMax-1) 
            {
                vida.Vida = vida.PvMax;
                vida.Pv_C = 0;
            }
            else 
            {

                GameObject ob = Instantiate(VidaP, local, Quaternion.identity) as GameObject;
                ob.name = "Vida " + i.ToString();
                local = local + new Vector3(32, 0, 0);
                ob.transform.parent = gameObject.transform;
                vida.Pv_C--;
                i++;
                vida.Vida++;
            }
        }



    }
    public void Criar(int VidaCriar) { 

        local = Bar.position;
        while (i<VidaCriar)
        {
            
            
            GameObject ob = Instantiate(VidaP, local, Quaternion.identity) as GameObject;
            ob.name = "Vida " + i.ToString();
            local = local + new Vector3(32,0,0);
            ob.transform.parent = gameObject.transform;
            i++;
        }
       
    }
}
