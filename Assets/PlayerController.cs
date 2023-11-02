using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StarterAssets
{
    public class PlayerController : MonoBehaviour
    {
        private int time;
        public int coins;

        public GameObject stageObject;
        public float additionalForce;
        public Rigidbody playerRb;

        public bool isBoosting = false;
        public int boostersLeft;
        public TMP_Text boostersLeftText;

        public float boosterCooldown;
        public TMP_Text boosterCooldownText;
        public float boostTime;
        public TMP_Text boostTimeText;

        private float _timeBoosted;
        private float _timeSinceLastBoost;

        public GameObject gameOver;
        public GameObject levelComplete;
        public TMP_Text Score;

        public GameObject controlMenu;
        public GameObject pauseMenu;

        public float gravity = 9.8f;
        public Vector3 gravityDirection = Vector3.down;
        public bool flipped = false;

        private StarterAssetsInputs _input;


        private void Start()
        {
            gravityDirection = gravity * gravityDirection;
            playerRb = GetComponent<Rigidbody>();
            // StartTimer();

            Physics.gravity = gravityDirection;
        }

        private void FixedUpdate()
        {
            // FlipGravity();
            BoostCheck();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Debug.Log(collision.gameObject.tag);
        }

        private void OnTriggerEnter(Collider other)
        {
            BounceTriggerCheck(other);
        }


        // ============ Collision with Enemmy ===============
        void EnemyCollisionCheck(Collision collision)
        {
            string tag = collision.gameObject.tag;
            if (tag == "Enemy")
            {

            }
        }

        // ============== Collision with BouncePad =============
        void BounceTriggerCheck(Collider collision)
        {
            string tag = collision.gameObject.tag;
            if (tag == "BouncePad")
            {
                Transform bouncePad = collision.gameObject.transform;
                playerRb.AddForce(bouncePad.up * additionalForce, ForceMode.Impulse);
            }
        }

        // ============= Collision with Finale object ===========
        void StageCompleteCheck(Collision collision)
        {
            string tag = collision.gameObject.tag;
            if (tag == "StageComplete")
            {
                StageComplete();
            }
        }

        // ============== Coins ===============
        public void PickupCoin()
        {
            coins += 1;
        }

        // =============== Bosters =================
        public void PickupBooster()
        {
            if(boostersLeft < 4) boostersLeft += 1;
        }

        // ============== Flip Gravity =============================
        public void FlipGravity()
        {
            gravityDirection = -gravityDirection;
            Physics.gravity = gravityDirection;
        }

        // ============== Boost mechanics ===========================
        public void Boost()
        {
            Debug.Log("I was boosted outer loop");
            if (_timeSinceLastBoost == 0)
            {
                Debug.Log("Eventually I ran");
                _timeSinceLastBoost = boosterCooldown;
                _timeBoosted = boostTime;
                Physics.gravity = gravityDirection * 3;
                boostersLeft -= 1;
            }
        }

        public void BoostCheck()
        {
            if (_timeSinceLastBoost > 0) _timeSinceLastBoost -= Time.deltaTime;
            else _timeSinceLastBoost = 0;

            if (_timeBoosted > 0) _timeBoosted -= Time.deltaTime;
            else _timeBoosted = 0;


            boosterCooldownText.text = "Cooldown: " +(_timeSinceLastBoost).ToString("0");
            boostTimeText.text = "BoostTime: " + (_timeBoosted).ToString("0");


            boostersLeftText.text = "BoostersLeft: " + (boostersLeft).ToString("0");

            if (_timeBoosted < 0)
            {
                Physics.gravity = gravityDirection;
            }
        }

        // ================= Timer ======================
        void StartTimer()
        {
            time = 0;
            InvokeRepeating("IncrementTime", 1, 1);
        }

        void StopTimer()
        {
            CancelInvoke();
        }


        // ================== Game Over ===================
        public void GameOver()
        {
            pauseMenu.SetActive(false);
            controlMenu.SetActive(false);
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        // ================== Stage Complete ================
        public void StageComplete()
        {
            stageObject.SetActive(false);
            pauseMenu.SetActive(false);
            controlMenu.SetActive(false);
            int score = (coins * 5) - (time * 2); // Fix hard codding
            Score.text = (score).ToString("0");
            levelComplete.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
