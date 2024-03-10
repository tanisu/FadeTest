using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    SpriteRenderer sp;
    [SerializeField] Button fadeButton;
    float duration = 1f;
    Color spriteColor;
    bool isFadingOut,isFading;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        spriteColor = sp.color;
        //StartCoroutine(Fade(1));
        fadeButton.onClick.AddListener(()=> ToggleFade());
    }

    void ToggleFade()
    {
        if (isFading) return;
     //   StopAllCoroutines();
        StartCoroutine(Fade(isFadingOut ? 1:0));
        isFadingOut = !isFadingOut;
    }

    IEnumerator Fade(float targetAlpha)
    {
        isFading = true;
        fadeButton.interactable = false;
        while (!Mathf.Approximately(spriteColor.a, targetAlpha))
        {
            float changePerFrame = Time.deltaTime / duration;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
            sp.color = spriteColor;
            yield return null;
        }
        isFading = false;
        fadeButton.interactable = true;
    }
}
