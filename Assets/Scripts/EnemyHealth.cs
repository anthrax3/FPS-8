using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


    public int health;
    Animator anim;
    public AudioSource deathSound;
    public int points_awarded;
    public GameObject hud;
    HUDManager hud_manager;
   
    bool isDead = false;


    void Awake()
    {
        anim = GetComponent<Animator>();
        hud_manager = GameObject.Find("HUD").GetComponent<HUDManager>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        
        
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0 && !isDead)
        {
            isDead = true;
            hud_manager.update_score(points_awarded);
            
            anim.SetTrigger("isDead");
            //DestroyObject();

        }
            

	}

    public void DestroyObject()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    public void playdeathSound()
    {
        deathSound.Play();
    }


}
