using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIFramework.Test
{
    public class TestPanelView: Panel.View<TestPanel>
    {
        [SerializeField] private Button closeBtn;
        public Button CloseBtn => closeBtn;
    }
}