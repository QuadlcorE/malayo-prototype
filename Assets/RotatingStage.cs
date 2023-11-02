using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif
using TMPro;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM 
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class RotatingStage : MonoBehaviour
    {
        PlayerController playerController;

        public Vector3 currentGravity;
        public GameObject player;
        public GameObject stage;
        public float speed = 20.0f; // Speed of rotation
        public float fastSpeed = 30.0f; // Fast speed of rotation 


        private Rigidbody stageRb;


        public static bool isPaused = false;
        public bool paused = false;

        public bool flipped = false;

        public bool boost = false;

        public GameObject pauseMenu;
        public GameObject controlMenu;



        // Starter assets 
#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerInput;
#endif

        private StarterAssetsInputs _input;

        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
                return false;
#endif
            }
        }

        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM
            _playerInput = GetComponent<PlayerInput>();
#else
            Debug.LogError("Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            stageRb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // Rotate around the y-axis
            // transform.Rotate(0, speed * Time.deltaTime, 0);
            
            PauseGame();
            currentGravity = Physics.gravity;
        }

        void FixedUpdate()
        {
            MovePlayer();
            RotateStage();
        }

     

        // Handle input and rotate the stage
        // This isn't working causes collision errors
        /*
        void RotateStage()
        {
            if (_input.rotateLeft)
            {
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z + speed * Time.deltaTime));
            }
            else if (_input.rotateLeftFast)
            {
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z + fastSpeed * Time.deltaTime));
            }
            else if (_input.rotateRight)
            {
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z - speed * Time.deltaTime));
            }
            else if (_input.rotateRightFast)
            {
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z - fastSpeed * Time.deltaTime));
            }
        }*/

        // Fix if there is time.
        public void RotateStage()
        {
            Vector3 point = player.transform.position; 
            Vector3 originalPosition = stage.transform.position; 

            if (_input.rotateLeft)
            {
                stage.transform.position = point;
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z + speed * Time.deltaTime));
                stage.transform.position = originalPosition; 
            }
            else if (_input.rotateLeftFast)
            {
                stage.transform.position = point;
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z + fastSpeed * Time.deltaTime));
                stage.transform.position = originalPosition;
            }
            else if (_input.rotateRight)
            {
                stage.transform.position = point;
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z - speed * Time.deltaTime));
                stage.transform.position = originalPosition;
            }
            else if (_input.rotateRightFast)
            {
                stage.transform.position = point;
                stageRb.MoveRotation(Quaternion.Euler(0, 0, stageRb.rotation.eulerAngles.z - fastSpeed * Time.deltaTime));
                stage.transform.position = originalPosition;
            }
        }



        // Move the player
        void MovePlayer()
        {
            if (_input.flip)
            {
                flipped = true;
            }
            else if (!_input.flip && flipped)
            {
                playerController.FlipGravity();
                flipped = false;
            }

            if (_input.boost)
            {
                boost = true;
            }
            else if (!_input.boost && boost)
            {
                playerController.Boost();
                boost = false;
            }
        }

        void PauseGame()
        {
            if(_input.pause)
            {
                paused = true;
            } 
            else if (!_input.pause && paused)
            {
                isPaused = !isPaused;
                paused = false;
            }

            pauseMenu.SetActive(isPaused);
            controlMenu.SetActive(!isPaused);

            if (isPaused) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }

        // Unused functions 
        /*public void RotateLeft()
        {
            stage.transform.Rotate(0, 0, fastSpeed * Time.deltaTime);
        }
        public void RotateRight()
        {
            stage.transform.Rotate(0, 0, (-fastSpeed) * Time.deltaTime);
        }*/

        
       
    }
} 