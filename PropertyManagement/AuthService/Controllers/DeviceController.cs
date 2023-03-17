// using AuthService.Models;
// using AuthService.Services;
// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace AuthService.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// [Authorize]
// public class DeviceController : ControllerBase
// {
//     private readonly IMapper _mapper;
//     private readonly GrpcDeviceService _grpcDeviceService;
//     
//     public DeviceController(IMapper mapper, GrpcDeviceService grpcDeviceService)
//     {
//         _mapper = mapper;
//         _grpcDeviceService = grpcDeviceService;
//     }
//     
//     // GET
//     [HttpGet]
//     public async Task<ActionResult<Device>> GetDevice()
//     {
//         var device = _grpcDeviceService.ReturnAllDevices();
//         Console.WriteLine("Device: " + device);
//         return Ok(device);
//     }
// }