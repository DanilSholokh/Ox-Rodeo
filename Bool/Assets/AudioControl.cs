using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioClip audioClip;
    public Slider volumeSlider;
    private AudioSource audioSource;

    void Start()
    {
        // ���������� ���������� Audio Source
        audioSource = GetComponent<AudioSource>();
        // ���������� ����������
        audioSource.clip = audioClip;
        // ��������� ����������
        audioSource.volume = 0.5f; // ��������� ���������
        audioSource.pitch = 1.0f;
        audioSource.loop = true;

        // ��������������� �����
        audioSource.Play();

        // ��������� ���������� �������� �������� � ���������� ���������
        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }
    }

    void OnVolumeSliderChanged(float value)
    {
        audioSource.volume = value;
    }


}
