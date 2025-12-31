using UnityEngine.EventSystems;

namespace Intersection
{
    /// <summary>
    /// 
    /// 
    /// Author: William Min
    /// Date: 12/21/25
    /// </summary>
    public class ActOnMouseImage : ActOnMouseAction, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Private Fields


        private bool _hasEntered;   // 
        private bool _hasClicked;   // 


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

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            _activateEnterEvents(_cameraObject);

            _hasEntered = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            _activateExitEvents(_cameraObject);

            _hasEntered = false;
            _hasClicked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            _activatePressEvents(_cameraObject);

            _hasClicked = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
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
