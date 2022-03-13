using Catalogo.API.ViewModels;
using System.Collections.Generic;

namespace Catalogo.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            var result = new ResultViewModel();
            result.Data = null;
            result.Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.";
            result.Success = false;

            return result;
        }
        
        public static ResultViewModel DomainErrorMessage(string message)
        {
            var result = new ResultViewModel();
            result.Data = null;
            result.Message = message;
            result.Success = false;

            return result;
        }
        
        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            var result = new ResultViewModel();
            result.Data = errors;
            result.Message = message;
            result.Success = false;

            return result;
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            var result = new ResultViewModel();
            result.Data = null;
            result.Message = "A combinação de login e senha está incorreta!";
            result.Success = false;

            return result;
        }
    }
}
