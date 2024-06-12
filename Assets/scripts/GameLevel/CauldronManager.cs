using System.Collections.Generic;
using UnityEngine;

public class CauldronManager : MonoBehaviour
{
    public List<GameObject> kazanlar;

    public void CheckCauldron(int toplamSayi)
    {
        foreach (var kazan in kazanlar)
        {
            KazanController kazanController = kazan.GetComponent<KazanController>();
            if (kazanController != null && kazanController.KontrolEt(toplamSayi))
            {
                kazanController.TekmeAt();
            }
        }
    }
}