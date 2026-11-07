using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";
    [SerializeField]
    private Rigidbody2D _rb2d;
    [SerializeField]
    private float _speed = 3f;
    private Vector2 _input;

    public UnityEvent OnPlayerDie;

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = _input * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _input = new Vector2(horizontalInput, verticalInput);
        _input.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(OnPlayerDie != null){
            OnPlayerDie.Invoke();
        }
        Destroy(gameObject);
    }

}
