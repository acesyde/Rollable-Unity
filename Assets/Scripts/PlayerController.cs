using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 0f;
    public TextMeshProUGUI CountText;
    public GameObject WinText;
    
    private Rigidbody _rigidbody;
    
    private float _movementX;
    private float _movementY;
    private int _count;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        _rigidbody.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        CountText.text = $"Count : {_count}";
        if (_count >= 12)
        {
            WinText.SetActive(true);
        }
    }
}
