using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dusman : MonoBehaviour
{
    public GameObject boomEffect;
    public GameObject EnemyGun;

    public Image dusman_bari;

    float can = 100.0f;
    float simdiki_can = 100.0f;
    float speed = 1.0f;
    float kursunHizi = 500.0f;
    public Yonet yonet;
    public Transform Oyuncu;
    float ates_etme_araligi = 0.2f;
    float ates_etme_zamani = 0.0f;
     static int score = 0;


    void Update()
    {

        if (Oyuncu)
        {
            if (transform.position.x < Oyuncu.position.x)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (transform.position.x > Oyuncu.position.x)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Oyuncu.position.x - transform.position.x <= 0.2f)
            {
                if (Time.time >= ates_etme_zamani)
                {
                    ates_et();
                    ates_etme_zamani = Time.time + ates_etme_araligi;
                }

            }
        }




    }
    void ates_et()
    {
        GameObject YeniGun = Instantiate(EnemyGun, transform.position, Quaternion.identity);

        YeniGun.GetComponent<Rigidbody2D>().AddForce(Vector2.down * kursunHizi);

        Destroy(YeniGun, 2.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OyuncuGun")
        {
            Destroy(collision.gameObject);
            can_azalt(5.0f);
        }
    }
    void can_azalt(float deger)
    {
        simdiki_can -= deger;
        dusman_bari.fillAmount = simdiki_can / can;
        if (simdiki_can <= 0)
        {
            score++;
            yok_ol();
        }
    }
    void yok_ol()
    {
        
        Destroy(gameObject);
        GameObject newBoom = Instantiate(boomEffect, transform.position, Quaternion.identity);
        Destroy(newBoom, 1.0f);
        
        checkScore();
        


    }
    void checkScore()
    {
        if (SceneManager.GetActiveScene().name.Equals("Section5") && score==1)
        {
            yonet.paneli_goster();
        }
        if (SceneManager.GetActiveScene().name.Equals("Section6") && score >= 2)
        {
            yonet.paneli_goster();
        }


    }
}
