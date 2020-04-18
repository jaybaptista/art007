using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 2;
    public float jumpForce = 5;

    public bool grounded = true;

    public GameObject groundCheck = null;
    public GameObject footCollide = null;
    public GameObject topCollide = null;

    public GameObject interactUI;

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

        if (GetCollision(footCollide) != null && GetCollision(footCollide).gameObject.tag == "Interactable")
        {
            GetCollision(footCollide).gameObject.GetComponent<Interactable>().InProximity();
            if (Input.GetKey(KeyCode.E))
            {
                GetCollision(footCollide).gameObject.GetComponent<Interactable>().Interact();
            }
            
        } else if (GetCollision(topCollide) != null && GetCollision(topCollide).gameObject.tag == "Interactable")
        {
            GetCollision(topCollide).gameObject.GetComponent<Interactable>().InProximity();
            if (Input.GetKey(KeyCode.E))
            {
                GetCollision(topCollide).gameObject.GetComponent<Interactable>().Interact();
            }

         } else
        {
            interactUI.SetActive(false);
        }

        // Dialog Interact

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right, transform.position);
            Debug.DrawLine(transform.position + (transform.right * .2f), transform.position, Color.yellow);

            if (hit.collider != null && hit.collider.tag == "Character")
            {
                WhosTalking hitCharacter = hit.collider.GetComponent<WhosTalking>();

                if (hitCharacter)
                {
                    hitCharacter.startTalking();
                }
            }
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

        if (Input.GetKeyDown(KeyCode.W) && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }

        if (transform.position.y < -10)
        {
            transform.position = new Vector2(0, 0);
        }

        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    

    private Collider2D GetCollision(GameObject reference)
    {
        RaycastHit2D hitPlatform = Physics2D.Linecast(reference.transform.position, transform.position);
        return hitPlatform.collider;
    }
}
