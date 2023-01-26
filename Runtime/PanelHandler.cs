using System;
using System.Collections.Generic;
using Modules.UIFramework.Interface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.UIFramework
{
    public class PanelHandler
    {
        public Dictionary<PanelType, Type> Panels = new();

        private readonly Dictionary<PanelType, PanelView> _openedPanelViews = new ();
        private readonly Dictionary<PanelType, IPanelController> _openedPanelControllers = new ();
        private readonly DiContainer _container;
        
        public PanelHandler(DiContainer container)
        {
            _container = container;
        }
        
        public void Open(PanelType panelType)
        {
            if (_openedPanelViews.TryGetValue(panelType, out var panel))
            {
                panel.gameObject.SetActive(true);
                var controller = (IPanelController)_container.Resolve(Panels[panelType]);
                controller.OnOpen();
            }
            else
            {
                var canvas = CreateCanvas();
                var controller = (IPanelController)_container.Resolve(Panels[panelType]);
                controller.OnOpen();
                var panelView = (PanelView)controller.PanelView;
                panelView.SetCanvas(canvas);
                panelView.transform.SetParent(canvas.transform, false);
                _openedPanelControllers.Add(panelType, controller);
                _openedPanelViews.Add(panelType, panelView);
            }
        }

        public void Close(PanelType panelType)
        {
            if (_openedPanelViews.TryGetValue(panelType, out var panelView))
            {
                panelView.gameObject.SetActive(false);
            }

            if (_openedPanelControllers.TryGetValue(panelType, out var panelController))
            {
                panelController.OnClose();
            }
        }

        private Canvas CreateCanvas()
        {
            GameObject obj = new GameObject(PanelType.Test.ToString());
            Canvas canvas = obj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.matchWidthOrHeight = 1;
            canvasScaler.referencePixelsPerUnit = 100;
            GraphicRaycaster graphicRaycaster = obj.AddComponent<GraphicRaycaster>();
            graphicRaycaster.ignoreReversedGraphics = true;
            graphicRaycaster.blockingMask = LayerMask.GetMask("Default", "UI");
            return canvas;
        }
    }
}