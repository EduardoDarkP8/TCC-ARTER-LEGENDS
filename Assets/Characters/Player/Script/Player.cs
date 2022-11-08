using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimation 
{
    walk,
    attack,
    interact,
    shot
}
public class Player : MonoBehaviour
{
    public int selected;
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
    Rigidbody2D characterRg;
    public Animator anima;
    public AnimatorControllerParameter Wyn;
    public RuntimeAnimatorController[] AnimatorController = new RuntimeAnimatorController[2];

    public int playerSelected(int player) 
    {
        return player;
    }
	void Spwan() 
    {
        hp[0] = 10;
        hp[1] = 14;

        mana[0] = 10;
        mana[1  ] = 6;

        aDamage[0] = 2;
        aDamage[1] = 1;

        sDamage[0] = 1;
        sDamage[1] = 2;

        wSpeed[0] = 4;
        wSpeed[1] = 3;

        aSpeed[0] = 0.6f;
        aSpeed[1] = 0.3f;

        sSpeed[0] = 0.9f;
        sSpeed[1] = 0.6f;

        aRange[0] = 4;
        aRange[1] = 2;

        sRange[0] = 10;
        sRange[1] = 20;

        name[0] = "Mina Tenebra";
        name[1] = "Wyn Fridy";
        
		
        
    }
	void Awake()
    {
        Spwan();
        selected = playerSelected(selected);
        vida.Vida = hp[selected];
        anima.runtimeAnimatorController = AnimatorController[selected];
        GetComponent<SpriteRenderer>().sprite = sprites[selected];
    }
    void GetComponents() 
    {
        characterRg = GetComponent<Rigidbody2D>();
    }
    private void Start()
	{
        GetComponents();
    }
    private void FixedUpdate()
    {
        if (status == PlayerAnimation.walk)
        {
            Mover();
        }
        Attack();
        

    }
    void Mover() 
    {
        xm = Input.GetAxisRaw("Horizontal");
        ym = Input.GetAxisRaw("Vertical");
        if (xm != 0 || ym != 0 && Attacking == false && TriggerConfirm == false) 
        {
            
            characterRg.MovePosition(transform.position + new Vector3(xm, ym, 0) * wSpeed[selected] * Time.deltaTime);
                anima.SetFloat("X", xm);
                anima.SetFloat("Y", ym);
                PlayerAngle = Mathf.Atan2(-xm,ym) * Mathf.Rad2Deg;
                Pivo.transform.eulerAngles = new Vector3(0, 0, PlayerAngle);
        }
		if (xm == 0 || ym == 0)
        {
            characterRg.MovePosition(transform.position + new Vector3(xm, ym, 0) * wSpeed[selected] * Time.deltaTime);
        }
    }
    void Attack() 
    {

        if (Input.GetMouseButtonDown(0) && TriggerConfirm == false)
        {
            anima.SetBool("Ataque",true);
            Attacking = true;
            HitCollider.enabled = true;
            StartCoroutine(CoolDown(aSpeed[selected], PlayerAnimation.attack));
        }
		else if (Input.GetMouseButton(0) == false)
        {
            anima.SetBool("Ataque", false);
            Attacking = false;

            HitCollider.enabled = false;
        }

    }

	void Update()
    {
        characterRg.velocity = Vector2.zero;
    }
    public IEnumerator CoolDown(float tempo, PlayerAnimation State)
    {
        status = State;
        yield return new WaitForSeconds(tempo);
        status = PlayerAnimation.walk;
    }
    
}
