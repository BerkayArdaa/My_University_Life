using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{
    bool isDeath=false;
    public GameObject boomEffect;
    public GameObject PlayerGun;
    
    public Image oyuncu_bari;

    float can = 100.0f;
    float simdiki_can = 100.0f;
    float speed = 5.0f;
    float kursunHizi = 500.0f;
    public Yonet yonet;
    
    

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        float tus = Input.GetAxis("Horizontal");
        transform.Translate(tus * Time.deltaTime * speed, 0, 0);


        if(Input.GetKeyDown(KeyCode.Space)) {
            ates_et();
        }

        
    }
    void ates_et()
    {
        GameObject YeniGun =Instantiate(PlayerGun, transform.position,Quaternion.identity);

        YeniGun.GetComponent<Rigidbody2D>().AddForce(Vector2.up*kursunHizi);
        
        Destroy(YeniGun,2.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enem")
        {
            Destroy(collision.gameObject);
            can_azalt(10.0f);
        }
    }
    void can_azalt(float deger)
    {
        simdiki_can -= deger;
        oyuncu_bari.fillAmount = simdiki_can / can;
    if(simdiki_can<=0)
        {
            isDeath = true;
            yok_ol();
        }
    }
    void yok_ol()
    {
        Destroy(gameObject);
        GameObject newBoom=Instantiate(boomEffect, transform.position, Quaternion.identity);
        Destroy(newBoom, 1.0f);
        yonet.paneli_goster_second();

    }
}

