using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public ParticleSystem ps;
    public Slider slider;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            ps.Play();
            slider.value -= 0.4f;
        }
    }


}
