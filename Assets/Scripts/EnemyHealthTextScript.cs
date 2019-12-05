using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthTextScript : MonoBehaviour
{
    public Text healthText;
    public GameObject Holder;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
         healthText.text = Holder.GetComponent<EnemyController>().health.ToString() + "hp";
    }
}
