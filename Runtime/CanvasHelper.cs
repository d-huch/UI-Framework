using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIFramework
{
    public class CanvasHelper
    {
        public Vector2 CanvasResolution { get; set; } = new (1920, 1080);
        
        public Canvas CreateCanvas(string name)
        {
            GameObject obj = new GameObject(name);
            Canvas canvas = obj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = CanvasResolution;
            canvasScaler.matchWidthOrHeight = 1;
            canvasScaler.referencePixelsPerUnit = 100;
            GraphicRaycaster graphicRaycaster = obj.AddComponent<GraphicRaycaster>();
            graphicRaycaster.ignoreReversedGraphics = true;
            graphicRaycaster.blockingMask = LayerMask.GetMask("Default", "UI");
            return canvas;
        }
    }
}