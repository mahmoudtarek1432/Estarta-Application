namespace Estarta_Application.Controllers.Employee
{
    public record struct GetEmpStatusEndpointRequest
    {

    }

	//Hey there, quick tip, declaring a record by default uses a class base, which isnt really optimal when dealing with simple request/response DTOs.
    //specifying a struct record makes things way faster.
}
