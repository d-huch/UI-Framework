using System;
using Modules.UIFramework.Interface;
using UnityEngine;
using Zenject;

namespace Modules.UIFramework
{
    public abstract class Panel : IPanel
    {
        protected abstract class Controller<TView> : IPanelController where TView: IPanelView 
        {
            public IPanelView PanelView => View;
            protected readonly TView View;

            private readonly PanelHandler _panelHandler;
            
            protected Controller(TView view, PanelHandler panelHandler)
            {
                View = view;
                _panelHandler = panelHandler;
            }
            
            public virtual void OnOpen(){}
            public virtual void OnClose(){}

            public void Close()
            {
                _panelHandler.Close(View.PanelType);
            }
        }
        
        public abstract class View<TPanel>: PanelView, IPanelView where TPanel: Panel, new()
        {
            private PanelView _viewPrefab;

            public Type Setup(DiContainer container, PanelView viewPrefab)
            {
                _viewPrefab = viewPrefab;
                IPanel panel = new TPanel();
                panel.Setup(container, this);
                return panel.ControllerType;
            }

            public void Bind(DiContainer container, Type type)
            {
                container.Bind(GetType()).FromMethodUntyped(
                    context => container.InstantiatePrefabForComponent<PanelView>(_viewPrefab)).AsSingle();
            }
        }
        
        public Type ControllerType { get; private set; }
        
        private DiContainer _container;
        private IPanelView _view;
        
        protected abstract void InstallBindings();
        
        public void Setup(DiContainer container, IPanelView view)
        {
            _container = container;
            _view = view;
            InstallBindings();
        }

        protected void Bind<TController>()
        {
            ControllerType = typeof(TController);
            _view.Bind(_container, ControllerType);
            _container.Bind<TController>().AsSingle();
        }
    }
}