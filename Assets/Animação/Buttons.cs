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
    public void Continue() 
    {
        if (PlayerPrefs.GetInt("Cena") != 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Cena"));
        }
    }

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
        Anima3.SetBool("Ativar", true);
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

    
    
    private void Start()
	{
        
    }
	public void SetCharacter() 
    {
        PlayerPrefs.SetString("Local", "SpwanPoint1");
        PlayerPrefs.DeleteKey("selected");
        PlayerPrefs.SetInt("selected", select);
        Debug.Log(PlayerPrefs.GetInt("selected"));
        SceneManager.LoadScene(1);
    }
    

}
