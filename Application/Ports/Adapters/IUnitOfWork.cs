using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.Adapters
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPaymentRepository Payments { get; }
        IRefundRepository Refunds { get; }

        Task<int> SaveChangesAysnc(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
