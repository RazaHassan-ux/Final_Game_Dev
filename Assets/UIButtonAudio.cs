using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonAudio : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource audioSource;

    public void OnSelect(BaseEventData eventData)
    {
        audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
