using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float speed;
    public int damage;
    private bool collide = false;
	public bool playerbullet = true;
    public bool randomColors = true;
    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        if (randomColors)
        {
            var nColor = new Color(Random.value, Random.value, Random.value, 1f);
            Material trail = gameObject.GetComponent<TrailRenderer>().material;
            trail.SetColor("_Color", nColor);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (collide != true)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

    }

    void OnTriggerEnter(Collider other)
    {
       
		if (collide == false &&  (other.GetType() != typeof(SphereCollider)))
        {
            collide = true;
            
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            if (other.CompareTag("Player") && !playerbullet) //player can't hurt self
            {
                other.GetComponent<PlayerHealth>().PlayerLoseHealth(damage);
            }
			if (other.CompareTag ("Player") && playerbullet) 
			{
				collide = false;
				return;
			}
            //Destroy(gameObject);
            gameObject.GetComponent<Renderer>().enabled = false;

        }

    }
}
