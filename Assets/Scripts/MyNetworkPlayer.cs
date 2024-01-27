using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MyNetworkPlayer : MonoBehaviourPunCallbacks , IPunObservable
{
    PlayerController playerController;
    public GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    private

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //isminee = send
    void Update()
    {
        if (photonView.IsMine)
        {
            if (!playerController)
            {
                player = GameObject.Find("Player");
                playerController = player.GetComponent<PlayerController>();
                playerPosition = player.transform.position;
                playerRotation = player.transform.rotation;
            }
        }
        else
        {
            player.transform.position = playerPosition;
            player.transform.rotation = playerRotation;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (photonView.IsMine && stream.IsWriting)
        {
            stream.SendNext(playerPosition);
            stream.SendNext(playerRotation);
        }
        else
        {
            this.playerPosition = (Vector3)stream.ReceiveNext();
            this.playerRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
