using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform SegmentPerfab;
    public int initialSize = 4;
    private Vector2 _nextDirection = Vector2.right;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _nextDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
        {
            _nextDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
        {
            _nextDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
        {
            _nextDirection = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        _direction = _nextDirection; // Burada yönü güncelliyoruz

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.SegmentPerfab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        GameManager.Instance.AddScore(10);

    }
    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i< this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.SegmentPerfab));
        }

        this.transform.position = Vector3.zero;
        GameManager.Instance.ResetScore();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            

            // Game Over panelini aç
            FindObjectOfType<GameOverManager>().ShowGameOver();

            // Yılanı durdurmak için kendini devre dışı bırak
            this.enabled = false;
        }
    }

}
