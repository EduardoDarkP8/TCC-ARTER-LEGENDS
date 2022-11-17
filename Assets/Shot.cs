using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Player pl;
    public GameObject[] shots = new GameObject[2];
    public Transform local;
    private bool shot = true;
    public bool colliding;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        shotDirect();
        
    }
    void shotDirect() 
    {
		switch (pl.selected)
        {
        case 1:

       
        if (Input.GetButtonDown("Fire2") && shot == true)
        {
                  
                    Instantiate(shots[pl.selected], local);
                    StartCoroutine(contDown());
        }
        break;
        case 0:

        
        if (Input.GetButtonDown("Fire2") && shot == true)
        {
                    
                    Quaternion lower = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, -15));
        Quaternion top = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, 15));
        Instantiate(shots[pl.selected], local);
        Instantiate(shots[pl.selected], local.transform.position, lower);
        Instantiate(shots[pl.selected], local.transform.position, top);
        StartCoroutine(contDown());
        }
        break;

        }
        


}
    private IEnumerator contDown() 
    {
        pl.status = PlayerAnimation.shot;
        shot = false;
        if (pl.selected == 0) 
        {
            yield return new WaitForSeconds(0.2f);
        }
        if (pl.selected == 1)
        {
            yield return new WaitForSeconds(5.4f);
        }
        shot = true;
        pl.status = PlayerAnimation.walk;
        yield return null;

    }
    
    
}
