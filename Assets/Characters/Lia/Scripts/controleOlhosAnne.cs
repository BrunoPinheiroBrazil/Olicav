using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleOlhosAnne : MonoBehaviour
{
    private GameObject olhoDir;
    private GameObject olhoEsq;

    private GameObject trajetoVisao;

    // Start is called before the first frame update
    void Start()
    {
        olhoDir = GameObject.Find("OlhoDir 1");
        olhoEsq = GameObject.Find("OlhoEsq 1");

        trajetoVisao = GameObject.Find("trajetoVisao");

        StartCoroutine("controleOlhos");
    }

    private IEnumerator controleOlhos()
    {
        float tempo = 0.0f;
        float x, y, z;

        while (true)
        {
            yield return new WaitForEndOfFrame();
            tempo = Random.Range(1.0f, 4.0f);
            x = Random.Range(0.0f, 3.0f);
            y = Random.Range(0.0f, 3.0f);
            z = trajetoVisao.transform.position.z;
            trajetoVisao.transform.localPosition = new Vector3(x, y, z);
            olhoDir.transform.LookAt(trajetoVisao.transform);
            olhoEsq.transform.LookAt(trajetoVisao.transform);
            yield return new WaitForSecondsRealtime(tempo);
        }
        
    }
}
