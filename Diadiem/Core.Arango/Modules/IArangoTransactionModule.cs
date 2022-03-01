﻿using System.Threading;
using System.Threading.Tasks;
using Core.Arango.Protocol;

namespace Core.Arango.Modules
{
    /// <summary>
    ///     Stream and JavaScript transactions
    /// </summary>
    public interface IArangoTransactionModule
    {
        /// <summary>
        ///     Begin a server-side transaction
        /// </summary>
        Task<ArangoHandle> BeginAsync(ArangoHandle database, ArangoTransaction request,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Abort a server-side transaction
        /// </summary>
        Task AbortAsync(ArangoHandle database, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Commit a server-side transaction
        /// </summary>
        Task CommitAsync(ArangoHandle database, CancellationToken cancellationToken = default);

        /// <summary>
        ///     execute a server-side (script) transaction
        /// </summary>
        Task<T> ExecuteAsync<T>(ArangoHandle database, ArangoTransaction request,
            CancellationToken cancellationToken = default);
    }
}