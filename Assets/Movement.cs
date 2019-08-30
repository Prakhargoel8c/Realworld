using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode interactionKey;
    private Vector2 playerDirection;
    private bool playerTryingToInteract;
    private Rigidbody2D rigidbody;
    private Vector3 oldposition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        oldposition = (transform.position);
        playerDirection = Vector2.zero;
        if (Input.GetKey(left)) playerDirection.x -= 1;
        if (Input.GetKey(right)) playerDirection.x += 1;
        if (Input.GetKey(forward)) playerDirection.y += 1;
        if (Input.GetKey(backward)) playerDirection.y -= 1;
        if (Input.GetKey(interactionKey)) playerTryingToInteract = true;
        rigidbody.velocity = playerDirection*GameConstants.MovementOffset;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}
