using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public Button startButton;

    public static object main { get; internal set; }

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        LoadScene();
    }

    void Update()
    {
        transform.Rotate(Vector3.down, 5.0f * Time.deltaTime);
        transform.Rotate(Vector3.forward, 5.0f * Time.deltaTime);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
