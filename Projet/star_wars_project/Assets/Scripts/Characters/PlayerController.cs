using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private Vector2 mouseSensitivity = Vector2.one;
    [SerializeField] private Transform eyes;

    private Vector3 velocity;
    private Vector2 moveInput, lookInput;
    private bool jumpPerformed;
    private CharacterController characterController;

    public bool isCameraLock;

    public static PlayerController instance;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); 

        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerController dans la scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        isCameraLock = false;
    }

    private void Update()
    {
        Look();
        DisplayWeapon();
    }

    private void FixedUpdate()
    {
        if(!isCameraLock)
        {
            Vector3 _horizontalVelocity = speed * new Vector3(moveInput.x, 0, moveInput.y);
            float _gravityVelocity = Gravity(velocity.y);

            velocity = _horizontalVelocity + _gravityVelocity * Vector3.up;

            TryJump();

            Vector3 motion = transform.right * velocity.x + transform.up * velocity.y + transform.forward * velocity.z;
            characterController.Move(motion * Time.deltaTime);
        }
    }

    private void Look()
    {
        if(!isCameraLock)
        {
            //Rotation horizontale
            transform.Rotate(lookInput.x * mouseSensitivity.x * Time.deltaTime * Vector3.up);

            //Rotation verticale
            float _eyesAngleX = eyes.localEulerAngles.x - lookInput.y * Time.deltaTime * mouseSensitivity.y;

            //on clamp pour bloquer la vision et empecher de bouger dans tous les sens
            if(_eyesAngleX <= 90f) _eyesAngleX = _eyesAngleX > 0 ? Mathf.Clamp(_eyesAngleX, 0f, 89.9f) : _eyesAngleX;
            if(_eyesAngleX > 270f) _eyesAngleX = Mathf.Clamp(_eyesAngleX, 271f, 360f);

            eyes.localEulerAngles = Vector3.right * _eyesAngleX;
        }
    }

    private float Gravity(float _verticalVelocity)
    {
        //si la personne touche le sol je fais en sorte que _verticalVelocity soit nulle en sortie poure viter d'avoir une vitesse verticale en permanence
        if(characterController.isGrounded){
            return 0;
        }

        _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        return _verticalVelocity; 

    }

    private void TryJump()
    {
        //si le joueur ne saute pas ou qu'il ne touche pas le sol alors il ne se passe rien
        if(!jumpPerformed || !characterController.isGrounded) return;

        velocity.y += jumpForce;
        jumpPerformed = false;
    }

    public void MovePerformed(InputAction.CallbackContext _ctx) => moveInput = _ctx.ReadValue<Vector2>();
    public void LookPerformed(InputAction.CallbackContext _ctx) => lookInput = _ctx.ReadValue<Vector2>();
    public void JumpPerformed(InputAction.CallbackContext _ctx) => jumpPerformed = _ctx.performed;

    public void DisplayWeapon()
    {
        Debug.Log(EquipWeapon.instance.weaponEquip);
    }
}
