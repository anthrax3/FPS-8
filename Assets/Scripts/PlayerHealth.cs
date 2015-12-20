using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    public float Health = 100;
    public Slider health_slider;
    public Image healthSliderbackground;
	void Start () {
        health_slider.value = 100;
        healthSliderbackground.color = Color.green;
    }
	
	// Update is called once per frame
	void Update () {
        health_slider.value = Health;
        healthSliderbackground.color = Color.Lerp(Color.red, Color.green, Health / 100f);
    }

    public void PlayerLoseHealth(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0,100);
    }

    public void addHealth(int heal)
    {
        Health += heal;
		Health = Mathf.Clamp(Health, 0,100);
    }
}
