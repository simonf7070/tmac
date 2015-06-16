using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAL.DomainEvents
{
    public interface IDomainEvent
    { }

    public class NetworkAssetUpdated : IDomainEvent
    {
        public string Name { get; set; }
    }

    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        //public static IContainer Container { get; set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>) action)(args);
        }
    }

    public interface Handles<T> where T : IDomainEvent
    {
        void Handle(T args);
    }

    public class NetworkAssetUpdatedHandler : Handles<NetworkAssetUpdated>
    {
        public void Handle(NetworkAssetUpdated args)
        {
            // send email etc
        }
    }
}
