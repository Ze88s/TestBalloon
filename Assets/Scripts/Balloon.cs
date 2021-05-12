using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balloon : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1;
    Vector3 inst;
    public ParticleSystem ps;
    Animation boom_anim;
    public GameObject bomb;


    public float he = 0.1f;//Сколько в шарику гелия


    bool alive = true;//жив шарик или нет

    void Start()
    {
        boom_anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();

        //определяем будет ли бомба на шарику или нет
        if (Random.Range(0, 3) > 0)
            bomb.SetActive(false);
        else bomb.SetActive(true);
    }

    //Если мы лопнули наш шарик
    public void boom()//Если мы лопнули наш шарик
    {
        if (alive)
        {
            //BOMB
            if (bomb.activeSelf)
                bomb.transform.SetParent(null);
            bomb.GetComponent<Rigidbody>().useGravity = true;
            bomb.GetComponent<Rigidbody>().isKinematic = false;
            bomb.tag = "Bomb";
            //Запускаем анимацию взрыва
            boom_anim.Play();
            alive = false;
            ps.Play();


        }

    }
    public void setSpeed(float s)
    {
        speed = s;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //если шарик улетел за єкран то уничтожаем
        if (transform.position.y > 30)
            Destroy(gameObject);
        //если упал(веревочка) тоже уничтожаем
        if (transform.position.y < 0 && alive == false)
            Destroy(gameObject);
        //если живой то поднимаем
        if (alive)
            transform.Translate(0, speed * Time.deltaTime, 0);
        else
        {   //если не живой то после анимации убираем шар и оставляем веревочку которая падает
            if (!boom_anim.isPlaying)
            {

                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                rb.useGravity = true;
                rb.isKinematic = false;
                // Destroy(gameObject);
            }
        }
    }
}
