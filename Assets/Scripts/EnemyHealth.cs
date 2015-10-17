using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


    public int health;
    Animator anim;
    public AudioSource deathSound;
   
    bool isDead = false;


    void Awake()
    {
        anim = GetComponent<Animator>();
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
