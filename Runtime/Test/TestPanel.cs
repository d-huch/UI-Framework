using System;
using UnityEngine;

namespace Modules.UIFramework.Test
{
    public class TestPanel: Panel
    {
        private class Controller : Controller<TestPanelView>
        {
            public Controller(TestPanelView view, PanelHandler panelHandler) : base(view, panelHandler)
            {
                Debug.Log(view);
                Debug.Log(View.name);
            }

            public override void OnOpen()
            {
                View.CloseBtn.onClick.AddListener(OnCloseButtonClick); 
            }

            private void OnCloseButtonClick()
            {
                Close();
            }
            
            public override void OnClose()
            {
                View.CloseBtn.onClick.RemoveAllListeners();
            }
        }

        protected override void InstallBindings()
        {
            Bind<Controller>();
        }
    }
}