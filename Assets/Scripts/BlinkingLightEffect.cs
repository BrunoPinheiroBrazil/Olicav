using System.Collections;
using UnityEngine;

public class BlinkingLightEffect : MonoBehaviour
{
  Light myLight;

  private void Start()
  {
    myLight = GetComponent<Light>();
  }

  private void Update()
  {
    myLight.intensity = Mathf.PingPong(Time.time, 8);
  }
}
