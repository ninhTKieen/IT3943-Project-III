using AutoMapper;
using DeviceManagement.Data;
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

    public override Task<GetAllResponse> getDevice(GetAllDeviceRequest request, ServerCallContext context)
    {
        var response = new GetAllResponse();
        var devices = _context.Devices.ToList();

        foreach (var device in devices)
        {
            response.Devices.Add(_mapper.Map<GrpcDeviceModel>(device));
        }

        return Task.FromResult(response);
    }
}