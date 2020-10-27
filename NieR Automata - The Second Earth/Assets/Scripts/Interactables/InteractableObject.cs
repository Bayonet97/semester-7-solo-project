using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.Objects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public List<InteractionFlow> InteractionFlows = new List<InteractionFlow>();

        private int _interactionCount;

        [SerializeField]
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public string TextToShow { get; set; }
        public virtual void Interact()
        {
            // Default implementation.
            UpdateTextToShow(InteractionFlows[0]);
            _interactionCount++;
        }
        public virtual void Interact(bool hasItem)
        {
            // Default implementation.
            if (hasItem)
            {
                UpdateTextToShow(InteractionFlows[1]);
                _interactionCount++;
            }
            else
            {
                UpdateTextToShow(InteractionFlows[0]);
                _interactionCount++;
            }
        }

        public virtual void Interact(int amount)
        {
            // Default implementation.
            UpdateTextToShow(InteractionFlows[amount]);
            _interactionCount++;
        }

        public void UpdateTextToShow(InteractionFlow interactionFlow)
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
        }

        public void SetInteractionCount(int count)
        {
            _interactionCount = count;
        }
    }
}
