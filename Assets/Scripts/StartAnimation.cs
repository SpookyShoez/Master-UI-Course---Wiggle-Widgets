using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public RectTransform top;
    public RectTransform bottom;
    public Transform logo;
    public CanvasGroup logoCanvasGroup;
    public Transform presentsText;
    public CanvasGroup presentsTextCanvasGroup;

    
    void Start() {
        AnimationSeq();
    }

    void AnimationSeq () {
        // 1. Initialize
        top.anchoredPosition = new Vector2(0, 0);
        bottom.anchoredPosition = new Vector2(0, 0);
        logo.localScale = Vector3.zero;
        logoCanvasGroup.alpha = 0f;
        presentsText.localScale = Vector3.zero;
        presentsTextCanvasGroup.alpha = 0f;

        var seq = LeanTween.sequence();

        // 2. Zoom in Logo
        seq.append(logo.LeanScale(Vector3.one, 0.5f).setEaseInExpo());
        seq.insert(logoCanvasGroup.LeanAlpha(1f, 0.5f));

        // 3. Logo idle
        seq.append(logo.LeanScale(Vector3.one * 1.5f, 4f));

        seq.append(2.5f);

        // 4. Hide logo, zoom in text
        seq.append(presentsText.LeanScale(Vector3.one, 1f).setEaseInExpo());
        seq.insert(presentsTextCanvasGroup.LeanAlpha(1f, 0.5f));
        seq.insert(logo.LeanScale(Vector3.one * 2f, 0.75f).setEaseOutCubic());
        seq.insert(logoCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutCubic());

        // 5. Text idle
        seq.append(presentsText.LeanScale(Vector3.one * 1.5f, 4f));

        // 6. Hide text, move black panels
        seq.append(top.LeanMoveLocalY(1200f, 1f).setEaseInExpo());
        seq.insert(bottom.LeanMoveLocalY(-1200f, 1f).setEaseInExpo());
        seq.insert(presentsTextCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutCubic());
        seq.insert(presentsText.LeanScale(Vector3.one * 2f, 0.75f).setEaseOutCubic());
    }

    void AnimationOld () {
        // 1. Initialize
        top.anchoredPosition = new Vector2(0, 0);
        bottom.anchoredPosition = new Vector2(0, 0);
        logo.localScale = Vector3.zero;
        logoCanvasGroup.alpha = 0f;
        presentsText.localScale = Vector3.zero;
        presentsTextCanvasGroup.alpha = 0f;

        // 2. Zoom in Logo
        logoCanvasGroup.LeanAlpha(1f, 0.5f);
        logo.LeanScale(Vector3.one, 0.5f).setEaseInExpo().setOnComplete(() => {
            // 3. Logo idle
            logo.LeanScale(Vector3.one * 1.5f, 4f).setOnComplete(() => {
                // 4. Hide logo, zoom in text
                logoCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutCubic();
                logo.LeanScale(Vector3.one * 2f, 0.75f).setEaseOutCubic();
                presentsTextCanvasGroup.LeanAlpha(1f, 0.5f);
                presentsText.LeanScale(Vector3.one, 1f).setEaseInExpo().setOnComplete(() => {
                    // 5. Text idle
                    presentsText.LeanScale(Vector3.one * 1.5f, 4f).setOnComplete(() => {
                        // 6. Hide text, move black panels
                        presentsTextCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutCubic();
                        presentsText.LeanScale(Vector3.one * 2f, 0.75f).setEaseOutCubic();
                        top.LeanMoveLocalY(1200f, 1f).setEaseInExpo();
                        bottom.LeanMoveLocalY(-1200f, 1f).setEaseInExpo();
                    });
                });
            });
        });
    }
}
