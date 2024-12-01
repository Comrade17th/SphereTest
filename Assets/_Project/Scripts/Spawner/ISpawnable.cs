using System;

namespace _Project.Scripts
{
    public interface ISpawnable<T>
    {
        public event Action<T> Destroying;
    }
}