using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChooserEnemies : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraTarget _cameraTarget;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private ParticleSystem _manTrail;
    [SerializeField] private List<EnemySaveZone> _listSaveZone = new List<EnemySaveZone>();
    private bool _death;

    public void ChooseEnemy()
    {
        if (!_death)
        {
            _animator.AnimationSpeed(1);
            PlayerCollider(false);
            Time.timeScale = 1;
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    if(_listSaveZone.Count != 0)
                    {
                        for (int i = 0; i < _listSaveZone.Count; i++)
                        {
                            _listSaveZone[i].DisableEnableCollider();
                        }
                    }
                    enemy.DisableEnableCollider();
                    _manTrail.Play();
                    enemy.PlayerTarget();
                    _cameraTarget.TargetPosition();
                    Attack(enemy.transform.position);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemySaveZone enemySaveZone))
        {
            UpdateList(enemySaveZone);
        }
    }

    private void UpdateList(EnemySaveZone enemySaveZone)
    {
        _listSaveZone.Add(enemySaveZone);
    }

    private void Attack(Vector3 Target)
    {
        _player.SetDestination(Target);
    }

    public void AgentDisable()
    {
        _death = true;
        _player.enabled = false;
    }

    public void PlayerCollider(bool i)
    {
        _playerCollider.enabled = i;
    }
}
