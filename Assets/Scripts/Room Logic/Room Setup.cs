using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event container for setting up a stage.
/// 
/// Author: William Min
/// Date: 12/30/25
/// </summary>
public class RoomSetup : MonoBehaviour
{
    #region Public Fields


    /// <summary>
    /// Events called to set up stage on awake.
    /// </summary>
    public UnityEvent OnAwakeStage;

    /// <summary>
    /// Events called when opening a stage.
    /// </summary>
    public UnityEvent OnStageOpen;


    #endregion

    #region Monobehavior Callbacks


    private void Awake()
    {
        OnAwakeStage?.Invoke();
    }

    private void OnEnable()
    {
        OnStageOpen?.Invoke();
    }


    #endregion
}
