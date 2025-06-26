using UnityEngine;
using UnityEngine.UI;

// Скрипт керує глобальною гучністю через Slider і зберігає налаштування
public class VolumeControl : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("Перетягни сюди UI-повзунок зі сцени")]
    public Slider volumeSlider;

    // Ключ для PlayerPrefs
    private const string VolumeKey = "MasterVolume";

    // Початкова ініціалізація
    private void Start()
    {
        // Якщо повзунок не призначений – спробувати знайти перший Slider у сцені
        if (volumeSlider == null)
        {
            volumeSlider = FindObjectOfType<Slider>();
            if (volumeSlider == null)
            {
                Debug.LogWarning("VolumeControl: Slider не знайдено!");
                return;
            }
        }

        // Отримати збережене значення або взяти поточну гучність, якщо ключа немає
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, AudioListener.volume);

        // Синхронізувати Slider ↔ AudioListener
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Додати слухача на зміну значення повзунка
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Викликається щоразу, коли користувач рухає повзунок
    private void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);   // Зберегти налаштування
    }

    private void Update()
    {
        // Швидке вимкнення/увімкнення звуку клавішею M (Mute)
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isMuted = AudioListener.volume == 0f;

            // Якщо вже вимкнено – повертаємо попередній рівень, інакше вимикаємо
            AudioListener.volume = isMuted ? volumeSlider.value : 0f;

            // Оновити повзунок лише коли вмикаємо звук назад
            if (isMuted) volumeSlider.value = AudioListener.volume;

            // Зафіксувати зміну
            PlayerPrefs.SetFloat(VolumeKey, AudioListener.volume);
        }
    }
}
