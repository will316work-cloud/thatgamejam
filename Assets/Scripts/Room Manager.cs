using UnityEngine;

public class RoomManager: MonoBehaviour
{
    [SerializeField] private Transform _roomStorage;
    [SerializeField] private int _currentRoomIndex;

    protected void Awake()
    {
        for (int i = 0; i < _roomStorage.childCount; i++)
        {
            _roomStorage.GetChild(i).gameObject.SetActive(false);
        }

        LoadRoom(_currentRoomIndex);
    }

    public void LoadRoom(int index)
    {
        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(false);

        _currentRoomIndex = index;

        _roomStorage.GetChild(_currentRoomIndex).gameObject.SetActive(true);
    }
}
