using System;
using System.Collections.Generic;

namespace Content.Scripts.Utilities
{
    public class PresentersList : IPresenter
    {
        private readonly List<IPresenter> _presenters = new();

        public void Add(IPresenter presenter)
        {
            _presenters.Add(presenter);
        }

        public void Remove(IPresenter presenter)
        {
            presenter.Dispose();
            _presenters.Remove(presenter);
        }

        public void Clear()
        {
            _presenters.Clear();
        }
        
        public void Init()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Init();
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}