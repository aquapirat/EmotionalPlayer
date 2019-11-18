﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Player.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListVm>
    {
        private readonly IPlayerDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IPlayerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriesListVm> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CategoriesListVm
            {
                Categories = categories,
                Count = categories.Count
            };

            return vm;
        }
    }
}