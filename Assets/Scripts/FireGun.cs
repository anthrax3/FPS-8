using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {


    public GameObject bullet;
    GameObject hud;
    Animator hud_anim;
    Animator gun_anim;
    public volatile bool reload = false;
	public volatile bool active_gun = true;
    public int ammo_in_clip;
    public int clip_size;
    public AudioSource reloadAudio;
    public AudioSource fireAudio;
	public AudioSource shellAudio;
    private bool fire_flag = false;
	public GameObject no_ammo_icon;
	public int damage = 0;
	public int speed = 0;
	public int gun_type = 0;

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
		if (!active_gun)  //if gun not active
			return;
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

	public void playShellsAudio()
	{
		shellAudio.Stop ();
		shellAudio.Play ();
	}


    public void exitFire()
    {
        gun_anim.SetBool("Fire", false);
        fire_flag = false;
    }

	public void createBullet()
	{
		GameObject test;
		Transform bullettransform = gameObject.transform;

		if (gun_type == 0) {
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;
		} else if (gun_type == 1) { //shotgun

		

//			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
//			test.GetComponent<BulletMovement> ().damage = damage;
//			test.GetComponent<BulletMovement> ().speed = speed;


			bullettransform.Rotate (transform.up, 2f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.up, -5.5f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.up, 3f);
			bullettransform.Rotate (transform.right, 2f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.right, -6f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.up, 4f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.up, -8f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.right, 7f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;

			bullettransform.Rotate (transform.up, 8f);
			test = Instantiate (bullet, transform.position + transform.forward * (transform.localScale.z), bullettransform.rotation) as GameObject;
			test.GetComponent<BulletMovement> ().damage = damage;
			test.GetComponent<BulletMovement> ().speed = speed;



	


		}

	}


	public void SwapOut()
	{
		//gameObject.SetActive(false);
		active_gun = false;
	}


}


