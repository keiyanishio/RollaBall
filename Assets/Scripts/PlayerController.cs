using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float Health;
    [SerializeField] private float nowHealth;

    public float threshold;

    public GameOver GameOverScreen;
    public YouWin YouWinScreen;

    public float speed = 0;
    public TextMeshProUGUI countText;
    

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    

    public void YouWin()
    {
        YouWinScreen.Setup(count);
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    // Start is called before the first frame update
    void Start()
    {

        nowHealth = Health;
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

        if(count >= 12)
        {
            
            YouWin();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        
    }

    public void TakeDamage(float Damage)
    {
        nowHealth -= Damage;

        if (nowHealth <= 0)
        {
            GameOver();
        }
    }

}
