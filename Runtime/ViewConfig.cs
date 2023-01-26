using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIFramework
{
    [Serializable]
    public class ViewConfig
    {
        [SerializeField] private RenderMode canvasRenderMode = RenderMode.ScreenSpaceOverlay;
        [SerializeField] private CanvasScaler.ScaleMode scaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        [SerializeField] private Vector2 referenceResolution = new (1920, 1080);
        [SerializeField] private float matchWidthOfHeight = 1f;
        [SerializeField] private int referencePixelsPerUnit = 100;
        [SerializeField] private bool ignoreReversedGraphics = true;
        [SerializeField] private LayerMask blockingMask;
    }
}