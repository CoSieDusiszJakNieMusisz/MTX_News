using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTX_News.Infrastructure
{
    public interface ISessionManager
    {
        int GetSessionID();
        void Set<T>(string name, T value);
        void Abandon();
        T TryGet<T>(string key);
    }
}