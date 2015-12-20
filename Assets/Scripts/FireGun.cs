using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {


    public GameObject bullet;
    GameObject hud;
    Animator hud_anim;
    Animator gun_anim;
    public volatile bool reload = false;
    public int ammo_in_clip;
    public int clip_size;
    public AudioSource reloadAudio;
    public AudioSource fireAudio;
    private bool fire_flag = false;
	public GameObject no_ammo_icon;
	public int damage = 0;
	public int speed = 0;

    // Use this for initialization
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        hud_anim = hud.GetComponent<Animator>();
        ammo_in_clip = clip_size;
        gun_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (reload == false && ammo_in_clip == 0) {
			no_ammo_icon.SetActive (true);
		} 
		else 
		{
			no_ammo_icon.SetActive (false);
		}

		if (!fire_flag && !reload)
        {
            if (ammo_in_clip != 0  &&Input.GetMouseButtonDown(0))
            {
                fire_flag = true;
                ammo_in_clip--;
                gun_anim.SetBool("Fire", true);

                //Instantiate(bullet, transform.position + transform.forward*(transform.localScale.z), transform.rotation);
            }
            bool reloadGun = Input.GetKeyDown("r");
            if (reloadGun)
            {
                reload = true;
				no_ammo_icon.SetActive (false);
                hud_anim.SetTrigger("Reload");
                gun_anim.SetTrigger("Reload");
                
            }
        }


    }

    public void reloadedGun()
    {
        reload = false;
        //hud_anim.SetBool("Reload", false);
        ammo_in_clip = clip_size;
    }

    public void playReloadAudio()
    {
		reloadAudio.Stop();
        reloadAudio.Play();
    }
    public void playFireAudio()
    {
        fireAudio.Stop();
        fireAudio.Play();
    }


    public void exitFire()
    {
        gun_anim.SetBool("Fire", false);
        fire_flag = false;
    }

	public void createBullet()
	{
		GameObject test;
		test = Instantiate(bullet, transform.position + transform.forward*(transform.localScale.z), transform.rotation) as GameObject;
		test.GetComponent<BulletMovement> ().damage = damage;
	}



}


