using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Animator Anima;
    public Animator Anima2;
    public Animator Anima3;
    public Animator Anima4;
    public Animator Anima5;
    public void NewGame()
    {
        Anima.SetBool("SelectNewGame",true);
        Anima2.SetBool("Ativar", true);
        Anima.SetBool("Credits", false);
        Anima4.SetBool("Ativar", true);
        Anima5.SetBool("Ativar", false);
    }
    public void Credits() 
    {
        Anima.SetBool("Credits", true);
        Anima2.SetBool("Ativar", true);
        StartCoroutine(Cooldown(0.2f));
        Anima4.SetBool("Ativar", true);
        Anima5.SetBool("Ativar", false);
    }
    public void Back() 
    {
        Anima.SetBool("SelectNewGame", false);
        Anima2.SetBool("Ativar", false);
        Anima.SetBool("Credits", false);
        Anima4.SetBool("Ativar", false);
        Anima3.SetBool("Ativar", false);
        Anima5.SetBool("Ativar", true);
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public IEnumerator Cooldown(float time) 
    {
        yield return new WaitForSeconds(time);
        Anima3.SetBool("Ativar", true);
    }
}
