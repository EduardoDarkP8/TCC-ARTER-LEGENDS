using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Animator Anima;
    public Animator Anima2;
    public Animator Anima3;
    public Animator Anima4;

    public int select;
    public void NewGame()
    {
        Anima.SetBool("SelectNewGame",true);
        Anima2.SetBool("Ativar", true);
        Anima.SetBool("Credits", false);
        Anima4.SetBool("Ativar", true);

    }
    public void Credits() 
    {
        Anima.SetBool("Credits", true);
        Anima2.SetBool("Ativar", true);
        StartCoroutine(Cooldown(0.1f));
        Anima4.SetBool("Ativar", true);

    }
    public void Back() 
    {
        Anima.SetBool("SelectNewGame", false);
        Anima2.SetBool("Ativar", false);
        Anima.SetBool("Credits", false);
        Anima4.SetBool("Ativar", false);
        Anima3.SetBool("Ativar", false);
       


    }
    public void Exit() 
    {
        Application.Quit();
    }
    public IEnumerator Cooldown(float time) 
    {
        yield return new WaitForSeconds(time);
        Anima3.SetBool("Ativar",true);
    }

    public void SetCharacter() 
    {

       PlayerPrefs.SetInt("selected", select);
       Debug.Log(PlayerPrefs.GetInt("selected"));
       SceneManager.LoadScene(1);
    }
	private void Start()
	{

        
	}
}
