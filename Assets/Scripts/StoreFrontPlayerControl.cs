using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoreFrontPlayerControl : MonoBehaviour
{

    public float moveSpeed = 2;
    public float jumpForce = 5;
    public GameObject groundCheck = null;
    public GameObject leftCollide = null;
    public GameObject rightCollide = null;

    private Vector2 direction;

    // Level Specific Triggers
    public GameObject triggerCollide = null;
    public GameObject triggerUI = null;
    public GameObject teleport = null;
    public bool triggered = false;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void Update()
    {
        //Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);

        //if (Physics2D.Linecast(groundCheck.transform.position, transform.position))
        //{
        //    RaycastHit2D hitPlatform = Physics2D.Linecast(groundCheck.transform.position, transform.position);
        //    Debug.Log("TOUCHING " + hitPlatform.collider.name);
        //}

        if (GetCollision(leftCollide) == triggerCollide.name || GetCollision(rightCollide) == triggerCollide.name)
        {
            triggerUI.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !(triggered))
            {
                
                teleport.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                triggered = true;

            }
        } else
        {
            triggerUI.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right, transform.position);
            Debug.DrawLine(transform.position + transform.right, transform.position, Color.yellow);

            if (hit.collider != null && hit.collider.tag == "Character")
            {
                WhosTalking hitCharacter = hit.collider.GetComponent<WhosTalking>();

                if (hitCharacter)
                {
                    hitCharacter.startTalking();
                }
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("interact", true);
        }
        else
        {
            anim.SetBool("interact", false);
        }

        if (GetCollision(leftCollide) == teleport.name || GetCollision(rightCollide) == teleport.name)
        {
            SceneManager.LoadScene("mini_1");
        }

            if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }

        if (transform.position.y < -10)
        {
            transform.position = new Vector2(0, 0);
        }

        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }

    private string GetCollision(GameObject reference)
    {
        RaycastHit2D hitPlatform = Physics2D.Linecast(reference.transform.position, transform.position);
        return hitPlatform.collider.name;
    }

    private bool returnInteract()
    {
        return true;
    }
}
