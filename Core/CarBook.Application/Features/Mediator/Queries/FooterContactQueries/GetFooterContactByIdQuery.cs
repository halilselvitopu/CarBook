using CarBook.Application.Features.Mediator.Results.FooterContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterContactQueries
{
    public class GetFooterContactByIdQuery : IRequest<GetFooterContactByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFooterContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
