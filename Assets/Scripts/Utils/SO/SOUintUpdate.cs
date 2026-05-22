using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUintUpdate : MonoBehaviour
{
    public SOint SoInt;
    public TextMeshProUGUI uiTextValue;


    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = SoInt.Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = SoInt.Value.ToString();
    }
}
