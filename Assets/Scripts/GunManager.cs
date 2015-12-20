using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {


	public GameObject[] GunsArray;
	public GameObject HUD;
	HUDManager hud;
	public int current_gun = 0;
	// Use this for initialization
	void Start () {
		hud = HUD.GetComponent<HUDManager> ();
		hud.gun = GunsArray [current_gun].transform.GetChild (0).gameObject;
		GunsArray [current_gun].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
		bool swapGuns = Input.GetKeyDown("t");
		if (swapGuns && GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Default")) 
		{
			GunsArray [current_gun].SetActive (false);
			current_gun++;
			current_gun = current_gun % GunsArray.Length;
			GunsArray [current_gun].SetActive (true);
			hud.gun = GunsArray [current_gun].transform.GetChild (0).gameObject;
		}
	}
}
