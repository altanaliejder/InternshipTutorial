using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
