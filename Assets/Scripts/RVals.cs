using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RVals : MonoBehaviour
{
    [SerializeField] private TMP_InputField text;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    private void Start()
    {
        if(DataPlayer.instance != null)
        {
            DataPlayer.instance.textMeshProUGUI = textMeshPro;
            DataPlayer.instance.namePlayer = text;
            DataPlayer.instance.textMeshProUGUI.text = DataPlayer.instance.playerName + " last score " + DataPlayer.instance.scorePalyer;
        }
    }

    
}
