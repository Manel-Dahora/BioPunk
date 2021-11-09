using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsule;
    private Vector3 _capsuleCenter;
    private float _capsuleHeight;
    public Animator animator;
    // Parameters
    private const float HALF = 0.5f;
    private float _speed = 8f;
    private float _jumpForce = 7f;
    private float _wallSlidingSpeed = -3f;
    private float _groundCheckDistance = 1.1f;
    private float _wallCheckDistance = 1f;
    // Inputs
    private float _horizontal;
    // Checks
    private bool _isGrounded;
    private bool _isAgainstWall;
    private bool _isCrouching;
    private bool _isCrouched;
    private bool _isJumping;
    private bool _isWallSliding;
    private bool _isWallJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsule = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        _capsuleHeight = _capsule.height;
        _capsuleCenter = _capsule.center;
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | 
                                 RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        // Inputs
        _horizontal = Input.GetAxisRaw("Horizontal");
        _isJumping = Input.GetButtonDown("Jump");
        _isCrouching = Input.GetKeyDown(KeyCode.C);
        // Basic Checks
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance) ? true : false;
        _isAgainstWall = Physics.Raycast(transform.position, Vector3.right, _wallCheckDistance) || 
                         Physics.Raycast(transform.position, Vector3.left, _wallCheckDistance) ? true : false;
        // Basic Moves
        _rigidbody.velocity = new Vector3(_horizontal * _speed, _rigidbody.velocity.y, 0);
        transform.rotation = _horizontal >= 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        if (_horizontal != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetBool("IsRunning", false);
        }

        if (_isJumping && _isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            animator.SetBool("Moving", true);
            animator.SetBool("isJumping", true);
            _isJumping = false;
        }
        // Special Moves
        SpecialMoves(_horizontal, _isJumping, _isCrouching, _isGrounded, _isAgainstWall);
    }

    private void SpecialMoves(float horizontal, bool isJumping, bool isCrouching, bool isGrounded, bool isAgainstWall)
    {
        // Special Checks
        _isWallSliding = (!isGrounded && isAgainstWall && horizontal != 0) ? true : false;
        _isWallJumping = (_isWallSliding && isJumping) ? true : false;
        // Special Moves
        if (_isWallSliding) _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _wallSlidingSpeed, 0);
        //if (_isWallJumping) _rigidbody.AddForce(_jumpForce * (Vector3.up + horizontal * Vector3.left).normalized, ForceMode.Impulse);
        if (_isWallJumping) _rigidbody.velocity = new Vector3(_jumpForce * -horizontal, _jumpForce, 0);
        ScaleCapsuleForCrouching(isCrouching);
        PreventStandingInLowHeadroom();
    }

    private void ScaleCapsuleForCrouching(bool isCrouching)
    {
        if (_isGrounded && isCrouching)
        {
            if (!_isCrouched)
            {
                _capsule.height = _capsule.height / 2f;
                _capsule.center = _capsule.center / 2f;
                _isCrouched = true;
            }
        }
        else
        {
            Ray crouchRay = new Ray(_rigidbody.position + Vector3.up * _capsule.radius * HALF, Vector3.up);
            float crouchRayLength = _capsuleHeight - _capsule.radius * HALF;
            _isCrouching = Physics.SphereCast(crouchRay, _capsule.radius * HALF, crouchRayLength, Physics.AllLayers,
                QueryTriggerInteraction.Ignore) ? true : false;
            if (!_isCrouching)
            {
                _capsule.height = _capsuleHeight;
                _capsule.center = _capsuleCenter;
                _isCrouched = false;
            }
        }
    }

    private void PreventStandingInLowHeadroom()
    {
        if (!_isCrouching)
        {
            Ray crouchRay = new Ray(_rigidbody.position + Vector3.up * _capsule.radius * HALF, Vector3.up);
            float crouchRayLength = _capsuleHeight - _capsule.radius * HALF;
            _isCrouching = Physics.SphereCast(crouchRay, _capsule.radius * HALF, crouchRayLength, Physics.AllLayers,
                QueryTriggerInteraction.Ignore) ? true : false;
        }
    }
}
