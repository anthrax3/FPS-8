using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour {


    public GameObject gun;
    public GameObject gun_manager;
    FireGun firegun;
    GunManager gun_manager_script;
    public Text ammo_display;
    int ammo_count;
    public GameObject pauseMenu;
    public GameObject gameoverscreen;
    bool pause = false;
    GameObject player;
    PlayerHealth playerhealth;
    bool gameover = false;
	public Text health_value_display;
    Animator anim;
    public Image damaged_image;
    public Color damaged_color = new Color(1f, 0f, 0f, 0.1f);
    public Color health_color = new Color(0f, 1f, 0f, 0.1f);
    public Color selected_color = new Color(0f, 0f, 1f);
    public Color not_selected_color = new Color(0f, 0f, 0.1f);
    public float damaged_fade_speed = 3f;
    public RawImage [] gun_selected;


    // Use this for initialization
    void Start () {
        firegun = gun.GetComponent<FireGun>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        anim = gameObject.GetComponent<Animator>();
        gun_manager_script = gun_manager.GetComponent<GunManager>();


    }
	
	// Update is called once per frame
	void FixedUpdate () {
		firegun = gun.GetComponent<FireGun>();
        anim.speed = firegun.animation_speed;
        ammo_count = firegun.ammo_in_clip;
        ammo_display.text = ammo_count.ToString() + "/" + firegun.clip_size.ToString();
        if (int.Parse(health_value_display.text) > playerhealth.Health)
        //if (string.Compare(health_value_display.text,playerhealth.Health.ToString()) > 0)
        {
            damaged_image.color = damaged_color;
        }
        else if (int.Parse(health_value_display.text) < playerhealth.Health)
        {
            damaged_image.color = health_color;
        }
        else
        {
            
            damaged_image.color = Color.Lerp(damaged_image.color, Color.clear, damaged_fade_speed * Time.deltaTime);
        }
		health_value_display.text = playerhealth.Health.ToString();

        if (playerhealth.Health <= 0)
        {
            gameover = true;
            gameoverscreen.SetActive(true);
            Time.timeScale = 0.0F;
        }



        //display which gun we have
        for (int i = 0; i < gun_selected.Length; i++)
        {
            if (i == gun_manager_script.current_gun)
            {
                gun_selected[i].color = selected_color;
            }
            else
            {
                gun_selected[i].color = not_selected_color;
            }
        }


    }

    void Update()
    {
        if (!gameover)
        {
            bool buttonpress = Input.GetKeyDown(KeyCode.Escape);
            if (buttonpress)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pause = !pause;
        if (pause == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0F;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0F;
        }
    }


    public void exitReload()
    {
        firegun.reloadedGun();
    }

    public void reloadLevel()
    {
        Time.timeScale = 1.0F;
        //Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene ("Level0");
    }


    public void quitGame()
    {
        Application.Quit();
    }



}
