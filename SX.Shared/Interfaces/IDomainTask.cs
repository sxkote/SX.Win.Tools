using System;

namespace SX.Shared.Interfaces
{
    /// <summary>
    /// Defines Domain Task Argument to be fired
    /// </summary>
    public interface IDomainTask
    {
    }

    /// <summary>
    /// Defines Domain Task Result to be returned
    /// </summary>
    public interface IDomainTaskResult
    {
        void Merge(IDomainTaskResult result);
    }

    /// <summary>
    /// Defines the method that can execute Domain Task of type T
    /// </summary>
    /// <typeparam name="T">Domain Task type</typeparam>
    public interface IDomainTaskExecutor<T> : IDisposable
        where T : IDomainTask
        //where R : IDomainTaskResult
    {
        IDomainTaskResult Execute(T args);
    }
}
