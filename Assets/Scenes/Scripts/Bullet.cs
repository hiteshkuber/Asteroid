using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public int speed = 500;
    private float _maxLifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
