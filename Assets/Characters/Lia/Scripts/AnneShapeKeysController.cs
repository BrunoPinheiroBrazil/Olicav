using System.Collections;
using UnityEngine;

public class AnneShapeKeysController : MonoBehaviour
{
  #region Variaveis de controle para piscar os olhos
  public string meshName = "";
  private bool blnControlePiscar = false;
  private float dblPesoPiscar = 0.0f;
  private float dblVelPiscar = 11.0f;
  #endregion

  #region Variaveis de controle para a fala
  private bool terminaFala = false;
  private float dblVelFalar = 11.0f;
  private float dblPesoFalar = 0.0f;
  private bool blnControleFalar = false;
  #endregion

  private SkinnedMeshRenderer characterMesh;
  private int blendFala;

  void Start()
  {
    LoadInstances();
  }

  private void OnBecameVisible()
  {
    Debug.Log("Visivel");
    enabled = true;
  }

  private void OnBecameInvisible()
  {
    Debug.Log("Invisivel");
    enabled = false;
  }

  private void LoadInstances()
  {
    characterMesh = GameObject.Find(meshName).GetComponent<SkinnedMeshRenderer>();
    if (characterMesh != null)
    {
      StartCoroutine("BlinkTimeCounter");
    }
  }

  void FixedUpdate()
  {
    if (characterMesh.isVisible)
    {
      BlinkControl();
      SpeakControl();
    }
  }

  private void SpeakControl()
  {
    if (blnControleFalar && dblPesoFalar < 100.00f)
    {
      dblPesoFalar += dblVelFalar * Time.deltaTime * 100.0f;
      characterMesh.SetBlendShapeWeight(blendFala, dblPesoFalar);
      if (dblPesoFalar >= 100.0f)
      {
        dblPesoFalar = 100.0f;
        blnControleFalar = false;
      }
    }
    else if (dblPesoFalar > 0.0f)
    {
      dblPesoFalar -= dblVelFalar * Time.deltaTime * 100.0f;
      if (dblPesoFalar <= 0.0f)
      {
        dblPesoFalar = 0.0f;
        var range = UnityEngine.Random.Range(0, 1);

        if (range == 0)
          range = 5;

        blendFala = range;
      }
      characterMesh.SetBlendShapeWeight(blendFala, dblPesoFalar);
    }
  }

  private IEnumerator controleFala()
  {
    while (true)
    {
      var tempoEsperay = Random.Range(0.5f, 0.2f);
      yield return new WaitForSeconds(tempoEsperay);

      if (!blnControleFalar)
      {
        blnControleFalar = true;
      }

      if (terminaFala)
      {
        characterMesh.SetBlendShapeWeight(1, 0.0f);
        break;
      }
    }
  }

  private IEnumerator BlinkTimeCounter()
  {
    while (true)
    {
      var waitTime = Random.Range(5.0f, 15.0f);
      yield return new WaitForSeconds(waitTime);
      blnControlePiscar = true;
    }
  }

  private void BlinkControl()
  {
    if (blnControlePiscar && dblPesoPiscar < 100.00f)
    {
      dblPesoPiscar += dblVelPiscar * Time.deltaTime * 100.0f;
      characterMesh.SetBlendShapeWeight(0, dblPesoPiscar);
      if (dblPesoPiscar >= 100.0f)
      {
        dblPesoPiscar = 100.0f;
        blnControlePiscar = false;
      }
    }
    else if (dblPesoPiscar > 0.0f)
    {
      dblPesoPiscar -= dblVelPiscar * Time.deltaTime * 100.0f;
      if (dblPesoPiscar < 0.0f)
      {
        dblPesoPiscar = 0.0f;
      }
      characterMesh.SetBlendShapeWeight(0, dblPesoPiscar);
    }
  }

  public void AnneFalando(bool falando)
  {
    terminaFala = !falando;
    StartCoroutine("controleFala");
  }
}
