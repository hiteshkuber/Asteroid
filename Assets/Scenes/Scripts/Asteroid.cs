using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _body2D;
    private float _maxLifeTime = 30f;
    // Start is called before the first frame update
    void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360);
        this.transform.localScale = Vector3.one * this.size;

        _body2D.mass = this.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTrajectory(Vector2 direction)
    {
        // Throwing asteroid logic
        _body2D.AddForce(direction * Random.Range(15, 25));
        Destroy(this.gameObject, this._maxLifeTime);
    }
}
