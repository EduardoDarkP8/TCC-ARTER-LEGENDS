using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apear : MonoBehaviour
{

    public Teleport tp;

    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (gm == null) 
        {
            tp.enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            gameObject.GetComponent<BoxCollider2D>().size = new Vector3(20,20);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;


        }
    }
}
