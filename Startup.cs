﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(W2022A6YH.Startup))]

namespace W2022A6YH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
