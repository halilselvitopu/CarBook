﻿using CarBook.Application.Features.Mediator.Results.RentalPriceResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.RentalPriceInterfaces
{
    public interface IRentalPriceRepository
    {
        Task<List<RentalPrice>> GetRentalPrices();
        Task<List<GetRentalPriceWithTimePeriodQueryResult>> GetRentalPricesWithTimePeriod();
    }
}
