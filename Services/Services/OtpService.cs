using Common;
using Common.Exceptions;
using Data.Repositories;
using Entities.Auth;
using Kavenegar;
using Kavenegar.Models;
using Microsoft.Extensions.Options;
using System;
using System.Linq;


namespace Services.Services
{
    public class OtpService : IOtpService
    {
        private readonly IRepository<Auth> _authRepository;
        private readonly IRepository<Otp> _otpRepository;
        private readonly SiteSettings _siteSettings;
        public OtpService(IRepository<Auth> authRepository, IRepository<Otp> otpRepository, IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _authRepository = authRepository;
            _otpRepository = otpRepository;
            _siteSettings = siteSettings.Value;
        }
        public SendResult GetOneTimePassword(string mobileNumber)
        {
            var random = new Random();
            var smsApi = new KavenegarApi(_siteSettings.SmsApiKey);
            //var verificationCode = random.Next(1111, 9999);
            //SendResult result;
            //var result = smsApi.Send("", mobileNumber, $"کد تایید تل بال: {verificationCode}");
            var verificationCode = 1111;
            var result = new SendResult
            {
                Cost = 250,
                Date = 22255151,
                GregorianDate = DateTime.Now,
                Message = "کد : 1111",
                Messageid = 1,
                Receptor = "09394299889",
                Sender = "1000002030",
                Status = 1,
                StatusText = "ارسال به مخابرات",
            };
            var exist = _authRepository.Entities
                .Where(a => a.PhoneNumber == mobileNumber)
                .FirstOrDefault();
            var otp = new Otp
            {
                Auth = new Auth
                {
                    PhoneNumber = mobileNumber
                },
                Code = verificationCode,
                Cost = result.Cost,
                Date = result.GregorianDate,
                Sender = result.Sender,
                Receptor = result.Receptor,
                Message = result.Message,
                Status = result.Status,
                StatusText = result.StatusText,
            };
            if (result == null)
            {
                throw new AppException("ارسال پیامک موفقیت آمیز نبود");
            }
            else
            {
                if (exist == null)
                {
                    _otpRepository.Add(otp);
                }
                else
                {
                    otp.Auth = exist;
                    _otpRepository.Add(otp);
                }
            }
            return result;
        }
        public bool CheckOneTimePassword(string mobileNumber, int verficationCode)
        {
            var result = _otpRepository.TableNoTracking
                .OrderBy(p => p.Date)
                .Last();

            if (mobileNumber == result.Auth.PhoneNumber && verficationCode == result.Code)
                return true;
            return false;
        }
    }
}
