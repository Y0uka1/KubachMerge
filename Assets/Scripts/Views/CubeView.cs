using System;
using Databases;
using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Views
{
    public class CubeView : LinkableView
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private TMP_Text[] _texts;

        public GameEntity LinkedEntity => Entity;
        private Touch _touch;
        private Vector3 screenPoint;
        private Vector3 offset;

        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.AddCubeRenderer(meshRenderer);
            entity.AddCubeRigidBody(_rigidbody);
            entity.AddCubePosition(transform);
            foreach (var text in _texts)
            {
                text.text = Math.Pow(2, entity.tier.Value).ToString();
            }
        }


        private void Update()
        {
            if (!Entity.isUnderControl)
                return;
            TouchInput();
        }

        private void TouchInput()
        {
            Input.simulateMouseWithTouches = true;
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y,
                        transform.position.z + _touch.deltaPosition.x*Time.deltaTime
                    );
                }

                if (_touch.phase == TouchPhase.Ended)
                {
                    Entity.isStartingAcceleration = true;
                    Entity.isUnderControl = false;
                }
            }
        }

        #region mouseControll

#if UNITY_EDITOR


        void OnMouseDown()
        {
            if (!Entity.isUnderControl)
                return;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                         screenPoint.z));
        }

        void OnMouseDrag()
        {
            if (!Entity.isUnderControl)
                return;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(transform.position.x, transform.position.y, curPosition.z);
        }

        private void OnMouseUp()
        {
            if (!Entity.isUnderControl)
                return;
            Entity.isStartingAcceleration = true;
            Entity.isUnderControl = false;
        }
#endif

        #endregion mouseControll

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetEntityLink() == null)
                return;
            var entity = collision.gameObject.GetEntityLink().entity as GameEntity;
            if(!entity.isMergeable)
                return;
            entity.isAffectedByOtherCube = true;
            if (entity.tier.Value == Entity.tier.Value)
            {
                var cubePosition = collision.gameObject.transform.position;
                var view = collision.gameObject.GetComponent<CubeView>();
                Entity.AddCollision(view, cubePosition);
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}