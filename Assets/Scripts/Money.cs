using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public float money;
    TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"Total Money: ${money}";
    }
}
