using AuthService.Data;
using AuthService.Protos;
using AutoMapper;
using Grpc.Core;

namespace AuthService.Services;

public class GrpcUserService : GrpcUser.GrpcUserBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GrpcUserService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public override Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var response = new GetUserResponse();
        var user = _context.Users.Find(request.Id);
        
        if (user == null)
        {
            response.User.Id = 0;
            response.User.Role = "none";
            response.User.Username = "none";
            response.User.LastName = "none";
            return Task.FromResult(response);
        }

        response.User = new PUser
        {
            Id = user.Id,
            Role = user.Role,
            Username = user.Username,
            LastName = user.LastName
        };
        return Task.FromResult(response);
    }
}