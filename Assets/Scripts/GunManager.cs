using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {


	public GameObject[] GunsArray;
	public GameObject HUD;
	HUDManager hud;

	bool swappingGuns = false;
	public int current_gun = 0;
	// Use this for initialization
	void Start () {
		hud = HUD.GetComponent<HUDManager> ();
		hud.gun = GunsArray [current_gun].transform.GetChild (0).gameObject;
		GunsArray [current_gun].transform.GetChild (0).gameObject.SetActive (true);
		//GunsArray [current_gun].SetActive (true);
		GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<Animator> ().CrossFade ("Default", 0f);
	}
	
	// Update is called once per frame
	void Update () {
	

		bool swapGuns = Input.GetKeyDown("t");
		if (swappingGuns == true)
		{
			if (GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<FireGun> ().active_gun == true)
				return;
			
			current_gun++;
			current_gun = current_gun % GunsArray.Length;
			GunsArray [current_gun].transform.GetChild (0).gameObject.SetActive (true);
			GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<Animator> ().SetTrigger ("SwapIn");
			GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<FireGun>().active_gun = true;
			hud.gun = GunsArray [current_gun].transform.GetChild (0).gameObject;
			swappingGuns = false;
			return;

		}
		if (swapGuns && GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Default")) {
			//GunsArray [current_gun].SetActive (false);
			GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<FireGun> ().active_gun = false;
			GunsArray [current_gun].transform.GetChild (0).gameObject.GetComponent<Animator> ().SetTrigger ("SwapOut");
			swappingGuns = true;


		} 
	}
}
