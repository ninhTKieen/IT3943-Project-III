using AutoMapper;
using DeviceManagement.Data;
using DeviceManagement.Protos;
using Grpc.Core;

namespace DeviceManagement.Services;

public class GrpcDeviceService: GrpcDevice.GrpcDeviceBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GrpcDeviceService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public override Task<GetDeviceResponse> getDevice(GetDeviceRequest request, ServerCallContext context)
    {
        var response = new GetDeviceResponse();
        var devices = _context.Devices.Find(5);

        response.Devices = _mapper.Map<PDevice>(devices);
        return Task.FromResult(response);
    }
}