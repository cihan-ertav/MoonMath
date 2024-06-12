using UnityEngine;

public class KazanController : MonoBehaviour
{
    [SerializeField] private int hedefSayi;

    public bool KontrolEt(int toplamSayi)
    {
        return toplamSayi == hedefSayi;
    }

    public void TekmeAt()
    {
        Debug.Log("Kazana tekme atıldı! Hedef sayıya ulaşıldı: " + hedefSayi);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(new Vector2(500, 0)); // Sağ tarafa doğru kuvvet uygula
        }
    }
}