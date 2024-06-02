using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float thrustSpeed = 1f;
    public float turnSpeed = 1f;
    private Rigidbody2D _rigidBody;
    private bool _thursting;
    private float _turnDirection;
    public Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _thursting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("D pressed");
            _turnDirection = -1.0f;
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("A pressed");
            _turnDirection = 1.0f;
        } else
        {
            _turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        { 
            Shoot();
        }
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_thursting)
        {
            _rigidBody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (_turnDirection != 0f) 
        {
            _rigidBody.AddTorque(_turnDirection * this.turnSpeed);
            Debug.Log(_turnDirection + " : turnDirection");
        }
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);

        bullet.Project(this.transform.up);
    }
}
