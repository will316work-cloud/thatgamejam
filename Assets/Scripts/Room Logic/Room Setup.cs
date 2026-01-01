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
    /// Events called when setting the stage.
    /// </summary>
    public UnityEvent DoOnStageSetup;


    #endregion

    #region Public Methods


    /// <summary>
    /// Sets up the stage
    /// </summary>
    [ContextMenu("Set Up Stages")]
    public void SetUpStage()
    {
        DoOnStageSetup?.Invoke();
    }


    #endregion
}
