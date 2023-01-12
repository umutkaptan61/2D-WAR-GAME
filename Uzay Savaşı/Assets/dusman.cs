using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dusman : MonoBehaviour
{

    public Transform oyuncu;

    public GameObject patlama_efekti;
    public GameObject dusman_kursunu;
    public Image dusman_can_bari;
    public yonetici yonet;

    float can = 100f;
    float simdiki_can = 100f;

    float hareket_hizi = 3.0f;
    float kursun_hizi = 500f;

    float ates_etme_araligi = 0.2f;
    float ates_etme_zamani= 0.0f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "oyuncu_kursunu")
        {
            Destroy(collision.gameObject);
            can_azalt(5f);
        }
    }

    void can_azalt(float deger)
    {
        simdiki_can -= deger;
        dusman_can_bari.fillAmount = simdiki_can / can;

        if (simdiki_can <= 0)
        {
            yok_ol();
        }

    }

    void yok_ol()
    {
        Destroy(gameObject);

        GameObject yeni_patlama = Instantiate(patlama_efekti, transform.position, Quaternion.identity);

        Destroy(yeni_patlama, 1f);

        yonet.paneli_goster();
    }


    void ates_et()
    {
        GameObject yeni_kursun = Instantiate(dusman_kursunu, transform.position, Quaternion.identity);
        yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.down * kursun_hizi);

        Destroy(yeni_kursun, 2f);
    }





    void Update()
    {
        if (oyuncu)      
              
        {
        
        if (transform.position.x < oyuncu.position.x)
        {
            transform.Translate(hareket_hizi * Time.deltaTime, 0, 0);
        }

        if (transform.position.x > oyuncu.position.x)
        {
            transform.Translate(-hareket_hizi * Time.deltaTime, 0, 0);
        }


        if (Mathf.Abs(oyuncu.position.x - transform.position.x) <= 0.2f)
        {
            if (Time.time >= ates_etme_zamani)
            {
                ates_et();
                ates_etme_zamani = Time.time + ates_etme_araligi;
            }
            
        }

        }
    }


}
