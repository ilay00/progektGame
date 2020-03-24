using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private sbyte _directin;
    private float _leftBorder;
    private float _rightBorder;
 
    private bool _deed;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;


    // При поевлении обЪекта при старте на сцени
    void Start()
    {
        _directin = 1;
        _deed = false;
        _leftBorder = transform.position.x - _distance;
        _rightBorder = transform.position.x + _distance;
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();

    }

    /* Выполняится каждый раз при обновления Экрана Update()
    void Update()
    {
        _mc.transform.position = new Vector3(transform.position.x, transform.position.y, _mc.transform.position.z);
    }*/
    private void FixedUpdate()
    {
        if (!_deed) { 

        if (_directin==1 && transform.position.x > _rightBorder)
        {
            _sr.flipX = true;
            _directin = -1;
       
        }
            if (_directin == -1 && transform.position.x < _leftBorder)
            {
                _sr.flipX = false;
                _directin = 1;
            }
        }
        Move();
    }
    private void Move()
    {
        _rb.velocity = new Vector2(_speed * _directin, _rb.velocity.y);
    }
       public void TakeDamage()
    {
        _deed = true;
        GetComponent<Animator>().SetBool("Bdeath", true);
        Destroy(gameObject,2);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name== "heroidle1") 
        {
            col.gameObject.GetComponent<hero>().TakeDamage();
        }
    }
  
}
