using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {


    GameObject player;
    GameObject head;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        head = player.transform.FindChild("Head").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = head.transform.position;
        transform.rotation = head.transform.rotation;
	}
}
