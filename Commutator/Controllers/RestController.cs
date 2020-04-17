﻿using Entity.ViewModal.Rest;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Commutator.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RestController : ControllerBase
    {
        IServiceProvider _provider;
        public RestController(IServiceProvider provider)
        {
            _provider = provider;

        }

        [HttpPost]
        public Task<string> FromRequest([FromBody]RestViewModal modal)
        {
            var projectName = Request.Headers.FirstOrDefault(m => m.Key.ToLower() == "coroname").Value;
            if (string.IsNullOrEmpty(projectName))
            {
                return Task.Factory.StartNew<string>(() => SendUnuthorize(_provider, modal));
            }
            return Task.Factory.StartNew<string>(() => SendAuthorize(_provider, modal));
        }
        private string SendUnuthorize(IServiceProvider provider, RestViewModal modal)
        {
            
        }
        private string SendAuthorize(IServiceProvider provider, RestViewModal modal)
        {
            
        }

    }





}