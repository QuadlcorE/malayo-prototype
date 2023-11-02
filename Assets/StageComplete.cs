using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class StageComplete : MonoBehaviour
    {
        PlayerController playerController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerController.StageComplete();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}