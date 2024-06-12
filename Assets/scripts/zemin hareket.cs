using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminhareket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //zemini sola doğru hareket ettirme 17.5 birim sonra 10 saniye duracak ve tekrar sola doğru hareket edecek
        if (transform.position.x < 17.5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
        else
        {
            StartCoroutine(bekle());
        }
    }
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(10);
        transform.position = new Vector3(-17.5f, 0, 0);
    }

}
