using AuthService.Models;
using Grpc.Net.Client;
using AuthService;
using AuthService.Protos;
using AutoMapper;

namespace AuthService.Services;

public class GrpcDeviceService
{
    private readonly IMapper _mapper;
    
    public GrpcDeviceService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public Device ReturnAllDevices()
    {
        var httpHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        
        var channel = GrpcChannel.ForAddress("https://localhost:7262", new GrpcChannelOptions{HttpHandler = httpHandler});
        var client = new GrpcDevice.GrpcDeviceClient(channel);
        var request = new GetDeviceRequest();

        try
        {
            var reply = client.getDevice(request);
            //log
            Console.WriteLine("Devices: " + reply.Devices);
            return _mapper.Map<Device>(reply.Devices);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}