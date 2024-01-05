using Mirror;
using UnityEngine;

public class NetworkedWall : NetworkBehaviour
{
    //TODO m'assurer de faire disparaitre le mur apres son initialisation sur le serveur

    public static NetworkedWall _instance;

    [SyncVar(hook = nameof(SetIsEnabled))]
    public bool sync_isEnabled = true;

    private void Awake()
    {
        _instance = this;
        _instance.gameObject.SetActive(false);
    }

    //private void Start() //Not working
    //{
    //    _instance.gameObject.SetActive(false);
    //}

    [Command(requiresAuthority = false)]
    public void SetActiveNetworked()
    {
        sync_isEnabled = !sync_isEnabled;
        //ToggleActiveRPC();
    }

    [ClientRpc]
    public void ToggleActiveRPC()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    void SetIsEnabled(bool oldValue, bool newValue)
    {
        gameObject.SetActive(newValue);
    }
        
}


