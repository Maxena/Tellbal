
using Data.Repositories;
using Entities.User;
using Kavenegar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;

namespace Tellbal.Controllers
{
    [ApiController]
    [Route("/api/auth/")]
    public class Authentication : Controller
    {
        private readonly IJwtService jwtService;
        private readonly IOtpService otpService;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Province> _provinceRepository;
        public Authentication(IJwtService jwtService, IOtpService otpService, IRepository<User> userRepository, IRepository<Province> provinceRepository)
        {
            this.jwtService = jwtService;
            this.otpService = otpService;
            _userRepository = userRepository;
            _provinceRepository = provinceRepository;
        }
        [HttpPost("otp/{mobileNumber}")]
        [AllowAnonymous]
        public ApiResult<SendResult> GetOtp(string mobileNumber)
        {
            SendResult result;
            if(ModelState.IsValid)
            {
                result = otpService.GetOneTimePassword(mobileNumber);
            }
            else
            {
                return BadRequest("wrong input");
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResult<string>> Auth(string mobileNumber, int verficationCode, CancellationToken cancellationToken)
        {
            if (otpService.CheckOneTimePassword(mobileNumber, verficationCode))
            {
                var user = new User
                {
                    PhoneNumber = mobileNumber
                };
                await _userRepository.AddAsync(user, cancellationToken);
                var jwt = jwtService.Generate(user);
                return Ok(jwt);
            }
            return BadRequest();
        }
        [HttpPost("register")]
        public async Task<ApiResult<string>> Register(User user, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var checkPhoneNumber = _userRepository.TableNoTracking
                    .Where(p => p.PhoneNumber == user.PhoneNumber)
                    .FirstOrDefault();
                if (checkPhoneNumber != null)
                {
                    return BadRequest();
                }
                else
                {
                    await _userRepository.AddAsync(user, cancellationToken);

                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpGet("gettest")]
        public IActionResult GetTest()
        {
            var result = _userRepository.TableNoTracking.Include(p => p.Province);
            Console.WriteLine(result);
            return Ok(result);
        }
        [HttpGet("cities")]
        public IActionResult Cities()
        {
            return null;
        }
    }
}
