using AdvertiseService.Application;
using AdvertiseService.Application.Features.Ads.Commands;
using AdvertiseService.Application.Features.Ads.Queries;
using AdvertiseService.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvertiseService.Presentation.Controllers
{
    /// <summary>
    /// کنترلر مدیریت آگهی‌های ملکی
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] 
    public class AdsController : ControllerBase
    {
        private readonly JwtService jwtService;
        private readonly IMediator _mediator;
         

        public AdsController(JwtService jwtService, IMediator mediator)
        { 
            this.jwtService = jwtService;
            _mediator = mediator;
        }

        /// <summary>
        /// ایجاد آگهی جدید
        /// </summary>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateAdCommand command)
        {

            // دریافت توکن از هدر درخواست
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null || !jwtService.ValidateToken(token))
            {
                return Unauthorized("Token not Valid.");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// بایگانی آگهی  
        /// </summary>
        [HttpPost("Archive")] 
        public async Task<IActionResult> ArchiveAd([FromBody] ArchiveAdCommand command)
        {

            // دریافت توکن از هدر درخواست
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null || jwtService.ValidateToken(token))
            {
                return Unauthorized("Token not Valid.");
            }

            await _mediator.Send(command);
            return Ok();
        }


        /// <summary>
        ///  PAGE جستوجوی لیست آگهی های ملکی به صورت     
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdsPaged([FromQuery] GetAdsPagedQuery query)
        {

            // دریافت توکن از هدر درخواست
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null || jwtService.ValidateToken(token))
            {
                return Unauthorized("Token not Valid.");
            }
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
