using UnityEngine.EventSystems;

namespace Intersection
{
    public class ActOnMouseImage : ActOnMouseAction, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Private Fields


        private bool _hasEntered;
        private bool _hasClicked;


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
