using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioSource sr;
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
		if (sr.clip == Music1 && collision.gameObject.name == "Body") 
        {
            sr.clip = Music2;
            sr.Play();
            Destroy(gameObject);
            Debug.Log("2");
        }
        else if (sr.clip == Music2 && collision.gameObject.name == "Body") 
        {
            sr.clip = Music1;
            sr.Play();
            Destroy(gameObject);
            Debug.Log("1");
        }
	}
}
