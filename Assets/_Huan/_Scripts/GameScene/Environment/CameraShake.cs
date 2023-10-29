using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    [SerializeField] private Transform mainCam;
    private float shakeDuration;
    private float shakeStrength;
    [SerializeField] private float decrementFactor = 1;

    private Vector3 camOriPosition;
    private bool shaked = false;
    private bool shakeDisabled = false;

    private void Awake()
    {
        Instance = this;

        if (mainCam == null)
            mainCam = Camera.main.transform;

        camOriPosition = mainCam.position;    
    }

    private void Update()
    {
        if (shakeDisabled == true)
            return;

        if (shaked == false)
            return;

        if (shakeDuration > 0)
        {
            mainCam.localPosition = camOriPosition + Random.insideUnitSphere * shakeStrength;

            shakeDuration -= Time.deltaTime * decrementFactor;
        }
        else
        {
            mainCam.localPosition = camOriPosition;

            shaked = false;
        }
    }

    public void Shake(float dur, float str)
    {
        shakeDuration = dur;
        shakeStrength = str;

        shaked = true;
    }

    public void SetShakable(bool value)
    {
        shakeDisabled = !value;
    }
}
