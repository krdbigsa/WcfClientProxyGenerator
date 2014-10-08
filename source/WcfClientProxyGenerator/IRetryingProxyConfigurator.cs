﻿using System;
using WcfClientProxyGenerator.Policy;

namespace WcfClientProxyGenerator
{
    /// <summary>
    /// Proxy configuration options for managing retry logic
    /// </summary>
    public interface IRetryingProxyConfigurator : IProxyConfigurator
    {
        /// <summary>
        /// Specifies the maximum amount of retries that should be made
        /// when known failures happen during a service call.
        /// </summary>
        /// <param name="retryCount"></param>
        void MaximumRetries(int retryCount);
        
        /// <summary>
        /// Configures the proxy to use a specific <see cref="IDelayPolicy"/>
        /// to determine the amount of time to wait between call retries.
        /// </summary>
        /// <param name="policyFactory"></param>
        void SetDelayPolicy(Func<IDelayPolicy> policyFactory);

        /// <summary>
        /// Specifies an exception case to trigger a call retry.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="where"></param>
        void RetryOnException<TException>(Predicate<TException> where = null)
            where TException : Exception;

        /// <summary>
        /// Specifies an exception case to trigger a call retry.
        /// </summary>
        /// <param name="exceptionType"></param>
        /// <param name="where">Predicate defining the case to retry on</param>
        void RetryOnException(Type exceptionType, Predicate<Exception> where = null);

        /// <summary>
        /// Specifies a case based on a service response to trigger a call retry.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="where">Predicate defining the case to retry on</param>
        void RetryOnResponse<TResponse>(Predicate<TResponse> where);
    }
}
