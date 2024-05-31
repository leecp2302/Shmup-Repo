using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject damage;
    public float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        damage = GameObject.Find("Damage");
        damage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private IEnumerator Damage()
    {
        damage.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        damage.SetActive(false);
    }
}
