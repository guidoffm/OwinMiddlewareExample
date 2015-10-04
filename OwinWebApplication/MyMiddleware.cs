using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinWebApplication
{
    public class MyMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public MyMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);

            context.Request.User = new GenericPrincipal(new GenericIdentity("Test user"), new string[] {});

            Debug.Write(context.Request.User.Identity.Name);

            await _next.Invoke(env);
        }
    }
}