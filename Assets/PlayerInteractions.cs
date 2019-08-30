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
    private TextMesh vegetables;
    private string[] vegetablenames;
    // Start is called before the first frame update
    void Start()
    {
        vegetablenames = new string[2];
        vegetables = transform.Find("Vegetables").GetComponent<TextMesh>();
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
    public void OnInteract()
    {
        if(currentObject!=null)
        {
            if(currentObject.tag=="Vegetable")
            {
                string name = currentObject.GetComponent<VegetableName>().Vegetable;
                if(vegetablenames[0]==null)
                {
                    vegetablenames[0] = name;
                    vegetables.text =vegetablenames[0];
                }
                else if(vegetablenames[1]==null)
                    {
                    vegetablenames[1] = name;
                    vegetables.text = vegetablenames[0] + "," + vegetablenames[1];
                }
                Debug.Log(name);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        LayerMask mask = LayerMask.GetMask("Interactable");
        collider2D = Physics2D.OverlapCircleAll(transform.position, interactionDistance,mask);
        if (collider2D.Length > 0)
        {
            if (currentObject != collider2D[0])
            {
                if (currentObject != null)
                {
                    currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
                }
                currentObject = collider2D[0].gameObject;
                currentObject.GetComponent<Outline>().effectColor = color;
                currentObject.GetComponent<Outline>().effectDistance = new Vector2(7, 7);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(currentObject!=null)
        {
            currentObject.GetComponent<Outline>().effectDistance = Vector2.zero;
        }
    }
}
