using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerJump _playerJump;
    private SurfaceDetector _surfaceDetector;
    private string _isJumpBool = "IsJump";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerJump = GetComponent<PlayerJump>();
        _surfaceDetector = GetComponent<SurfaceDetector>();
    }

    private void Update()
    {
        if (_surfaceDetector.IsDetectGround() == false || _playerJump.IsJump == true)
        {
            _animator.SetBool(_isJumpBool, true);
        }
        else
        {
            _animator.SetBool(_isJumpBool, false);
        }
    }
}
