using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public float saniye, dakika;
    [SerializeField] Text sayac;
    [SerializeField] GameObject panel;

    void Start()
    {
        dakika = 2;
        saniye = 59;
        StartCoroutine(geri_say());
    }

    public IEnumerator geri_say()
    {
        while (saniye >= 0)
        {
            if (saniye > 0 && saniye < 10)
            {
                sayac.text = "0" + dakika + ":" + "0" + (int)saniye;
            }
            else
            {
                sayac.text = "0" + dakika + ":" + (int)saniye;
            }
            yield return new WaitForSeconds(1);
            saniye--;

            if (saniye == 0)
            {
                if (dakika == 0 && saniye == 0)
                {
                    break;
                }
                else
                {
                    dakika--;
                    saniye = 59;
                }
            }
        }
        panel.SetActive(true);
    }
}
