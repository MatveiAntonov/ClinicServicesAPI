using FluentValidation;
using Management.Application.Services.Queries.QueriesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.Queries.QueryValidators
{
    public class GetServiceQueryValidator : AbstractValidator<GetServiceQuery>
    {
        public GetServiceQueryValidator()
        {
            RuleFor(query => query.ServiceId).NotNull();
        }
    }
}
