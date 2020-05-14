using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour, IObjectStates
{
    private float speed = -12f;
    private float turnSpeed;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;




    public void Turn()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(turnSpeed, new Vector3(0f, 0f, 1f));
        _transform.rotation *= rotationZ;
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(speed + Time.deltaTime, 0f); 
    }

    public void AfterMap()
    {
       if (_transform.position.x < -12)
           Destroy(gameObject);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        turnSpeed = Random.Range(-10f, 10f);
    }

    private void Update()
    {
        AfterMap();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Bullet")
            Destroy(gameObject);
    }


}
