using System.Collections.Generic;
using PetrovDA.Utils.InputController.ScreenRegistrator;
using PetrovDA.Utils.InputController.AxisRegistrator;
using PetrovDA.Utils.Interface;

namespace PetrovDA.Utils.InputController
{
    public class InputController : IMonoBehaviourUpdate
    {
        private Dictionary<int, AbstractScreenRegistrator> screenTouchReistratorsDictionary = new Dictionary<int, AbstractScreenRegistrator>();
        private AbstractAxisRegistrator axisDirectionRegistrator;
        private List<IMonoBehaviourUpdate> updatableComponentsList = new List<IMonoBehaviourUpdate>();

        public AbstractAxisRegistrator AxisDirectionRegistrator 
        { 
            get => axisDirectionRegistrator; 
            set => axisDirectionRegistrator = AddComponent(value); 
        }

        public void SetScreenTouchRegistrator(int index, AbstractScreenRegistrator registrator)
        {
            registrator.MouseButtonIndex = index;
            screenTouchReistratorsDictionary.Add(index, registrator);
            AddComponent(registrator);
        }

        public AbstractScreenRegistrator ScreenRegistrator(int index)
        {
            AbstractScreenRegistrator registrator;
            screenTouchReistratorsDictionary.TryGetValue(index, out registrator);
            return registrator;
        }

        public void Update()
        {
            foreach (IMonoBehaviourUpdate component in updatableComponentsList) component.Update();
        }

        private T AddComponent<T>(T component) where T : IMonoBehaviourUpdate
        {
            updatableComponentsList.Add(component);
            return component;
        }
    }
}

