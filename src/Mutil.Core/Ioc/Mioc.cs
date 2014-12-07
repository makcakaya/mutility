using Mutil.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Mutil.Core.Ioc
{
    public sealed class Mioc
    {
        private object _lock = new object();
        private Dictionary<Type, object> _objRepo = new Dictionary<Type, object>();
        private Dictionary<Type, Func<object, object>> _factoryRepo = new Dictionary<Type, Func<object, object>>();

        #region Methods

        public void Register<IType>(IType obj)
            where IType : class
        {
            if (Contains<IType>()) { throw new AlreadyRegisteredException(typeof(IType)); }
            _objRepo.Add(typeof(IType), obj);
        }

        public void Register<IType>(Func<object, IType> factory)
            where IType : class
        {
            if (Contains<IType>()) { throw new AlreadyRegisteredException(typeof(IType)); }
            _factoryRepo.Add(typeof(IType), factory);
        }

        public IType Resolve<IType>(object arg = null) where IType : class
        {
            var containment = GetContainmentType<IType>();
            if (containment == ContainmentType.None) { throw new NotRegisteredException(typeof(IType)); }
            else if (containment == ContainmentType.Object) { return (IType)_objRepo[typeof(IType)]; }
            else { return (IType)_factoryRepo[typeof(IType)](arg); }
        }

        public ContainmentType GetContainmentType<IType>() where IType : class
        {
            if (_objRepo.ContainsKey(typeof(IType))) { return ContainmentType.Object; }
            if (_factoryRepo.ContainsKey(typeof(IType))) { return ContainmentType.Factory; }
            return ContainmentType.None; // If all fails
        }

        public bool Contains<IType>() where IType : class
        {
            return GetContainmentType<IType>() == ContainmentType.None ? false : true;
        }

        #endregion
    }
}
