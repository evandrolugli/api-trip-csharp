
using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    public void Validate(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Name MUST NOT be empty");
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new ArgumentException("MUST BE from now and then date");
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            throw new ArgumentException("EndDate MUST BE after StartDate");
        }
    }
}