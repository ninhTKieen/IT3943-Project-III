using AssetManagement.Models;
using AutoMapper;
using Grpc.Net.Client;
using AssetManagement.Protos;

namespace AssetManagement.Services;

public class GrpcService
{
    private readonly IMapper _mapper;
    
    public GrpcService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public GrpcUserM GetUser(int userId)
    {
        var httpHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        
        var channel = GrpcChannel.ForAddress("https://localhost:9000", new GrpcChannelOptions{HttpHandler = httpHandler});
        var client = new GrpcUser.GrpcUserClient(channel);
        var request = new GetUserRequest
        {
            Id = userId
        };

        try
        {
            var reply = client.GetUser(request);
            // if(reply)
            //log
            Console.WriteLine("Devices: " + reply.User);
            var result = new GrpcUserM
            {
                Id = reply.User.Id,
                Role = reply.User.Role,
                Username = reply.User.Username,
                LastName = reply.User.LastName
            };
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
}