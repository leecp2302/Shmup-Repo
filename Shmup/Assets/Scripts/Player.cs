using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 boundary;
    public float fireRate = 0.1f;
    private Camera MainCamera;
    private float nextFire;
    private float objectHeight;
    private float objectWidth;
    private GameObject playerModel;
    private Vector3 position;
    private GameObject projectile;
    private Transform projectileSpawnPosition;
    public float rotateSpeed = 350.0f;
    public float speed = 1000.0f;
    public float tilt = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerModel = GameObject.Find("craft_speederA");
        projectile = Resources.Load<GameObject>("Projectile");
        projectileSpawnPosition = GameObject.Find("Projectile Spawn Position").transform;

        SetBoundary();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        //Boundary();

        //PlayerMovement();

        transform.position = position;

        Shoot();
    }

    void FixedUpdate()
    {
        //LookAtMouse();

        PhysicsMovement();

        //TankControls();

        Tilt();
    }

    void LateUpdate()
    {
        InitialiseOrthographicBoundary();

        //InitialisePerspectiveBoundary();
    }

    private void SetBoundary()
    {
        boundary = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = playerModel.transform.GetComponent<MeshRenderer>().bounds.extents.x;
        objectHeight = playerModel.transform.GetComponent<MeshRenderer>().bounds.extents.y;
    }

    //private void Boundary()
    //{
    //    if (position.x > GameManager.instance.xBoundary)
    //    {
    //        position.x = GameManager.instance.xBoundary;
    //    }
    //    else if (position.x < -GameManager.instance.xBoundary)
    //    {
    //        position.x = -GameManager.instance.xBoundary;
    //    }
    //    if (position.y > GameManager.instance.yBoundary)
    //    {
    //        position.y = GameManager.instance.yBoundary;
    //    }
    //    else if (position.y < -GameManager.instance.yBoundary)
    //    {
    //        position.y = -GameManager.instance.yBoundary;
    //    }
    //}

    private void PlayerMovement()
    {
        if (Input.GetKey("w"))
        {
            position.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            position.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            position.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            position.x += speed * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            Instantiate(projectile, projectileSpawnPosition.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    private void LookAtMouse()
    {
        float moveVertical = Input.GetAxis("Vertical");
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        GetComponent<Rigidbody>().velocity = moveVertical * transform.up * speed * Time.fixedDeltaTime;
    }

    private void PhysicsMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed * Time.fixedDeltaTime;
    }

    private void TankControls()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward * moveHorizontal * rotateSpeed * Time.fixedDeltaTime * -1);
        GetComponent<Rigidbody>().velocity = moveVertical * transform.up * speed * Time.fixedDeltaTime;
    }

    private void Tilt()
    {
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * tilt * -1);
    }

    private void InitialiseOrthographicBoundary()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, boundary.x * -1 + objectWidth, boundary.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, boundary.y * -1 + objectHeight, boundary.y - objectHeight);
        transform.position = viewPosition;
    }

    private void InitialisePerspectiveBoundary()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, boundary.x + objectWidth, boundary.x * -1 - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, boundary.y + objectHeight, boundary.y * -1 - objectHeight);
        transform.position = viewPosition;
    }
}
