using UnityEngine;
using UnityEngine.Events;

namespace Intersection
{
    /// <summary>
    /// 
    /// 
    /// Author: William Min
    /// Date: 12/21/25
    /// </summary>
    public abstract class ActOnMouseAction : ActOnIntersect
    {
        #region Serialized Fields


        [Header("Act On Mouse Action Properties")]

        [Header("Act On Mouse Action Toggles")]
        [SerializeField] private bool _willRespondToPress = true;               // True if the intersectable will act on being pressed by mouse
        [SerializeField] private bool _willRespondToDrag = true;                // True if the intersectable will act on being dragged by mouse
        [SerializeField] private bool _willRespondToRelease = true;             // True if the intersectable will act on being released by mouse
        [SerializeField] private bool _willRespondToReleaseOnPressed = true;    // True if the intersectable will act on being released on the same object pressed by mouse

        [Header("Act On Mouse Action Events")]
        [Space]

        /// <summary>
        /// Events for when the mouse presses on the area that gives the owner.
        /// </summary>
        public UnityEvent<GameObject> PressEventPassOwner;

        /// <summary>
        /// Events for when the mouse presses on the area that gives the collider's gameObject.
        /// </summary>
        public UnityEvent<GameObject> PressEventPassCollided;

        /// <summary>
        /// Events for when the mouse drags on the area that gives the owner.
        /// </summary>
        public UnityEvent<GameObject> DragEventPassOwner;

        /// <summary>
        /// Events for when the mouse drags on the area that gives the collider's gameObject.
        /// </summary>
        public UnityEvent<GameObject> DragEventPassCollided;

        /// <summary>
        /// Events for when the mouse releases the area that gives the owner.
        /// </summary>
        public UnityEvent<GameObject> ReleaseEventPassOwner;

        /// <summary>
        /// Events for when the mouse releases the area that gives the collider's gameObject.
        /// </summary>
        public UnityEvent<GameObject> ReleaseEventPassCollided;

        /// <summary>
        /// Events for when the mouse releases the pressed area that gives the owner.
        /// </summary>
        public UnityEvent<GameObject> ReleaseOnPressedEventPassOwner;

        /// <summary>
        /// Events for when the mouse releases the pressed area that gives the collider's gameObject.
        /// </summary>
        public UnityEvent<GameObject> ReleaseOnPressedEventPassCollided;


        #endregion

        #region Private Fields


        protected GameObject _cameraObject;


        #endregion

        #region MonoBehavior Callbacks


        protected override void Awake()
        {
            base.Awake();

            _cameraObject = Camera.main.gameObject;

            //EnterEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Entered with {gameObject.name}"));
            //StayEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Stayed with {gameObject.name}"));
            //ExitEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Exited with {gameObject.name}"));

            //PressEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Pressed with {gameObject.name}"));
            //DragEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Dragged with {gameObject.name}"));
            ReleaseEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Released with {gameObject.name}"));
            ReleaseOnPressedEventPassCollided.AddListener((gameObject) => Debug.Log($"{name} Mouse Released On Pressed with {gameObject.name}"));
        }


        #endregion

        #region Private Methods


        protected void _activatePressEvents(GameObject collidedObject)
        {
            _activateEvents(collidedObject, _willRespondToPress, PressEventPassOwner, PressEventPassCollided);
        }

        protected void _activateDragEvents(GameObject collidedObject)
        {
            _activateEvents(collidedObject, _willRespondToDrag, DragEventPassOwner, DragEventPassCollided);
        }

        protected void _activateReleaseEvents(GameObject collidedObject)
        {
            _activateEvents(collidedObject, _willRespondToRelease, ReleaseEventPassOwner, ReleaseEventPassCollided);
        }

        protected void _activateReleaseOnPressedEvents(GameObject collidedObject)
        {
            _activateEvents(_cameraObject, _willRespondToReleaseOnPressed, ReleaseOnPressedEventPassOwner, ReleaseOnPressedEventPassCollided);
        }


        #endregion
    }
}
