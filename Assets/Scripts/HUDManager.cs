using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour {


    public GameObject gun;
    FireGun firegun;
    public Text ammo_display;
    int ammo_count;
    public GameObject pauseMenu;
    public GameObject gameoverscreen;
    bool pause = false;
    GameObject player;
    PlayerHealth playerhealth;
    bool gameover = false;
	public Text health_value_display;


    // Use this for initialization
    void Start () {
        firegun = gun.GetComponent<FireGun>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();


    }
	
	// Update is called once per frame
	void FixedUpdate () {
		firegun = gun.GetComponent<FireGun>();
        ammo_count = firegun.ammo_in_clip;
        ammo_display.text = ammo_count.ToString() + "/" + firegun.clip_size.ToString();
		health_value_display.text = playerhealth.Health.ToString();

        if (playerhealth.Health <= 0)
        {
            gameover = true;
            gameoverscreen.SetActive(true);
            Time.timeScale = 0.0F;
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
