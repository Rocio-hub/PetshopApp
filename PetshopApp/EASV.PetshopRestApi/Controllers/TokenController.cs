using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetshopApp.Core.DomainService;

namespace EASV.PetshopRestApi.Controllers
{
    [Route("/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IUserRepository repository;
    }
}
