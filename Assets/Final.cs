using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Final : MonoBehaviour
{
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
        if (collision.gameObject.name == "Body")
        {
            StartCoroutine(terminar());
        }
    }
    public IEnumerator terminar() 
    {
        Debug.Log("asdasd");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);

    }


}
