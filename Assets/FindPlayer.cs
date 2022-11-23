using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayer : MonoBehaviour
{
    CinemachineVirtualCamera cn;

    void Start()
    {
        cn = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (GameObject.Find("Body") != null)
        {
            cn.Follow = GameObject.Find("Body").transform;
        }
    }
}
