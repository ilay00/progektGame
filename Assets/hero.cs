using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour

{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private GameObject _patron;
    private byte _patronCount;
    private sbyte _directin;
    private bool _onFloor;
    private bool _deed;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Camera _mc;
    private Animator _anim;

    // При поевлении обЪекта при старте на сцени
    void Start()
    {
        _deed = false;
        _mc = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim= GetComponent<Animator>();

    }

    // Выполняится каждый раз при обновления Экрана Update()
    void Update()
    {
        _mc.transform.position = new Vector3(transform.position.x, transform.position.y, _mc.transform.position.z);
    }
    private void FixedUpdate()
    {
        if (!_deed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _sr.flipX = false;
                _directin = 1;
                Move();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _sr.flipX = true;
                _directin = -1;
                Move();
            }

            else
            {
                Stop();
            }

            if (Input.GetKey(KeyCode.W) && _onFloor)
            {
               
                _onFloor = false;
                Jump();
            }
          


            if (_rb.velocity.y == 0)
            {
                _anim.SetBool("Bdeath", false);
                _onFloor = true;
               
            }
         

            if (Input.GetKeyDown(KeyCode.Q) && _patronCount > 0)
            {
                _patronCount--;
                var patron = Instantiate(_patron, transform.position, new Quaternion());
                patron.GetComponent<Rigidbody2D>().velocity = new Vector2(_directin * 7, 3);
            }
        }
    }
    private void Move()
    {
        _anim.SetBool("go", true);
        _rb.velocity = new Vector2(_speed * _directin, _rb.velocity.y);
        
    }
    private void Stop()
    {
        _anim.SetBool("go", false);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
       
    }
    private void Jump() {
        _anim.SetBool("jamp", true);
        _rb.velocity = new Vector2(_rb.velocity.x,_jumpHeight);
        
    }

    public void AddPatron(byte patronCount)
    {
        _patronCount += patronCount;
    }
    public void TakeDamage()
    {
        _deed = true;
       _anim.SetBool("Bdeath", true);
        Destroy(gameObject, 2);
    }
}
