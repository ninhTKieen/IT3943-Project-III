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

    public override async Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        try
        {
            var response = new GetUserResponse();
            var user = await _context.Users.FindAsync(request.Id);
        
            if (user == null)
            {
                response.User = new PUser
                {
                    Id = 0,
                    Role = "none",
                    Username = "None",
                    LastName = "None"
                };
                return (response);
            }
            else
            {
                response.User = new PUser
                {
                    Id = user.Id,
                    Role = user.Role,
                    Username = user.Username,
                    LastName = user.LastName
                };
                return (response);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}