using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 startPos;
    public Vector3 updatePos;
    public Vector3 screen;
    public RectTransform joystickBG;
    public RectTransform joystickController;
    public GameObject panel;
    public float magnitude;

    private Vector3 mousePos => Input.mousePosition - screen / 2;

    private void Awake()
    {
        direction = Vector3.zero;
        screen.x = Screen.width;
        screen.y = Screen.height;
        panel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = mousePos;
            joystickBG.anchoredPosition = startPos;
            panel.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            updatePos = mousePos;
            joystickController.anchoredPosition = Vector3.ClampMagnitude((updatePos - startPos), magnitude) + startPos;
            direction = (updatePos - startPos).normalized;
            direction.z = direction.y;
            direction.y = 0;

        }
        if (Input.GetMouseButtonUp(0))
        {
            panel.SetActive(false);
            direction = Vector3.zero;
        }
    }
    private void OnDisable()
    {
        direction = Vector3.zero;
    }
}
