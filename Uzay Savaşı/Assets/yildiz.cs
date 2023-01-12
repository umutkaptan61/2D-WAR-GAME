using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildiz : MonoBehaviour
{
    SpriteRenderer gorunurluk;
    void Start()
    {

        gorunurluk = GetComponent<SpriteRenderer>();

        float rast_gele = Random.Range(0.01f, 0.03f);

        transform.localScale = new Vector3(rast_gele, rast_gele, 1f);

        if (rast_gele > 0.02 )
        {
            gorunurluk.enabled = false;
        }

        InvokeRepeating("gorunurluk_degistir", 0f, 1f);
    }


    void gorunurluk_degistir()
    {
        gorunurluk.enabled = !gorunurluk.enabled;
    }
    
}
