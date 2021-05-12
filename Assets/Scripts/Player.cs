using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    RaycastHit hit;
    GameObject other;
    public Slider slider;
    public Text score;
    private int sc = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        //Создаем рейкаст и привязываем его к камере и передаем координаты мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            other = hit.collider.gameObject;
            if (other.tag == "Balloon")
            {
                sc++;
                slider.value += other.GetComponentInParent<Balloon>().he;
                other.GetComponentInParent<Balloon>().boom();
                other.tag = "Untagged";


            }
            score.text = "" + sc.ToString();
        }

    }
}
