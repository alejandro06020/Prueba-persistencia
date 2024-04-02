using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SButton : MonoBehaviour
{
    private Button boton;
    private void Awake()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(CargarTodo);
    }

    private void CargarTodo()
    {
        DataPlayer.instance.SaveName();
        DataPlayer.instance.ChangeScene();
        Debug.Log("Se presiono el boton");
    }
}
