using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableName : MonoBehaviour
{
    public string Vegetable;
    // Start is called before the first frame update
    void Start()
    {
        Vegetable=transform.Find("Name").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
