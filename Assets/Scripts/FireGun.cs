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

        if (!reload && !fire_flag)
        {
            if (ammo_in_clip != 0  &&Input.GetMouseButtonDown(0))
            {
                fire_flag = true;
                ammo_in_clip--;
                gun_anim.SetBool("Fire", true);

                Instantiate(bullet, transform.position + transform.forward*(transform.localScale.z), transform.rotation);
            }
            bool reloadGun = Input.GetKeyDown("r");
            if (reloadGun)
            {
                reload = true;
                hud_anim.SetBool("Reload", true);
                gun_anim.SetTrigger("Reload");
                
            }
        }


    }

    public void reloadedGun()
    {
        reload = false;
        hud_anim.SetBool("Reload", false);
        ammo_in_clip = clip_size;
    }

    public void playReloadAudio()
    {
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



}


