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
        public readonly Dictionary<string, Type> Panels = new();

        private readonly Dictionary<string, PanelView> _openedPanelViews = new ();
        private readonly Dictionary<string, IPanelController> _openedPanelControllers = new ();
        private readonly DiContainer _container;
        private readonly CanvasHelper _canvasHelper;

        public PanelHandler(DiContainer container, CanvasHelper canvasHelper)
        {
            _container = container;
            _canvasHelper = canvasHelper;
        }
        
        public void Open(string panelName)
        {
            if (_openedPanelViews.TryGetValue(panelName, out var panel))
            {
                panel.gameObject.SetActive(true);
                var controller = (IPanelController)_container.Resolve(Panels[panelName]);
                controller.OnOpen();
            }
            else
            {
                var canvas = _canvasHelper.CreateCanvas(panelName);
                var controller = (IPanelController)_container.Resolve(Panels[panelName]);
                controller.OnOpen();
                var panelView = (PanelView)controller.PanelView;
                panelView.SetCanvas(canvas);
                panelView.transform.SetParent(canvas.transform, false);
                _openedPanelControllers.Add(panelName, controller);
                _openedPanelViews.Add(panelName, panelView);
            }
        }

        public void Close(string panelType)
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
    }
}