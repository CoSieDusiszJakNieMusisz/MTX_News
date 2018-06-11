using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MTX_News.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState session;

        public SessionManager()
        {
            session = HttpContext.Current.Session;
        }

        public void Abandon()
        {
            throw new NotImplementedException();
        }

        public int GetSessionID()
        {
            return session.LCID;
        }

        public void Set<T>(string name, T value)
        {
            throw new NotImplementedException();
        }

        public T TryGet<T>(string key)
        {
            throw new NotImplementedException();
        }
    }
}