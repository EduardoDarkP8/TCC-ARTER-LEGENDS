using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTheGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fechar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator fechar() 
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
