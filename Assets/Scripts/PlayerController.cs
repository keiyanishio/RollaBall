using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public int Health;
    [SerializeField] private int nowHealth;

    public float threshold;

    public GameOver GameOverScreen;
    public YouWin YouWinScreen;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI lifeText;


    private Rigidbody rb;
    private int count;
    private int life;
    private float movementX;
    private float movementY;
    private int played;

    AudioManagers audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagers>();
    }

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
        life = 5;
        played = 0;
        SetCountText();
        SetLifeText();
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

        if(count >= 16)
        {
            audioManager.PlaySFX(audioManager.win);
            played = 1;
            YouWin();

        }
    }

    void SetLifeText()
    {
        lifeText.text = "Life: " + life.ToString();

        if(life <= 2)
        {
            lifeText.color = Color.red;
        }

        if (life == 0)
        {

            GameOver();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            life -= 1;
            SetLifeText();
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

            audioManager.PlaySFX(audioManager.item);

            SetCountText();
        }
        
    }

    public void TakeDamage(int Damage)
    {
        if (played == 0) {
            nowHealth -= Damage;
            life -= 1;
            audioManager.PlaySFX(audioManager.damage);
            SetLifeText();
        }
            

        if (nowHealth <= 0)
        {
            GameOver();
            if (played == 0)
            {
                audioManager.PlaySFX(audioManager.lost);
                played = 1;
            }
        }
    }

}
