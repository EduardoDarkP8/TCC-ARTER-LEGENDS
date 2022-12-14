using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayerAnimation 
{
    walk,
    attack,
    interact,
    stuned,
    shot
}
public class Player : MonoBehaviour
{

    bool paused;
    public string PlayerDirect;
    public int[] hp = new int[2];
    public int[] mana = new int[2];
    public int[] aDamage = new int[2];
    public int[] sDamage = new int[2];
    public float[] wSpeed = new float[2];
    public float[] aSpeed = new float[2];
    public float[] sSpeed = new float[2];
    public float[] aRange = new float[2];
    public float[] sRange = new float[2];
    public string[] name = new string[2];
    private bool Attacking;
    public float PlayerAngle;
    public Collider2D HitCollider;
    public bool TriggerConfirm;
    public float xm { get; set; }
    public float ym { get; set; }
    public Sprite[] sprites = new Sprite[2];
    public PlayerAnimation status;
    public Vivo vida;
    public GameObject Pivo;
    public Rigidbody2D characterRg;
    public Animator anima;
    public AnimatorControllerParameter Wyn;
    public RuntimeAnimatorController[] AnimatorController = new RuntimeAnimatorController[2];


    void Spwan()
    {


        hp[0] = 10;
        hp[1] = 14;

        mana[0] = 10;
        mana[1] = 6;

        aDamage[0] = 1;
        aDamage[1] = 1;

        sDamage[0] = 1;
        sDamage[1] = 2;

        wSpeed[0] = 4;
        wSpeed[1] = 3;

        aSpeed[0] = 0.35f;
        aSpeed[1] = 0.45f;

        sSpeed[0] = 1.3f;
        sSpeed[1] = 0.9f;

        aRange[0] = 4;
        aRange[1] = 2;

        sRange[0] = 10;
        sRange[1] = 20;

        name[0] = "Mina Tenebra";
        name[1] = "Wyn Fridy";



    }


    void GetComponents()
    {
        characterRg = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {


        Spwan();
        vida.Vida = hp[PlayerPrefs.GetInt("selected")];
        anima.runtimeAnimatorController = AnimatorController[PlayerPrefs.GetInt("selected")];
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("selected")];


        GetComponents();
    }
    private void FixedUpdate()
    {
        if (status == PlayerAnimation.walk)
        {
            Mover();
        }
    }
    void Mover()
    {
        xm = Input.GetAxisRaw("Horizontal");
        ym = Input.GetAxisRaw("Vertical");
        if (xm != 0 || ym != 0 && Attacking == false && TriggerConfirm == false && status == PlayerAnimation.walk)
        {

            characterRg.MovePosition(transform.position + new Vector3(xm, ym, 0) * wSpeed[PlayerPrefs.GetInt("selected")] * Time.deltaTime);
            anima.SetFloat("X", xm);
            anima.SetFloat("Y", ym);
            
            PlayerAngle = Mathf.Atan2(-xm, ym) * Mathf.Rad2Deg;
            Pivo.transform.eulerAngles = new Vector3(0, 0, PlayerAngle);
            
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) 
        {
            anima.SetBool("Andando",true);
        }
        else
        if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {
            anima.SetBool("Andando",false);
        }
        if (xm == 0 || ym == 0)
        {
            characterRg.MovePosition(transform.position + new Vector3(xm, ym, 0) * wSpeed[PlayerPrefs.GetInt("selected")] * Time.deltaTime);
           
        }
    }
    void Attack()
    {
        StartCoroutine(CoolDown(aSpeed[PlayerPrefs.GetInt("selected")], PlayerAnimation.attack));
        if (status == PlayerAnimation.attack)
        {
            anima.SetBool("Ataque", true);
            Attacking = true;
            HitCollider.enabled = true;
        }


        else if (status != PlayerAnimation.attack)
        {
            anima.SetBool("Ataque", false);
            Attacking = false;
            HitCollider.enabled = false;
        }

    }

    void Update()
    {
        Menu();
        Attack();
        characterRg.velocity = Vector2.zero;

    }
    public IEnumerator CoolDown(float tempo, PlayerAnimation State)
    {
        if (Input.GetMouseButtonDown(0))
        {
            status = State;
            yield return new WaitForSeconds(tempo);
            status = PlayerAnimation.walk;

        }
        yield return null;
    }
    public void KnockBackhit(Transform reference)
    {

        status = PlayerAnimation.stuned;
        Vector3 Local = (transform.position + reference.forward);
        characterRg.MovePosition(Vector2.MoveTowards(transform.position, Local, Time.deltaTime * 50));
        StartCoroutine(Returnar());
    }
    private IEnumerator Returnar()
    {
        yield return new WaitForSeconds(0.5f);
        status = PlayerAnimation.walk;

    }
    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {

            GameObject ob = GameObject.Find("Hud") as GameObject;
            ob.transform.Find("Menu").gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            GameObject ob = GameObject.Find("Hud") as GameObject;
            ob.transform.Find("Menu").gameObject.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

}