using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float speed = 2000.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
}
