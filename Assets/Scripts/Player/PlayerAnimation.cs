using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerJump _playerJump;
    private PlayerMovement _playerMovement;
    private SurfaceDetector _surfaceDetector;
    private string _isJumpBool = "IsJump";
    private string _isRunning = "IsRunning";

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _playerJump = GetComponent<PlayerJump>();
        _surfaceDetector = GetComponent<SurfaceDetector>();
    }

    private void Update()
    {
        if (_playerMovement.enabled)
        {
            _animator.SetBool(_isRunning, true);

            if (_surfaceDetector.IsDetectGround() == false || _playerJump.IsJump == true)
            {
                _animator.SetBool(_isJumpBool, true);
            }
            else
            {
                _animator.SetBool(_isJumpBool, false);
            }
        }
        else
        {
            _animator.SetBool(_isRunning, false);
        }
    }
}
