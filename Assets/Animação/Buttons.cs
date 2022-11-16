using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Animator Anima;
    public Animator Anima2;
    public void NewGame()
    {
        Anima.SetBool("SelectNewGame",true);
        Anima2.SetBool("Ativar", true);
    }
}
