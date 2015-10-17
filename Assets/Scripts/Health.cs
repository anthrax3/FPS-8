using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    // Use this for initialization
    public int health_restored;
    public float respawnTime;
    public bool gone = false;
    private float TimePassed = 0;
    
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if (gone == true)
        {
            TimePassed += Time.deltaTime;
            if (TimePassed >= respawnTime)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gone = false;
                TimePassed = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gone == false && (other.CompareTag("Player")) )
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gone = true;
            other.GetComponent<PlayerHealth>().addHealth(health_restored);
        }

        
    }

}
