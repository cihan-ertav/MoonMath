using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManeger : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ikinciMenuyeGec()
    {
        SceneManager.LoadScene("ikinciMenu");
    }
    
    public void ayarlarMenuyeGec()
    {
        SceneManager.LoadScene("ayarlarMenu"); 
       
    }
    
    public void cikis()
    {
        Application.Quit();
    }
}
