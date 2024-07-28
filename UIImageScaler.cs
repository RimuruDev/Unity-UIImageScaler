// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

using UnityEngine;
using UnityEngine.UI;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.UI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(AspectRatioFitter))]
    public sealed class UIImageScaler : MonoBehaviour
    {
        [SerializeField] private ScaleImageMode scaleImageMode;

        private Image image;
        private RectTransform rectTransform;
        private AspectRatioFitter aspectRatioFitter;

        private void OnEnable()
        {
            if (scaleImageMode == ScaleImageMode.OnEnable)
                ScaleImage();
        }

        private void Awake()
        {
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
            aspectRatioFitter = GetComponent<AspectRatioFitter>();
        }

        private void Start() =>
            ScaleImage();

        private void LateUpdate()
        {
            if (scaleImageMode == ScaleImageMode.LateUpdate)
                ScaleImage();
        }

        private void ScaleImage()
        {
            SetAspectRatioMode();
            SetAnchorState();
        }

        private void SetAspectRatioMode()
        {
            aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
            aspectRatioFitter.aspectRatio = image.sprite.bounds.size.x / image.sprite.bounds.size.y;
        }

        private void SetAnchorState()
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;

            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }

        private enum ScaleImageMode
        {
            LateUpdate = 0,
            OnEnable = 1,
        }
    }
}
