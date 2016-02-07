using UnityEngine;
using System.Collections;

public class HeadRotation : MonoBehaviour {

    private float rotationY = 0f;
    private float rotationX = 0f;

    GameObject player;
    
    float speed;
    // Use this for initialization
    void Start () {
        speed = this.transform.parent.GetComponent<Movement>().rotationspeed;
        player = this.transform.parent.gameObject;
        transform.position = new Vector3(0, player.GetComponent<BoxCollider>().size.y, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rotationX += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        player.transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }
}
