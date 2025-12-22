namespace Intersection
{
    public class ActOnMouseCollider : ActOnMouseAction
    {
        #region MonoBehavior Callbacks


        private void OnMouseEnter()
        {
            _activateEnterEvents(_cameraObject);
        }

        private void OnMouseOver()
        {
            _activateStayEvents(_cameraObject);
        }

        private void OnMouseExit()
        {
            _activateExitEvents(_cameraObject);
        }

        private void OnMouseDown()
        {
            _activatePressEvents(_cameraObject);
        }

        private void OnMouseDrag()
        {
            _activateDragEvents(_cameraObject);
        }

        private void OnMouseUp()
        {
            _activateReleaseEvents(_cameraObject);
        }
        private void OnMouseUpAsButton()
        {
            _activateReleaseOnPressedEvents(_cameraObject);
        }


        #endregion
    }
}
