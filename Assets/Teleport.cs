using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport : MonoBehaviour
{
    public Transform tr;
    public int Cena;
    public bool OtherScene;
    public string Local;
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
        if (collision.gameObject.GetComponent<Player>() != null)
        {
			if (OtherScene) 
            {
                PlayerPrefs.SetString("Local", Local);
                SceneManager.LoadScene(Cena);
            }
            if (OtherScene == false)
            {
                collision.gameObject.transform.position = tr.position;
            }
        }
    }
}
