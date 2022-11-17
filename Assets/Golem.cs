using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enimy
{
    public float Velo;
    public float ataSpd;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        Velocity = Velo;
        Target = null;
        GerarVida();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        PivoAngle();
        Morrer();
        rgbd.velocity = Vector2.zero;
    }
}
