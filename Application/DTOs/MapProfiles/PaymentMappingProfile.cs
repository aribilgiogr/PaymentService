using Application.DTOs.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MapProfiles
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentResponse>()
                .ForMember(d => d.PaymentId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount.Value))
                .ForMember(d => d.Currency, o => o.MapFrom(s => s.Amount.Currency.ToString()))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Provider, o => o.MapFrom(s => s.Provider.ToString()))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(s => s.Method));

            CreateMap<Transaction, TransactionResponseDto>()
                .ForMember(d => d.TransactionId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => s.StatusAtTime.ToString()));

            CreateMap<RefundRequest, RefundResponse>()
                .ForMember(d => d.RefundId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount.Value))
                .ForMember(d => d.Currency, o => o.MapFrom(s => s.Amount.Currency.ToString()))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<PaymentMethod, PaymentMethodResponseDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.WalletProvider, o => o.MapFrom(s => s.AdditionalData.ContainsKey("Provider") ? s.AdditionalData["Provider"] : null));

        }
    }
}
