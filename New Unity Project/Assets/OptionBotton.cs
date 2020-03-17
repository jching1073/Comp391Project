using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBotton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Option").GetComponentInChildren<Text>().text = "Option";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
