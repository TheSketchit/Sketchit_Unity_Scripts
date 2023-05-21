using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button[] buttons;
    public AudioSource audioSource;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayButtonClickSound());
        }
    }

    public void PlayButtonClickSound()
    {
        audioSource.Play();
    }
}

