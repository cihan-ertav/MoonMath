using System.Collections;
using TMPro;
using UnityEngine;

public class MergeCharacters : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    public GameObject characterprefab;

    [SerializeField] private TextMeshProUGUI sayiText;
    [SerializeField] private TextMeshProUGUI sayiText1;
    [SerializeField] private TextMeshProUGUI sayiText2;
    [SerializeField] private TextMeshProUGUI sayiText3;
    [SerializeField] private TextMeshProUGUI sayiText4;
    [SerializeField] private TextMeshProUGUI sayiText5;
    [SerializeField] private TextMeshProUGUI sayiText6;
    [SerializeField] private TextMeshProUGUI sayiText7;
    [SerializeField] private TextMeshProUGUI sayiText8;
    [SerializeField] private TextMeshProUGUI sayiText9;
    [SerializeField] private TextMeshProUGUI kazanText;
    [SerializeField] private TextMeshProUGUI kazanText1;
    [SerializeField] private TextMeshProUGUI kazanText2;
    [SerializeField] private TextMeshProUGUI kazanText3;
    [SerializeField] private TextMeshProUGUI kazanText4;
    private int sayi;
    private CauldronManager cauldronManager;

    private void Start()
    {
        //RastgeleSayiOlustur();
        cauldronManager = FindObjectOfType<CauldronManager>();
        sayiText.text=Random.Range(1,10).ToString();
        sayiText1.text=Random.Range(1,10).ToString();
        sayiText2.text=Random.Range(1,10).ToString();
        sayiText3.text=Random.Range(1,10).ToString();
        sayiText4.text=Random.Range(1,10).ToString();
        sayiText5.text=Random.Range(1,10).ToString();
        sayiText6.text=Random.Range(1,10).ToString();
        sayiText7.text=Random.Range(1,10).ToString();
        sayiText8.text=Random.Range(1,10).ToString();
        sayiText9.text=Random.Range(1,10).ToString();
        //sayıtextlari int yap
        int sayi0 = int.Parse(sayiText.text);
        int sayi1 = int.Parse(sayiText1.text);
        int sayi2 = int.Parse(sayiText2.text);
        int sayi3 = int.Parse(sayiText3.text);
        int sayi4 = int.Parse(sayiText4.text);
        int sayi5 = int.Parse(sayiText5.text);
        int sayi6 = int.Parse(sayiText6.text);
        int sayi7 = int.Parse(sayiText7.text);
        int sayi8 = int.Parse(sayiText8.text);
        int sayi9 = int.Parse(sayiText9.text);


        kazanText.text = (sayi0 + sayi1).ToString();
        kazanText1.text = (sayi2 + sayi3).ToString();
        kazanText2.text = (sayi4 + sayi5).ToString();
        kazanText3.text = (sayi6 + sayi7).ToString();
        kazanText4.text = (sayi8 + sayi9).ToString();



    }

    private void OnMouseDown()
    {
        isDragging = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(curPosition.x, curPosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))//
        {
MergeCharacters otherCharacter = other.GetComponent<MergeCharacters>();
            if (otherCharacter != null )
            {
                // İki karakteri birleştir
                int toplamSayi = sayi + otherCharacter.sayi;
                if (cauldronManager != null)
                {
                    cauldronManager.CheckCauldron(toplamSayi);
                }
                 
                

                // Karakterleri yok et
                Destroy(other.gameObject);
                Destroy(gameObject);
                //karakterlerden sadece birini yok et diğeri kalacak
                

                // Birleşme efektini oynat
                StartCoroutine(MergeEffect());
            }
            
            
        }
    }

    private IEnumerator MergeEffect()
    {
        Vector3 originalScale = transform.localScale; // Orijinal büyüklük
        Vector3 expandedScale = originalScale * 1.2f; // Genişletilmiş büyüklük
        float duration = 0.5f; // Animasyon süresi

        // Büyüt
        float timer = 0;
        while (timer <= duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, expandedScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Küçült
        timer = 0;
        while (timer <= duration)
        {
            transform.localScale = Vector3.Lerp(expandedScale, originalScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void RastgeleSayiOlustur()
    {
        // Rastgele sayı oluştur ve metni güncelle
        sayi = Random.Range(1, 10);
        if (sayiText != null)
        {
            sayiText.text = sayi.ToString();
        }
        else
        {
            Debug.LogError("sayiText is null!");
        }
    }
}
