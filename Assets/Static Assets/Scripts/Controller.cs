using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject _MainCamera;

    [SerializeField]
    private GameObject _player;

    private float _speed;
    private Rigidbody _rb;
    private bool _grounded;

    private int _speedRotation = 1;
    private int _jumpSpeed = 10;
    void Start()
    {
        _grounded = true;
        _rb = _player.GetComponent<Rigidbody>();
        _speed = 5;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _player.transform.position += _player.transform.forward * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _player.transform.position -= _player.transform.forward * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.Rotate(Vector3.down * _speedRotation);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.Rotate(Vector3.up * _speedRotation);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.transform.position += _player.transform.up * _jumpSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.transform.position += _player.transform.up * _jumpSpeed * Time.deltaTime;
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _jumpForce = 20f;

    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        var testMovement = movement * _speed;
        Debug.Log(testMovement);
        _rb.AddForce(movement * _speed);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * _jumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }

    void OnCollisionStay(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }
    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}*/