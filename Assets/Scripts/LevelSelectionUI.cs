using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    public Transform parent;
    public GameObject levelButton;
    
    private void Start()
    {
        foreach (var level in LevelSelect.Instance.levelList)
        {
            GameObject newLevelObj = Instantiate(levelButton, parent);
            newLevelObj.GetComponent<Button>().onClick.AddListener(
                () => LevelSelect.Instance.LoadLevel(level.levelNumber));
            Text[] buttonTexts = newLevelObj.GetComponentsInChildren<Text>();
            Debug.Log(level.IsCleared);
            foreach (var text in buttonTexts)
            {
                if (text.gameObject.name == "Number")
                {
                    text.text = level.levelNumber.ToString();
                }
                else
                {
                    text.gameObject.SetActive(level.IsCleared);
                }
            }
        }
        
    }
}
