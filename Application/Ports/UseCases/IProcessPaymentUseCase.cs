using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.UseCases
{
    public interface IProcessPaymentUseCase
    {
        Task<PaymentResponse> ExecuteAsync(ProcessPaymentRequest request, CancellationToken cancellationToken = default);
    }
}
