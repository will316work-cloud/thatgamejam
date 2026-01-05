using UnityEngine.EventSystems;

namespace Intersection
{
    /// <summary>
    /// Area that triggers events based on whose mouse cursor interacts with image raycast.
    /// 
    /// Author: William Min
    /// Date: 12/21/25
    /// </summary>
    public class ActOnMouseImage : ActOnMouseAction, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Private Fields


        private bool _hasEntered;   // True if mouse cursor has entered the image raycast target
        private bool _hasClicked;   // True if mouse cursor has clicked on the image raycast target


        #endregion

        #region MonoBehavior Callbacks


        private void Update()
        {
            if (_hasEntered)
            {
                _activateStayEvents(_cameraObject);
            }

            if (_hasClicked)
            {
                _activateDragEvents(_cameraObject);
            }
        }


        #endregion

        #region IPointer Callbacks


        public void OnPointerEnter(PointerEventData eventData)
        {
            _activateEnterEvents(_cameraObject);

            _hasEntered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _activateExitEvents(_cameraObject);

            _hasEntered = false;
            _hasClicked = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _activatePressEvents(_cameraObject);

            _hasClicked = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _activateReleaseEvents(_cameraObject);

            if (_hasClicked)
            {
                _activateReleaseOnPressedEvents(_cameraObject);
            }

            _hasClicked = false;
        }


        #endregion
    }
}
