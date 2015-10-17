using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float rotationspeed;
    public float upthrust;
    public int jumps_possible;
    private int jump_counter;
    



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        jump_counter = jumps_possible;
    }



    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.position += ((new Vector3(transform.forward.x, 0, transform.forward.z)).normalized * moveVertical + (new Vector3(transform.right.x, 0, transform.right.z)).normalized * moveHorizontal) * speed * Time.deltaTime;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void Update()
    {
       
        
       
        bool jump = Input.GetKeyDown("space");
 
        if (jump && jump_counter != 0)
        {
            jump_counter--;
            rb.velocity = new Vector3 (0,0,0);
            rb.AddForce((new Vector3(0,1,0)) * upthrust);
        }
     

       


      
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jump_counter = jumps_possible;
        }
    }
}
