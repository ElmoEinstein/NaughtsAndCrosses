using System.Collections;
using UnityEngine;
using Cinemachine;
public class Shake : MonoBehaviour
{

    CinemachineVirtualCamera cmvc;
    float timer;
    private void Start()
    {
        cmvc = GetComponent<CinemachineVirtualCamera>();
        ButtonPosInGrid.shakeScreen += ShakeCam;
    }

    private void OnDestroy()
    {
        ButtonPosInGrid.shakeScreen -= ShakeCam;
    }
    

    

    void ShakeCam(float _intensity, float _time)
    {
        CinemachineBasicMultiChannelPerlin _cmmcp = cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cmmcp.m_AmplitudeGain = _intensity;
        timer = _time;
        Debug.Log("sajh");

    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
           if(timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin _cmmcp = cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cmmcp.m_AmplitudeGain = 0f;
            }

        }

    }
}
