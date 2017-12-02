﻿using UnityEngine;


public class BloodCell : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rb2d;
    private float _speed;
    private Vector2 _travelVec;



    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _speed = GenerateSpeed();
        _direction = GenerateDirection();
        _travelVec = new Vector2(_direction.x * _speed, _direction.y * _speed);
    }

    private Vector2 GenerateDirection()
    {
        //Generate X
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        return new Vector2(x, y);
    }

    private float GenerateSpeed()
    {
        //Generate a random speed for blood cell
        float spd = Random.Range(3f, 11f);

        return spd;
    }

    private void TravelInDirection()
    {
        _rb2d.velocity = _travelVec;
    }

    private void Update()
    {
        TravelInDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("Blood Cell Exited game world");
            Destroy(gameObject);
        }
    }
}
