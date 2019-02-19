﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Eisk.Core.DomainService;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.Core.WebApi
{
    [Route("api/[controller]")]
    public abstract class WebApiControllerBaseAsync<TDomain,TId>: Controller
        where TDomain : class, new()
    {
        protected DomainServiceAsync<TDomain,TId> DomainService;
        protected WebApiControllerBaseAsync(DomainServiceAsync<TDomain, TId> domainService)
        {
            DomainService = domainService;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TDomain>> Get()
        {
            return await DomainService.GetAll();
        }

        [HttpGet("{id}")]
        public virtual async Task<TDomain> Get(TId id)
        {
            return await DomainService.GetById(id);
        }

        [HttpPost]
        public virtual async Task Post(TDomain domain)
        {
            await DomainService.Add(domain);
        }

        [HttpPut("{id}")]
        public virtual async Task Put(TId id, TDomain domain)
        {
            await DomainService.Update(id, domain);
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(TId id)
        {
            await DomainService.Delete(id);
        }
    }
}
