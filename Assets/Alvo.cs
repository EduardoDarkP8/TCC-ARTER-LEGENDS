using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{

    public GameObject[] Alvos = new GameObject[0];
    public int vida;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindObjects() 
    {
        
        while (i < Alvos.Length) 
        {
            if (Alvos[i] != null) 
            {
                vida++;     
            }
            else if (Alvos[i] == null)
            {
                vida--;
            }
            i++;
        }
        StartCoroutine(countDown());
    }
    IEnumerator countDown() 
    {
        yield return new WaitForSeconds(0.2f);
        if (vida == 0) 
        {
            Destroy(gameObject);
        }
    }
}
