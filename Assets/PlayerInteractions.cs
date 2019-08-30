using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public Color color;
    public float interactionDistance = 3f;
    private Collider2D[] collider2D;
    private GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        collider2D = Physics2D.OverlapCircleAll(transform.position, interactionDistance,mask);
        if(currentObject!=collider2D[0])
        {
            if(currentObject!=null)
            {
                currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
            }
            currentObject = collider2D[0].gameObject;
            currentObject.GetComponent<Outline>().effectColor = color;
            currentObject.GetComponent<Outline>().effectDistance = new Vector2(7, 7);
        }
        Debug.Log(collider2D[0]);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(currentObject!=null)
        {
            currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
        }
    }
}
