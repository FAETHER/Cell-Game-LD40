﻿using UnityEngine;


public class InvaderCell : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _speed;
    private Vector2 _direction;
    private Vector2 _travelVec;
    private float _minSpeed = 8f;
    private float _maxSpeed = 18f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        GenerateTravelVector();
    }

    private Vector2 GenerateDirection()
    {
        //Generate X
        float x = Random.Range(-1f, 1f);

        //Generate Y
        float y = Random.Range(-1f, 1f);

        return new Vector2(x, y);
    }

    private float GenerateSpeed()
    {
        //Generate a random speed for blood cell
        float spd = Random.Range(_minSpeed, _maxSpeed);

        return spd;
    }

    private void TravelInDirection()
    {
        _rb2d.velocity = _travelVec;
    }

    private void GenerateTravelVector()
    {
        _speed = GenerateSpeed();
        _direction = GenerateDirection();

        _travelVec = new Vector2(_direction.x * _speed, _direction.y * _speed);
    }

    private void Update()
    {
        TravelInDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            //Regenerate travel vector
            GenerateTravelVector();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player destroyed invader cell!");

            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            //Regenerate travel vector
            GenerateTravelVector();
        }
    }
}
