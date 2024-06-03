using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private AudioManager audioManager;
    public float damage = 50.0f;
    public float lifetime = 1.0f;
    private Rigidbody rigidBody;
    public float speed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifetime);
    }

    void FixedUpdate()
    {
        if (this.gameObject.tag == "Up")
        {
            rigidBody.velocity = transform.up * speed * Time.fixedDeltaTime;
        }
        else if (this.gameObject.tag == "Left")
        {
            rigidBody.velocity = -transform.right * speed * Time.fixedDeltaTime;
        }
        else if (this.gameObject.tag == "Down")
        {
            rigidBody.velocity = -transform.up * speed * Time.fixedDeltaTime;
        }
        else if (gameObject.tag == "Right")
        {
            rigidBody.velocity = transform.right * speed * Time.fixedDeltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
            audioManager.ProjectileImpactAudio();
        }
    }
}
