using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] private Button _toggleMenuButton;
    [SerializeField] private GameObject _panel;
    private bool _showPanel;
    
    //FPS
    [SerializeField] private TMP_Text _fpsCounter;
    [SerializeField] private Button _toggleFpsButton;
    private float _avgFPS;
    private WaitForSecondsRealtime waitForFrequency;
    public float FpsSmoothSpeed = 300;
    private bool _fpsLook;

    private void Start()
    {
        _toggleMenuButton.onClick.AddListener(TogglePanel);
        _toggleFpsButton.onClick.AddListener(ToggleFps);
    }

    private void Update()
    {
        _panel.SetActive(_showPanel);
        //FPS
        if (!_fpsLook)
            FPSCount(_fpsCounter);
    }

    private void FPSCount(TMP_Text tmpText)
    {
        float fps, smoothFps = 0;
        fps = 1f / Time.smoothDeltaTime;
        if(Time.timeSinceLevelLoad < 0.1f) 
            smoothFps = fps;
        smoothFps += (fps - smoothFps) * Mathf.Clamp(Time.deltaTime * FpsSmoothSpeed, 0, 1);
        // float currentFPS;
        // currentFPS = (int)(1f / Time.unscaledDeltaTime);
        // _avgFPS = (int)currentFPS;
        _avgFPS = smoothFps;
        tmpText.text = "FPS: " + _avgFPS.ToString();
        if (_avgFPS > 60)
            tmpText.color = new Color(0,1,0.212f);
        if (_avgFPS < 60 && _avgFPS > 45)
            tmpText.color = new Color(0,0.522f,0.11f);
        if (_avgFPS < 45 && _avgFPS > 30)
            tmpText.color = Color.yellow;
        if (_avgFPS < 30)
            tmpText.color = Color.red;
    }

    private void TogglePanel()
    {
        _showPanel = !_showPanel;
    }

    private void ToggleFps()
    {
        _fpsLook = !_fpsLook;
    }
}
