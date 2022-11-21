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
		switch (PlayerPrefs.GetInt("selected"))
        {
        case 1:

       
        if (Input.GetButtonDown("Fire2") && shot == true)
        {
                    Quaternion normal = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, 0));
                    GameObject shot = Instantiate(shots[PlayerPrefs.GetInt("selected")], local.transform.position, normal) as GameObject;
                    StartCoroutine(contDown());
        }
        break;
        case 0:

        
        if (Input.GetButtonDown("Fire2") && shot == true)
        {
                    
        Quaternion lower = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, -15));
        Quaternion top = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, 15));
        Quaternion normal = Quaternion.Euler(local.eulerAngles + new Vector3(0, 0, 0));
        GameObject shot1 = Instantiate(shots[PlayerPrefs.GetInt("selected")], local.transform.position, normal) as GameObject;
        GameObject shot2 = Instantiate(shots[PlayerPrefs.GetInt("selected")], local.transform.position, lower) as GameObject;
        GameObject shot3 = Instantiate(shots[PlayerPrefs.GetInt("selected")], local.transform.position, top) as GameObject;

        StartCoroutine(contDown());
        }
        break;

        }
        


}
    private IEnumerator contDown() 
    {
        pl.status = PlayerAnimation.shot;
        shot = false;
        if (PlayerPrefs.GetInt("selected") == 0) 
        {
            yield return new WaitForSeconds(0.2f);
        }
        if (PlayerPrefs.GetInt("selected") == 1)
        {
            yield return new WaitForSeconds(0.2f);
        }
        shot = true;
        pl.status = PlayerAnimation.walk;
        yield return null;

    }
    
    
}
