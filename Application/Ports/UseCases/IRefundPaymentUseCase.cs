using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Ports.UseCases
{
    public interface IRefundPaymentUseCase
    {
        Task<RefundResponse> ExecuteAsync(RefundPaymentRequest request, CancellationToken cancellationToken = default);
    }


}
