using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


    GameObject player;
    Transform inner_barrel;
    public GameObject bullet;
    public float time_between_attacks;
    float time_after_last_attack = 0;
    volatile bool player_in_range = false;
    Animator anim;
    NavMeshAgent nav;
    public AudioSource laserfireAudio;
    bool isDead = false;
	Rigidbody rb;

    // Use this for initialization
    void Start () {
        inner_barrel = this.gameObject.transform.GetChild(1).GetChild(0);
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
		//rb = GetComponent<Rigidbody> ();

    }
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
            {

                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, Time.deltaTime, 0));
				
                if (player_in_range)
                {
                    time_after_last_attack += Time.deltaTime;
                    if (time_after_last_attack >= time_between_attacks)
                    {
                    
                        //set bool
                        anim.SetTrigger("Attack");
                        time_after_last_attack = 0;
                    }
                    nav.SetDestination(player.transform.position);

                }
            
            }
        else
            nav.enabled = false;

        player_in_range = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            player_in_range = true;

        }

    }
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
           

    //        player_in_range = false;
    //    }

    //}

    void Attack()
    {
        playFireAudio();
        Instantiate(bullet, inner_barrel.position + inner_barrel.up , transform.rotation);
    }
    public void playFireAudio()
    {
        laserfireAudio.Stop();
        laserfireAudio.Play();
    }

    public void setDeath()
    {
        isDead = true;
    }


}
