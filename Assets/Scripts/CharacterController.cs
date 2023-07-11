using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded;
    private bool _started;
    private bool _jumping;
    private int _lives = 3;
    public TextMeshProUGUI _livesText;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _started = false;
        _isGrounded = true;
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (_started && _isGrounded)
            {
                _animator.SetTrigger("jump");
                _isGrounded = false;
                _jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                _started = true;
            }
        }

        _animator.SetBool("grounded", _isGrounded);

    }
    private void FixedUpdate()
    {
        if (_started)
        {
            _rigidbody.velocity = new Vector2(speed*2f, _rigidbody.velocity.y);
        }
        if (_jumping)
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce*2f));
            _jumping = false;
        }
    }
    private void NormalJumpForce()
    {
        _rigidbody.AddForce(transform.up*0, ForceMode2D.Impulse);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("maplimit"))
        {
            SceneManager.LoadScene(5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("powerupjump"))
        {
            _rigidbody.AddForce(transform.up * 10f, ForceMode2D.Impulse);
            Invoke("NormalJumpForce", 2f);
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            _lives--;
            _livesText.text = "" + _lives;
            if(_lives==0)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
