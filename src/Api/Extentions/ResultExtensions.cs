using CSharpFunctionalExtensions;

namespace Api.Extentions;

public static class ResultExtensions
{
    public static Microsoft.AspNetCore.Http.IResult ToActionResult(this Result result)
    {
        if (result.IsSuccess)
            return Results.Ok(result);

        return MapFailureToHttpResponse(result.Error);
    }

    public static Microsoft.AspNetCore.Http.IResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return MapFailureToHttpResponse(result.Error);
    }


    private static Microsoft.AspNetCore.Http.IResult MapFailureToHttpResponse(string error)
    {
        if (error.Contains(StatusCodes.Status404NotFound.ToString()))
            return Results.NotFound();


        if (error.Contains(StatusCodes.Status500InternalServerError.ToString()))
            return Results.Problem();

        return Results.BadRequest(error);
    }
}
