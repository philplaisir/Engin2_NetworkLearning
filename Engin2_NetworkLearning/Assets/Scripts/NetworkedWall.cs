using Mirror;
using UnityEngine;

public class NetworkedWall : NetworkBehaviour
{
    public static NetworkedWall _instance;

    [SyncVar(hook = nameof(SetIsEnabled))]
    public bool sync_isEnabled = true;

    private void Awake()
    {
        _instance = this;
        _instance.gameObject.SetActive(false);
    }

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



//public static NetworkedWall _instance;
//
//[SyncVar(hook = nameof(SetIsEnabled))]
//public bool sync_isEnabled = true; // En changeant la valeur synced de cette variable avec le "hook" la methode SetIsEnabled est appelee
//
//private void Awake()
//{
//    _instance = this;
//    _instance.gameObject.SetActive(false);
//}
//
//[Command(requiresAuthority = false)] // N'a pas besoin d'avoir l'authorite du serveur pour être appelee
//public void SetActiveNetworked()
//{
//    sync_isEnabled = !sync_isEnabled;
//    //ToggleActiveRPC();
//}
//
//[ClientRpc]
//public void ToggleActiveRPC()
//{
//    gameObject.SetActive(!gameObject.activeInHierarchy);
//}
//
//void SetIsEnabled(bool oldValue, bool newValue)
//{
//    Debug.Log("WallSetIsEnabled");
//    gameObject.SetActive(newValue);
//}





//public static NetworkedWall _instance;
//
//[SyncVar(hook = nameof(SetIsEnabled))]
//public bool sync_isEnabled = true;
//
//private void Awake()
//{
//    Debug.Log("WallAwake");
//    _instance = this;         
//    _instance.gameObject.SetActive(false);               
//}
//
//[Server] // signifie que cette méthode ne peut être appelée que sur le serveur
//public override void OnStartServer() // Est appelé à l'ouverture du server
//{
//    NetworkServer.Spawn(gameObject);
//}
//
//[Command(requiresAuthority = false)]
//public void SetActiveNetworked()
//{
//    Debug.Log("WallSetActiveNetworked");
//    sync_isEnabled = !sync_isEnabled;
//    //ToggleActiveRPC();
//}
//
////[ClientRpc]
////public void ToggleActiveRPC()
////{
////    //if (isClientOnly) 
////    //{
////    //    Debug.Log("Entered toggle activbe RPC");
////    //}
////
////    Debug.Log("WallToggleActiveRPC");
////
////    gameObject.SetActive(!gameObject.activeInHierarchy);
////}
//
//[Command(requiresAuthority = false)]
//void SetIsEnabled(bool oldValue, bool newValue)
//{
//    Debug.Log("WallSetIsEnabled");
//    gameObject.SetActive(newValue);
//}
//
//[Command]
//public void setActiveNetworked()
//{
//    Debug.Log("WallsetActiveNetworked");
//    gameObject.SetActive(!gameObject.activeInHierarchy);
//}

