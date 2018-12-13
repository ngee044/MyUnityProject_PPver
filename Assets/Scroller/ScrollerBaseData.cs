/*
이름:김광수
 내용: 엘리먼트에 들어가는 base 내용
 프리로드를 해야 속도면에서 빨라진다.
작업:[kks][Scroller]:스크롤 
*/
using UnityEngine;
using System.Collections;

namespace nsEnhancedScroller
{
    /// <summary>
    /// This delegate handles any changes to the selection state of the data
    /// </summary>
    /// <param name="val">The state of the selection</param>
    //public delegate void SelectedChangedDelegate(bool val);

    /// <summary>
    /// This class represents an inventory record
    /// </summary>
    public class ScrollerBaseData
    {
        /// The delegate to call if the data's selection state
        /// has changed. This will update any views that are hooked
        /// to the data so that they show the proper selection state UI.
        //public SelectedChangedDelegate selectedChanged;

        public ScrollerBaseCellView CellView;

        /// The selection state
        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set
            {
                // if the value has changed
                if (_selected != value)
                {
                    // update the state and call the selection handler if it exists
                    _selected = value;
                    //if (selectedChanged != null) selectedChanged(_selected);
                }
            }
        }
    }
}