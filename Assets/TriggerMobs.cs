using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMobs : MonoBehaviour
{
    public bool IsHere;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Body")
        {
            IsHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Body")
        {
            IsHere = false;
        }
    }

}
