using Application.DTOs.Responses;

namespace Application.Ports.UseCases
{
    public interface IGetPaymentStatusUseCase
    {
        Task<PaymentStatusResponse> ExecuteAsync(Guid paymentId, CancellationToken cancellationToken = default);
        Task<PaymentStatusResponse> ExecuteByOrderIdAsync(string orderId, CancellationToken cancellationToken = default);
    }


}
