using System.Collections.Generic;

namespace Content.Scripts.Utilities
{
    public class UpdatersList : IUpdater
    {
        private readonly List<IUpdater> _updaters = new();
        private readonly List<IUpdater> _toAddUpdaters = new();
        private readonly List<IUpdater> _toRemoveUpdaters = new();
        
        public void Update(float deltaTime)
        {
            foreach (var updater in _toRemoveUpdaters)
            {
                _updaters.Remove(updater);
            }

            foreach (var updater in _toAddUpdaters)
            {
                _updaters.Add(updater);
            }
            
            foreach (var updater in _updaters)
            {
                updater.Update(deltaTime);
            }
        }

        public void Add(IUpdater updater)
        {
            _toAddUpdaters.Add(updater);
        }

        public void Remove(IUpdater updater)
        {
            _toRemoveUpdaters.Remove(updater);
        }

        public void Clear()
        {
            _updaters.Clear();
        }
        
    }
}