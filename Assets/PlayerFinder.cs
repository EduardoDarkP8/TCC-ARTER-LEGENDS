using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    public Enimy inimigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body")
        {
            inimigo.Find();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Body" && Vector2.Distance(inimigo.Target.transform.position, transform.position) > 2f)
        {
            inimigo.Target = null;
            inimigo.anima.SetBool("Andando", false); 
        }
        else
        {
            return;
        }
    }
}
