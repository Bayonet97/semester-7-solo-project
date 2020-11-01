using cakeslice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

namespace Assets.Scripts.Objects
{
    public abstract class InteractableObject : MonoBehaviour
    {

        public delegate void EnteredRange(InteractableObject obj, PlayerCharacterBase character);
        public static event EnteredRange OnEnteredRange;

        public delegate void ExitedRange(InteractableObject obj, PlayerCharacterBase character);
        public static event ExitedRange OnExitedRange;

        public List<InteractionFlow> InteractionFlows = new List<InteractionFlow>();

        private int _interactionCount;

        public bool Dead = false;

        [SerializeField]
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public string TextToShow { get; set; }

        public void Awake()
        {
            enabled = true;
            if (gameObject.GetComponent<MeshRenderer>() != null)
            {
               gameObject.AddComponent<Outline>();
                gameObject.GetComponent<Outline>().eraseRenderer = true;
            }   
        }
        public virtual void Interact()
        {
            // Default implementation.
            //  UpdateTextToShow(InteractionFlows[0]);
            _interactionCount++;
        }
        public virtual void Interact(bool hasItem)
        {
            // Default implementation.
            if (hasItem)
            {
                // UpdateTextToShow(InteractionFlows[1]);
                _interactionCount++;
            }
            else
            {
                // UpdateTextToShow(InteractionFlows[0]);
                _interactionCount++;
            }
        }

        public virtual void Interact(int amount)
        {
            // Default implementation.
            //  UpdateTextToShow(InteractionFlows[amount]);
            _interactionCount++;
        }

        /*        public void UpdateTextToShow(InteractionFlow interactionFlow)
                {
                    if (_interactionCount >= interactionFlow.Dialogue.Count && interactionFlow.GetRepeatable() == false)
                    { // Not Repeatable
                        // The last interaction.
                        TextToShow = interactionFlow.Dialogue[interactionFlow.Dialogue.Count - 1];
                    } 
                    else if (_interactionCount >= interactionFlow.Dialogue.Count && interactionFlow.GetRepeatable() == true) 
                    { // Repeatable
                        // The first interaction.
                        _interactionCount = 0;
                        TextToShow = interactionFlow.Dialogue[_interactionCount];
                    }
                    else
                    {
                        TextToShow = interactionFlow.Dialogue[_interactionCount];
                    }
                }*/

        public void SetInteractionCount(int count)
        {
            _interactionCount = count;
        }

        public void GetKilled()
        {
            if(InteractionFlows.Count > 0)
            {
                Dead = true;
                GetComponent<Animator>().enabled = false;
                transform.rotation = Quaternion.Euler(-90f, transform.rotation.y, transform.rotation.z);
            }
        }

        public void Highlight(bool highlight)
        {
            if (gameObject.GetComponent<Outline>())
            {
                gameObject.GetComponent<Outline>().eraseRenderer = !highlight;
            }
        }

        public void OnTriggerEnter(Collider col)
        {
            PlayerCharacterBase character = col.GetComponent<PlayerCharacterBase>();
            if (character != null)
            {
                OnEnteredRange(this, character);
            }
        }

        public void OnTriggerExit(Collider col)
        {
            PlayerCharacterBase character = col.GetComponent<PlayerCharacterBase>();
            if (character != null)
            {
                OnExitedRange(this, character);
            }
        }
    }
}
