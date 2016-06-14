using UnityEngine;
using System.Collections;

public class enemy_jump : MonoBehaviour {


    NavMeshAgent nav;
    private bool jump_state = false;
    private Transform orig_transform;
    private float total_delta;
	// Use this for initialization
	void Start () {
        nav = gameObject.GetComponent<NavMeshAgent>();
        orig_transform = transform;
        total_delta = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //is jumping
        if (nav.isOnOffMeshLink)
        {
            jump_state = true;
        }
        if (jump_state)
        {
            total_delta += Time.deltaTime*3;
            if (Mathf.Clamp(total_delta, 0f, Mathf.PI) == Mathf.PI)
            {
                total_delta = 0f;
                // transform.position.Set(gameObject.transform.position.x, orig_transform.position.y, gameObject.transform.position.z);
                transform.localPosition = orig_transform.localPosition + new Vector3(0, 1, 0) * 1.5f*Mathf.Sin(total_delta);
                jump_state = false;
            }
            else
            {
                //transform.position.Set(gameObject.transform.position.x, orig_transform.position.y + total_delta, gameObject.transform.position.z);
                transform.localPosition = orig_transform.localPosition + new Vector3(0, 1 ,0) *1.5f*Mathf.Sin(total_delta);
            }
        }
	}
}
