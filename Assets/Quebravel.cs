using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quebravel : Vivo
{

    public Sprite[] sprs = new Sprite[0];
    SpriteRenderer spr;
    public bool OnlyObj;

    // Start is called before the first frame update
    void Start() 
    {
		if (gameObject.GetComponent<SpriteRenderer>() != null) 
        { 
        spr = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Mudar();
        DestroyTarget();
    }
    void Mudar() 
    {
        if (Vida > 0 && OnlyObj == false)
        {

        spr.sprite = sprs[Vida - 1];

        }
    }
}
