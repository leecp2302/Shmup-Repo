using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioManager audioManager;
    public float damage = 25.0f;
    public GameObject damageModel;
    public float damageRate = 1.0f;
    public float health = 100.0f;
    private float nextDamage;
    private Rigidbody rigidBody;
    public float speed = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = -transform.up * speed * Time.fixedDeltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Time.time > nextDamage)
        {
            other.GetComponent<Player>().TakeDamage(damage);
            nextDamage = Time.time + damageRate;
            audioManager.EnemyImpactAudio();
        }
    }

    private IEnumerator Damage()
    {
        damageModel.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        damageModel.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(Damage());
        if(health == 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
