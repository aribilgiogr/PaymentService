using Application.DTOs.Responses;

namespace Application.Ports.UseCases
{
    public interface IGetPaymentDetailUseCase
    {
        Task<PaymentResponse> ExecuteAsync(Guid paymentId, CancellationToken cancellationToken = default);
    }


}
