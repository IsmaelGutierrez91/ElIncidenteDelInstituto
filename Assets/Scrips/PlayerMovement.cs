using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    bool crouch;
    public float stamina;
    public float qurrentStamina;
    public int keyRange;
    bool isRunning;
    SpriteRenderer _ComponentSpriteRenderer;
    Animator _ComponentAnimator;
    Rigidbody2D _ComponentRigidbody2D;
    float horizontal;
    public int playerMaxLife;
    public int playerQurrentLife;
    public float playerSpeed;
    public bool canDie = true;
    public HealtObjectController healtObject;
    private void Awake()
    {
        _ComponentSpriteRenderer = GetComponent<SpriteRenderer>();
        _ComponentRigidbody2D = GetComponent<Rigidbody2D>();
        _ComponentAnimator = GetComponent<Animator>();
        playerQurrentLife = playerMaxLife;
    }
    void Update()
    {
        _ComponentAnimator.SetInteger("walking", (int)horizontal);
        _ComponentAnimator.SetBool("Running", isRunning);
        _ComponentAnimator.SetBool("Crouch", crouch);
        if (Input.GetKeyDown(KeyCode.C))
        {
            crouch = true;
            _ComponentRigidbody2D.velocity = new Vector2(0, -1);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            crouch = false;
        }
        if (horizontal > 0)
        {
            _ComponentSpriteRenderer.flipX = false;
        }
        if (horizontal < 0)
        {
            _ComponentSpriteRenderer.flipX = true;
        }
        if (playerQurrentLife > playerMaxLife)
        {
            playerQurrentLife = playerMaxLife;
        }
        if (Input.GetKeyDown(KeyCode.Z) && qurrentStamina > 0 && horizontal != 0 && crouch == false)
        {
            isRunning = true;
            playerSpeed = 9;
        }
        if (Input.GetKeyUp(KeyCode.Z) || qurrentStamina <= 0)
        {
            isRunning = false;
            playerSpeed = 4;
        }
        if (isRunning == true)
        {
            qurrentStamina = qurrentStamina - Time.deltaTime;
        }
        if (horizontal == 0 && isRunning == false)
        {
            qurrentStamina = qurrentStamina + Time.deltaTime;
        }
        if (qurrentStamina > stamina)
        {
            qurrentStamina = stamina;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (playerQurrentLife <= 0)
        {
            SceneManager.LoadScene("screenLose");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && canDie == true)
        {
            playerQurrentLife = 0;
        }
        if (collision.gameObject.tag == "ObjectToHide")
        {
            canDie = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ObjectToHide")
        {
            canDie = true;
        }
        if (collision.gameObject.tag == "TutorialObjectToHide")
        {
            canDie = true;
        }
        if (collision.gameObject.tag == "CrouchToHide")
        {
            canDie = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealtObject" && Input.GetKeyDown(KeyCode.X))
        {
            playerQurrentLife = healtObject.PlayerHeald(playerQurrentLife);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "CrouchToHide" && crouch == true)
        {
            canDie = false;
        }
        if (collision.gameObject.tag == "CrouchToHide" && crouch == false)
        {
            canDie = true;
        }
    }
    private void FixedUpdate()
    {
        if (crouch == false)
        {
            _ComponentRigidbody2D.velocity = new Vector2(horizontal * playerSpeed, -1);
        }
    }
}
