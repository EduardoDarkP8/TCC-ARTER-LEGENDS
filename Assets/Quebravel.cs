using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quebravel : Vivo
{

    public Sprite[] sprs = new Sprite[0];
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start() 
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Mudar();
        DestroyTarget();
    }
    void Mudar() 
    {
        if (Vida > 0)
        {

        spr.sprite = sprs[Vida - 1];

        }
    }
}
