using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    /*
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
    }*/

    CharacterController controller;

    public float speed = 20;
    public float speed_rotation = 10;
    public GameObject go;
    public float sensitivity = 1F;
    public Camera goCamera;
    private Vector3 MousePos;
    private float MyAngle = 0F;

    private void Start()
    {
        go = goCamera.transform.parent.gameObject;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MousePos = Input.mousePosition;
        transform.Rotate(0, Input.GetAxis("Horizontal") * speed_rotation, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float current_speed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * current_speed);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;
            MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, MyAngle);
            MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -MyAngle);
        }
    }
}

