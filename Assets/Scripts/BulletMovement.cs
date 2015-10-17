using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float speed;
    public int damage;
    private bool collide = false;
    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

    }

    void OnTriggerEnter(Collider other)
    {
       
        if (collide == false && other.GetType() == typeof(BoxCollider) )
        {
            collide = true;
            
            if (other.CompareTag("Enemy"))
            {
                
                other.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().PlayerLoseHealth(damage);
            }
            Destroy(gameObject);

        }

    }
}
