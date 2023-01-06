using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        
        public IResult Add(OperationClaim operationClaim)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            throw new NotImplementedException();
        }

        public IDataResult<OperationClaim> Get(int operationClaimId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(OperationClaim operationClaim)
        {
            throw new NotImplementedException();
        }
    }
}
