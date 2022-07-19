using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator _animator;
    private bool _isFollow;

    private int _hashFollowCam = Animator.StringToHash("FollowCam");
    private int _hashTimelineCam = Animator.StringToHash("TimelineCam");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            _isFollow = !_isFollow;

            _animator.Play(_isFollow ? _hashFollowCam : _hashTimelineCam);

            _animator.StopPlayback();
        }
    }
}
