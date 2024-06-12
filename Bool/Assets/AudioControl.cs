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
        // Добавление компонента Audio Source
        audioSource = GetComponent<AudioSource>();
        // Назначение аудиоклипа
        audioSource.clip = audioClip;
        // Настройка параметров
        audioSource.volume = 0.5f; // Начальная громкость
        audioSource.pitch = 1.0f;
        audioSource.loop = true;

        // Воспроизведение звука
        audioSource.Play();

        // Установка начального значения слайдера и добавление слушателя
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
