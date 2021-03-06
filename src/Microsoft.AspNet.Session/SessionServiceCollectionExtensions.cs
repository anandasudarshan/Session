// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Session;
using Microsoft.Framework.Internal;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for adding session services to the DI container.
    /// </summary>
    public static class SessionServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required for application session state.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSession([NotNull] this IServiceCollection services)
        {
            services.AddOptions();
            services.AddTransient<ISessionStore, DistributedSessionStore>();
            return services;
        }

        /// <summary>
        /// Configures the session.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure the services.</param>
        /// <param name="configure">The session options to configure the middleware with.</param>
        public static void ConfigureSession(
            [NotNull] this IServiceCollection services,
            [NotNull] Action<SessionOptions> configure)
        {
            services.Configure(configure);
        }
    }
}