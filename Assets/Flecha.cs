using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Rigidbody2D ctr;
    public float Velocity;
    // Start is called before the first frame update
    void Start()
    {
        ctr = GetComponent<Rigidbody2D>();
        StartCoroutine(destruir());

    }

    // Update is called once per frame
    void Update()
    {
        ctr.velocity = transform.up * Velocity * Time.deltaTime;
    }
    IEnumerator destruir()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
