using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;

namespace AbarrotesHogar.Services.Interfaces;

public interface IServicesAuth
{
    AuthResponse Login(AuthRequest request);
}