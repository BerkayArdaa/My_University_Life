using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yonet : MonoBehaviour
{
    public GameObject bitti_png;
    public GameObject Oyuncu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void paneli_goster()
    {
        
        bitti_png.SetActive(true);


        Invoke("durdur", 1.0f);



     
    }
    void durdur()
    {

        Time.timeScale = 0.0f;
    }
    public void tekrar_Oyna()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Section5");

    }
    public void ilerle()
    {
        Time.timeScale = 1.0f;
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
